using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Planets.Interfaces;
using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Application.Planets
{
    public class CreatePlanet : ICreatePlanet
    {
        private readonly IKotorsGateDbContext _context;

        public CreatePlanet(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task CreateAsync(Planet planet) {
            await _context.Planets.AddAsync(planet);

            await _context.SaveChangesAsync();
        }
    }
}
