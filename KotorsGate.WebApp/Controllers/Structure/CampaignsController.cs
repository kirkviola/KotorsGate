using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Campaigns.Models;
using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KotorsGate.WebApp.Controllers.Structure
{
    public class CampaignsController : ApiControllerBase
    {
        private readonly IGetAllCampaigns _getAllCampaigns;
        private readonly IGetOneCampaignById _getOneCampaignById;
        private readonly ICreateNewCampaign _createNewCampaign;
        private readonly IGetCampaignPlanetsByCampaignId _getCampaignPlanetsByCampaignId;

        public CampaignsController(IGetAllCampaigns getAllCampaigns, 
                                   IGetOneCampaignById getOneCampaignById, 
                                   ICreateNewCampaign createNewCampaign, 
                                   IGetCampaignPlanetsByCampaignId getCampaignPlanetsByCampaignId) {
            _getAllCampaigns = getAllCampaigns;
            _getOneCampaignById = getOneCampaignById;
            _createNewCampaign = createNewCampaign;
            _getCampaignPlanetsByCampaignId = getCampaignPlanetsByCampaignId;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> GetAllCampaigns() {
            return Ok(await _getAllCampaigns.GetAllAsync());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CampaignBasic?>> GetOneById(int id) {

            try {
               return Ok(await _getOneCampaignById.GetAsync(id));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = SecurityRule.CampaignCreator)]
        [HttpPost]
        public async Task<IActionResult> CreateCampaign(CampaignBasic campaign) {
            
            if (campaign == null) {
                return BadRequest();
            }

            try {
                var created = await _createNewCampaign.CreateAsync(campaign);

                return CreatedAtAction("GetOneById", new { id = created.Id }, created);
            } catch (Exception ex) {
                return BadRequest(ex);
            }

        }

        [Authorize(Policy = SecurityRule.CampaignCreator)]
        [HttpGet("campaign-planets/{campaignId}")]
        public async Task<ActionResult<IEnumerable<CampaignPlanetWithName>>> GetCampaignPlanets(int campaignId) {

            return Ok(await _getCampaignPlanetsByCampaignId.GetAllAsync(campaignId));
        }
    }
}
