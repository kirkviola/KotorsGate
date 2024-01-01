using KotorsGate.Application.Campaigns.Models;

namespace KotorsGate.Application.Campaigns.Interfaces
{
    public interface ICreateCampaignWithPlanets
    {
        public Task CreateAsync(CampaignWithPlanets campaign);
    }
}
