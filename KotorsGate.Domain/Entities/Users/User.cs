using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Permissions;
using System.Text.Json.Serialization;

namespace KotorsGate.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual IEnumerable<UserCharacter>? UserCharacters { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Campaign>? Campaigns { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Role> Roles { get; set; }
        public User() { }

        public User(string username, string password) {
            Username = username;
            Password = password;

            this.Campaigns = new List<Campaign>();
            this.Roles = new List<Role>();
            this.UserCharacters = new List<UserCharacter>();
        }
    }
}
