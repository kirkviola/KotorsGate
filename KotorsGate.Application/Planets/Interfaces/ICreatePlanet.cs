using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Application.Planets.Interfaces
{
    public interface ICreatePlanet
    {
        public Task CreateAsync(Planet planet);
    }
}
