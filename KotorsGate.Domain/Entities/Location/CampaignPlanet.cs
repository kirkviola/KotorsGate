namespace KotorsGate.Domain.Entities.Location
{
    public class CampaignPlanet
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public int CampaignId { get; set; }

        public CampaignPlanet() { }
    }
}
