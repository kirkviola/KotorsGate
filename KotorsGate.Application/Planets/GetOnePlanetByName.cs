using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Planets.Interfaces;
using KotorsGate.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Planets
{
    public class GetOnePlanetByName : IGetOnePlanetByName
    {
        private readonly IKotorsGateDbContext _context;

        public GetOnePlanetByName(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task<Planet?> GetAsync(string name) {
            return await _context.Planets.FirstOrDefaultAsync(planet => planet.Name == name);
        }
    }
}
