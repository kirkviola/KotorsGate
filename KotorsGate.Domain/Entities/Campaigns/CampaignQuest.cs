namespace KotorsGate.Domain.Entities.Campaigns
{
    public class CampaignQuest
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int CampaignId { get; set; }

        public Quest Quest { get; set; }
        public Campaign Campaign { get; set; }

        public IEnumerable<CampaignQuestObjective> CampaignQuestObjectives { get; set; }

        public CampaignQuest()
        { 
            Quest = new Quest();
            Campaign = new Campaign();
        }
    }
}
