using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Application.Planets.Interfaces
{
    public interface IGetOnePlanetByName
    {
        Task<Planet?> GetAsync(string name);
    }
}
