using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Campaigns.Models;
using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Campaigns
{
    public class CreateCampaignWithPlanets : ICreateCampaignWithPlanets
    {
        private readonly IKotorsGateDbContext _context;
        private readonly ICreateNewCampaign _createNewCampaign;
        private readonly IGetOneCampaignByName _getOneCampaignByName;

        public CreateCampaignWithPlanets(IKotorsGateDbContext context, ICreateNewCampaign createNewCampaign, IGetOneCampaignByName getOneCampaignByName) {
            _context = context;
            _createNewCampaign = createNewCampaign;
            _getOneCampaignByName = getOneCampaignByName;
        }

        public async Task CreateAsync(CampaignWithPlanets campaign) {

            if (await _getOneCampaignByName.GetAsync(campaign.Campaign.Name) != null) {
                throw new CampaignWithNameExistsException(campaign.Campaign.Name);
            }

            await _context.Campaigns.AddAsync(campaign.Campaign);

            await _context.SaveChangesAsync();

            var newCampaign = await _context.Campaigns.SingleOrDefaultAsync(x => x.Name == campaign.Campaign.Name);

            foreach (var planet in campaign.Planets) {
                var campaignPlanet = new CampaignPlanet { CampaignId = newCampaign!.Id, PlanetId = planet.Id };
                await _context.CampaignPlanets.AddAsync(campaignPlanet);
                await _context.SaveChangesAsync();
            }


        }
    }
}
