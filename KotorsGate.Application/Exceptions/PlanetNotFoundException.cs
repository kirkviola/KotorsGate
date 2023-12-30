namespace KotorsGate.Application.Exceptions
{
    public class PlanetNotFoundException : Exception
    {
        public PlanetNotFoundException(int id): base($"No planet found with given Id: {id}") { }
    }
}
