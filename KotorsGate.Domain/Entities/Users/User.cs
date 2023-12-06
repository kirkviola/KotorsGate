using KotorsGate.Domain.Entities.Permissions;
using System.Text.Json.Serialization;

namespace KotorsGate.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<UserCharacter>? UserCharacters { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<UserCampaign>? UserCampaigns { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<UserRole>? UserRoles { get; set; }
        public User() { }

        public User(string username, string password) {
            Username = username;
            Password = password;

            this.UserCampaigns = new List<UserCampaign>();
            this.UserRoles = new List<UserRole>();
            this.UserCharacters = new List<UserCharacter>();
        }
    }
}
