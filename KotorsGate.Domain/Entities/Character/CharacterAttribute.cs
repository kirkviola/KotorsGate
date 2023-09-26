using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Character
{
    public class CharacterAttribute
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int AttributeId { get; set; }
        public int CharacterId { get; set; }

        public CharacterAttribute() { }
    }
}
