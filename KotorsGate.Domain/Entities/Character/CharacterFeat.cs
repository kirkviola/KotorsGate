using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Character
{
    public class CharacterFeat
    {
        public int Id { get; set; }
        public int FeatId { get; set; }
        public int CharacterId { get; set; }

        public CharacterFeat() { }
    }
}
