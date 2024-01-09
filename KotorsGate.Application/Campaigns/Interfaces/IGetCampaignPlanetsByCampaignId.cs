using KotorsGate.Application.Campaigns.Models;

namespace KotorsGate.Application.Campaigns.Interfaces
{
    public interface IGetCampaignPlanetsByCampaignId
    {
        public Task<IEnumerable<CampaignPlanetWithName>> GetAllAsync(int campaignId);
    }
}
