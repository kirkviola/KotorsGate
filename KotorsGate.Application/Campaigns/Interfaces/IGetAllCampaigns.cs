using KotorsGate.Domain.Entities.Campaigns;

namespace KotorsGate.Application.Campaigns.Interfaces
{
    public interface IGetAllCampaigns
    {
        Task<IEnumerable<Campaign>> GetAllAsync();
    }
}
