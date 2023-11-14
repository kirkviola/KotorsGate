namespace KotorsGate.Domain.Entities.Location
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CampaignPlanetId { get; set; }

        public CampaignPlanet CampaignPlanet { get; set; }
        public virtual IEnumerable<Battlefield> Battlefields { get; set; }
        public virtual IEnumerable<LocationMap> LocationMaps { get; set; }

        public Location() {
            this.CampaignPlanet = new CampaignPlanet();
            this.Battlefields = new List<Battlefield>();
            this.LocationMaps = new List<LocationMap>();
        }
    }
}
