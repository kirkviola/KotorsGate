using Microsoft.AspNetCore.Identity;

namespace KotorsGate.Domain.Entities.User
{
    public class User : IdentityUser
    {

        public virtual IEnumerable<UserCharacter> UserCharacters { get; set; }
        public virtual IEnumerable<UserCampaign> UserCampaigns { get; set; }
        public User() { }
    }
}
