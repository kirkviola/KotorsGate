namespace KotorsGate.Domain.Entities.Locations
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<CampaignPlanet> CampaignPlanets { get; set; }

        public Planet() { }
    }
}
