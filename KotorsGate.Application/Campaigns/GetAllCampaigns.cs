using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Campaigns;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Campaigns
{
    public class GetAllCampaigns : IGetAllCampaigns
    {
        private readonly IKotorsGateDbContext _context;

        public GetAllCampaigns(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Campaign>> GetAllAsync() {
            return await _context.Campaigns.ToListAsync() ?? [];
        }
    }
}
