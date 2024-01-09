using KotorsGate.Domain.Entities.Items;
using System.Text.Json.Serialization;

namespace KotorsGate.Domain.Entities.Locations
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CampaignPlanetId { get; set; }

        [JsonIgnore]
        public CampaignPlanet CampaignPlanet { get; set; }
        public virtual ICollection<Battlefield> Battlefields { get; set; }
        public virtual ICollection<LocationMap> LocationMaps { get; set; }
        public virtual ICollection<LocationEnvironment> LocationEnvironments { get; set; }

        public Location() {
            this.CampaignPlanet = new CampaignPlanet();
            this.Battlefields = new List<Battlefield>();
            this.LocationMaps = new List<LocationMap>();
            this.LocationEnvironments = new List<LocationEnvironment>();
        }
    }
}
