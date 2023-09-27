namespace KotorsGate.Domain.Entities.Campaign
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Campaign() { }
    }
}
