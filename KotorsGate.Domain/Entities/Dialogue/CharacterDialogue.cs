using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Dialogue
{
    public class CharacterDialogue
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }

        public CharacterDialogue() { }
    }
}
