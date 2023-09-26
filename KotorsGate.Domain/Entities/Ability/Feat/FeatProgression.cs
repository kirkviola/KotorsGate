using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Ability.Feat
{
    public class FeatProgression
    {
        public int Id { get; set; }
        public int RequiredFeatId { get; set; }

        public FeatProgression() { }
    }
}
