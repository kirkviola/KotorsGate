using KotorsGate.Application.Campaigns.Models;
using KotorsGate.Domain.Entities.Campaigns;

namespace KotorsGate.Application.Campaigns.Interfaces
{
    public interface ICreateNewCampaign
    {
        public Task<Campaign> CreateAsync(CampaignBasic campaign);
    }
}
