using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Application.Planets.Interfaces
{
    public interface IGetOnePlanetById
    {
        public Task<Planet?> GetAsync(int id);
    }
}
