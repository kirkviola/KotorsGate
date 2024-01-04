using KotorsGate.Application.Campaigns.Models;

namespace KotorsGate.Application.Campaigns.Interfaces
{
    public interface IGetOneCampaignById
    {
        public Task<CampaignBasic?> GetAsync(int id);
    }
}
