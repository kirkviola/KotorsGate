namespace KotorsGate.Domain.Entities.Campaigns
{
    public class QuestObjective
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SequencePosition { get; set; }
        public int QuestId { get; set; }

        public Quest Quest { get; set; }

        public virtual IEnumerable<CampaignQuestObjective> CampaignQuestObjectives { get; set; }

        public QuestObjective()
        {
            Quest = new Quest();   
        }
    }
}
