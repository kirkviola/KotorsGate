using KotorsGate.Application.Campaigns.Interfaces;
using KotorsGate.Application.Campaigns.Models;
using KotorsGate.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Campaigns
{
    public class GetCampaignPlanetsByCampaignId : IGetCampaignPlanetsByCampaignId
    {
        private readonly IKotorsGateDbContext _context;

        public GetCampaignPlanetsByCampaignId(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<CampaignPlanetWithName>> GetAllAsync(int campaignId) {
            var raw = await _context.CampaignPlanets.Where(x => x.CampaignId == campaignId)
                                                    .Include(p => p.Planet)
                                                    .ToListAsync() ?? [];

            return raw.Select(x => new CampaignPlanetWithName(x.Planet.Name, x.Id));
        }
    }
}
