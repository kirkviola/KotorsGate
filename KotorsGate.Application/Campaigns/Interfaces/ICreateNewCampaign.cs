using KotorsGate.Domain.Entities.Campaigns;

namespace KotorsGate.Application.Campaigns.Interfaces
{
    public interface ICreateNewCampaign
    {
        public Task CreateAsync(Campaign campaign);
    }
}
