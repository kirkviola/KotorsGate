using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Campaigns;

namespace KotorsGate.Application.Campaigns
{
    public class GetOneCampaignById : IGetOneCampaignById
    {

        private readonly IKotorsGateDbContext _context;

        public GetOneCampaignById(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task<Campaign?> GetAsync(int id) {
            return await _context.Campaigns.FindAsync(id) ?? throw new CampaignNotFoundException(id);
        }
    }
}
