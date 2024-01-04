using KotorsGate.Domain.Entities.Locations;
using KotorsGate.Domain.Entities.Users;
using System.Text.Json.Serialization;

namespace KotorsGate.Domain.Entities.Campaigns
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual IEnumerable<User> Users { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Quest> Quests { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Planet> Planets { get; set; }

        public Campaign() {
            Planets = new List<Planet>();
            Quests = new List<Quest>();
            Users = new List<User>();
        }
    }
}
