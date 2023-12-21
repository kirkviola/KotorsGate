using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Planets.Interfaces;
using KotorsGate.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Planets
{
    public class GetOnePlanetById : IGetOnePlanetById
    {
        private readonly IKotorsGateDbContext _context;

        public GetOnePlanetById(IKotorsGateDbContext context) {
            _context = context;
        }

        public Task<Planet?> GetAsync(int id) {
            return _context.Planets.FirstOrDefaultAsync(x => x.Id == id) ?? throw new PlanetNotFoundException(id);
        }
    }
}
