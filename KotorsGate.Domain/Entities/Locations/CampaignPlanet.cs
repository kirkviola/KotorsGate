using KotorsGate.Domain.Entities.Campaigns;

namespace KotorsGate.Domain.Entities.Locations
{
    public class CampaignPlanet
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public int CampaignId { get; set; }

        public Campaign Campaign { get; set; }
        public Planet Planet { get; set; }

        public virtual IEnumerable<Location> Locations { get; set; }

        public CampaignPlanet() { 
            this.Campaign = new Campaign();
            this.Planet = new Planet();
        }
    }
}
