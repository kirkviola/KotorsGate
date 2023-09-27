namespace KotorsGate.Domain.Entities.Campaigns
{
    public class CampaignQuest
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int CampaignId { get; set; }

        public CampaignQuest() { }
    }
}
