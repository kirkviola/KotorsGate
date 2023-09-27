namespace KotorsGate.Domain.Entities.Location
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CampaignPlanet { get; set; }

        public Location() { }
    }
}
