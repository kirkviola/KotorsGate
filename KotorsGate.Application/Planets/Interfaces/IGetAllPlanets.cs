using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Application.Planets.Interfaces
{
    public interface IGetAllPlanets
    {
        public Task<IEnumerable<Planet>> GetAsync();
    }
}
