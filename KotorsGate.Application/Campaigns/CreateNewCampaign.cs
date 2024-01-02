using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Campaigns;

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

        public async Task CreateAsync(Campaign campaign)
        {
            if  (await _getOneCampaignByName.GetAsync(campaign.Name) != null) {
                throw new CampaignWithNameExistsException(campaign.Name);
            }

            _context.Campaigns.Add(campaign);

            await _context.SaveChangesAsync();
        }
    }
}
