﻿namespace KotorsGate.Domain.Entities.Dialogue
{
    public class DialogueLine
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int DialogueId { get; set; } // Can be for either type of dialogue

        public DialogueLine() { }
    }
}
