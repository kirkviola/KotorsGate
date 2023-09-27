﻿namespace KotorsGate.Domain.Entities.Dialogue
{
    public class Response
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int DialogueLineId { get; set; }

        public Response() { }
    }
}
