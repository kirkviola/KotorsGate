namespace KotorsGate.Domain.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public virtual IEnumerable<UserCharacter> UserCharacters { get; set; }
        public virtual IEnumerable<UserCampaign> UserCampaigns { get; set; }
        public User() { }
    }
}
