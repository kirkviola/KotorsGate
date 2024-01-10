using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Campaigns.Models;
using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Campaigns;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Campaigns
{
    public class CreateNewCampaign : ICreateNewCampaign
    {

        private readonly IKotorsGateDbContext _context;
        private readonly IGetOneCampaignByName _getOneCampaignByName;

        public CreateNewCampaign(IKotorsGateDbContext context, IGetOneCampaignByName getOneCampaignByName)
        {
            _context = context;
            _getOneCampaignByName = getOneCampaignByName;
        }

        public async Task<Campaign> CreateAsync(CampaignBasic campaign)
        {
            if  (await _getOneCampaignByName.GetAsync(campaign.Campaign.Name) != null) {
                throw new CampaignWithNameExistsException(campaign.Campaign.Name);
            }

            var ids = campaign.Planets.Select(x => x.Id).ToList();

            var planets = await _context.Planets.Where(x => ids.Contains(x.Id)).ToListAsync();

            var newCampaign = new Campaign { Name = campaign.Campaign.Name, 
                                             Description = campaign.Campaign.Description,
                                             Planets = planets };

            _context.Campaigns.Add(newCampaign);

            await _context.SaveChangesAsync();

            return newCampaign;
        }
    }
}
