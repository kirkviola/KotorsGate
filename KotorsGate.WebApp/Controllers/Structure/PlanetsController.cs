using KotorsGate.Application.Planets.Interfaces;
using KotorsGate.Domain.Entities.Locations;
using KotorsGate.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KotorsGate.WebApp.Controllers.Structure
{
    public class PlanetsController : ApiControllerBase
    {
        private readonly IGetAllPlanets _getAllPlanets;
        private readonly IGetOnePlanetById _getOnePlanetById;
        private readonly ICreatePlanet _createPlanet;

        public PlanetsController(IGetAllPlanets getAllPlanets, IGetOnePlanetById getOnePlanetById, ICreatePlanet createPlanet) {
            _getAllPlanets = getAllPlanets;
            _getOnePlanetById = getOnePlanetById;
            _createPlanet = createPlanet;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetAllPlanets() {
            return Ok(await _getAllPlanets.GetAsync());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Planet?>> GetOneById(int id) {
            try {
                return Ok(await _getOnePlanetById.GetAsync(id));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = SecurityRule.PlanetCreate)]
        [HttpPost]
        public async Task<IActionResult> CreatePlanet(Planet planet) {

            if (planet == null) {
                return BadRequest();
            }

            try {
                await _createPlanet.CreateAsync(planet);

                return CreatedAtAction("GetOneById", new { id = planet.Id }, planet);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }
    }
}
