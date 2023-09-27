namespace KotorsGate.Domain.Entities.Campaign
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsMainQuest { get; set; } = false;

        public Quest() { }
    }
}
