using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Campaigns;
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

        public async Task<Campaign?> GetAsync(int id) {
            return await _context.Campaigns.Where(x => x.Id == id)
                                            .Include(x => x.CampaignPlanets ?? new List<CampaignPlanet>())
                                            .ThenInclude(x => x.Planet)
                                            .FirstOrDefaultAsync()
                ?? throw new CampaignNotFoundException(id);
        }
    }
}
