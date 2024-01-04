using KotorsGate.Domain.Entities.Campaigns;
using System.Text.Json.Serialization;

namespace KotorsGate.Domain.Entities.Locations
{
    public class CampaignPlanet
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public int CampaignId { get; set; }

        [JsonIgnore]
        public Campaign? Campaign { get; set; }
        public Planet? Planet { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Location> Locations { get; set; }

        public CampaignPlanet() {
            this.Locations = new List<Location>();
        }

        public CampaignPlanet(int planetId, int campaignId) {
            this.PlanetId = planetId;
            this.CampaignId = campaignId;

            this.Locations = new List<Location>();
        }
    }
}
