using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Campaigns;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Campaigns
{
    public class GetOneCampaignByName : IGetOneCampaignByName
    {
        private readonly IKotorsGateDbContext _context;

        public GetOneCampaignByName(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task<Campaign?> GetAsync(string name) {
            return await _context.Campaigns.SingleOrDefaultAsync(c => c.Name == name);
        }
    }
}
