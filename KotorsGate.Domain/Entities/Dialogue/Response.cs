using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Dialogue
{
    public class Response
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int DialogueLineId { get; set; }

        public Response() { }
    }
}
