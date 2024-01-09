using KotorsGate.Domain.Entities.Campaigns;
using System.Text.Json.Serialization;

namespace KotorsGate.Domain.Entities.Locations
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Campaign> Campaigns { get; set; }

        public Planet() { 
            this.Campaigns = new List<Campaign>();
        }
    }
}
