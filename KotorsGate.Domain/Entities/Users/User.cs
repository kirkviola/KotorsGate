using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Characters;
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
        public virtual ICollection<Character> Characters { get; set; }
        [JsonIgnore]
        public virtual ICollection<Campaign> Campaigns { get; set; }
        [JsonIgnore]
        public virtual ICollection<Role> Roles { get; set; }
        public User() {
            this.Campaigns = new List<Campaign>();
            this.Roles = new List<Role>();
            this.Characters = new List<Character>();
        }

        public User(string username, string password) {
            Username = username;
            Password = password;

            this.Campaigns = new List<Campaign>();
            this.Roles = new List<Role>();
            this.Characters = new List<Character>();
        }
    }
}
