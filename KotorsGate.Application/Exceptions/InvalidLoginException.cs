namespace KotorsGate.Application.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string username) : base($"Invalid password given for user: {username}") { }
    }
}
