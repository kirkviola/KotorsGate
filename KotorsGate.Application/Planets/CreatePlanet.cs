using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Planets.Interfaces;
using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Application.Planets
{
    public class CreatePlanet : ICreatePlanet
    {
        private readonly IKotorsGateDbContext _context;
        private readonly IGetOnePlanetByName _getOnePlanetByName;

        public CreatePlanet(IKotorsGateDbContext context, IGetOnePlanetByName getOnePlanetByName) {
            _context = context;
            _getOnePlanetByName = getOnePlanetByName;
        }

        public async Task CreateAsync(Planet planet) {

            var existingPlanet = await _getOnePlanetByName.GetAsync(planet.Name);

            if (existingPlanet != null) {
                throw new PlanetAlreadyExistsException(planet.Name);
            }

            await _context.Planets.AddAsync(planet);

            await _context.SaveChangesAsync();
        }
    }
}
