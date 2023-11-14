using KotorsGate.Domain.Entities.Campaigns;

namespace KotorsGate.Domain.Entities.Dialogue
{
    public class QuestDialogue
    {
        public int Id { get; set; }
        public int QuestId { get; set; }

        public Quest Quest { get; set; }

        public virtual IEnumerable<DialogueLine> DialogueLines { get; set; }

        public QuestDialogue() {
            this.Quest = new Quest();
        }
    }
}
