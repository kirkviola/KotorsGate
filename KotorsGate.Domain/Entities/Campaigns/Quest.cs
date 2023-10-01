namespace KotorsGate.Domain.Entities.Campaigns
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsMainQuest { get; set; } = false;

        public virtual IEnumerable<QuestObjective> QuestObjectives { get; set; }
        public virtual IEnumerable<CampaignQuest> CampaignQuests { get; set; }

        public Quest() { }
    }
}
