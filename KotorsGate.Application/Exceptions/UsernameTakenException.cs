namespace KotorsGate.Application.Exceptions
{
    public class UsernameTakenException : Exception
    {
        public UsernameTakenException(string username) : base($"Username taken: {username}") { }
    }
}
