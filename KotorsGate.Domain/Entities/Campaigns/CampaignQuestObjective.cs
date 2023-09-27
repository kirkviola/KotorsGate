namespace KotorsGate.Domain.Entities.Campaigns
{
    public class CampaignQuestObjective
    {
        public int Id { get; set; }
        public int QuestObjectiveId { get; set; }
        public int CampaignQuestId { get; set; }
        public bool IsComplete { get; set; } = false;
        
        public CampaignQuestObjective() { }
    }
}
