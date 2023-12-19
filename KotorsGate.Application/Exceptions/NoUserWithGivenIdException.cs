namespace KotorsGate.Application.Exceptions
{
    public class NoUserWithGivenIdException : Exception
    {
        public NoUserWithGivenIdException(int id) : base($"No user information found with given id: {id}") { }
    }
}
