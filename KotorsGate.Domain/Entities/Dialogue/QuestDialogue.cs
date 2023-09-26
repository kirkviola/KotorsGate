using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Dialogue
{
    public class QuestDialogue
    {
        public int Id { get; set; }
        public int QuestId { get; set; }

        public QuestDialogue() { }
    }
}
