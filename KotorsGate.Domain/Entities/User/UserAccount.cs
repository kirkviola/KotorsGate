namespace KotorsGate.Domain.Entities.User
{
    public class UserAccount
    {
        public int UserId { get; set; }
        public string Password { get; set; } = string.Empty;

        public UserAccount() { }
    }
}
