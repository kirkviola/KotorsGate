namespace KotorsGate.Domain.Entities.Dialogue
{
    public class DialogueLine
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int DialogueId { get; set; } 

        public QuestDialogue QuestDialogue { get; set; }
        public virtual IEnumerable<Response>? Responses { get; set; }


        public DialogueLine() { 
            this.QuestDialogue = new QuestDialogue();
        }
    }
}
