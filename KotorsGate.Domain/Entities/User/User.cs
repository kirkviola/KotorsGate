using Microsoft.AspNetCore.Identity;

namespace KotorsGate.Domain.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; }

        public virtual IEnumerable<UserCharacter> UserCharacters { get; set; }
        public virtual IEnumerable<UserCampaign> UserCampaigns { get; set; }
        public User() { }
    }
}
