using KotorsGate.Domain.Entities.Dialogue;

namespace KotorsGate.Domain.Entities.Campaigns
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsMainQuest { get; set; } = false;

        public virtual ICollection<QuestObjective> QuestObjectives { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<QuestDialogue> QuestDialogues { get; set; }

        public Quest() {
            this.Campaigns = new List<Campaign>();
        }
    }
}
