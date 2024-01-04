using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Campaigns.Models;
using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Campaigns
{
    public class GetOneCampaignById : IGetOneCampaignById
    {

        private readonly IKotorsGateDbContext _context;

        public GetOneCampaignById(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task<CampaignBasic?> GetAsync(int id) {
            var raw = await _context.Campaigns.Where(x => x.Id == id)
                                            .Include(x => x.Planets)
                                            .FirstOrDefaultAsync()
                ?? throw new CampaignNotFoundException(id);

            if (raw == null) {
                return null;
            } else {
                return new CampaignBasic(
                    raw,
                    raw.Planets.ToList()
                    ); 
            }
        }
    }
}
