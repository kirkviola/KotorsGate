using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Planets.Interfaces;
using KotorsGate.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Planets
{
    public class GetAllPlanets : IGetAllPlanets
    {
        private readonly IKotorsGateDbContext _context;

        public GetAllPlanets(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Planet>> GetAsync() {
            return await _context.Planets.ToListAsync() ?? [];
        }
    }
}
