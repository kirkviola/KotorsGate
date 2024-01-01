using KotorsGate.Domain.Entities.Campaigns;

namespace KotorsGate.Application.Campaigns.Interfaces
{
    public interface IGetOneCampaignById
    {
        public Task<Campaign?> GetAsync(int id);
    }
}
