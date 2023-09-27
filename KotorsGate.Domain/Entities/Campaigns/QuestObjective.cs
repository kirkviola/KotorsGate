namespace KotorsGate.Domain.Entities.Campaigns
{
    public class QuestObjective
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? NextObjectiveId { get; set; }
        public int? PreviousObjectiveId { get; set; }
        public int QuestId { get; set; }

        public QuestObjective() { }
    }
}
