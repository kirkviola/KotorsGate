using KotorsGate.Domain.Entities.Campaigns;

namespace KotorsGate.Application.Campaigns.Interfaces
{
    public interface IGetOneCampaignByName
    {
        public Task<Campaign?> GetAsync(string name);
    }
}
