namespace KotorsGate.Application.Exceptions
{
    public class NoUserWithUsernameException : Exception
    {
        public NoUserWithUsernameException(string username): base($"No user found with given username: {username}") { }
    }
}
