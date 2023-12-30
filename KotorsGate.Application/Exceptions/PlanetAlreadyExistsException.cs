namespace KotorsGate.Application.Exceptions
{
    public class PlanetAlreadyExistsException : Exception
    {
        public PlanetAlreadyExistsException(string planet) : base($"Planet named {planet} already exists.") { }
    }
}
