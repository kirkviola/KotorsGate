using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Ability.Feat
{
    public class ClassFeat
    {
        public int Id { get; set; }
        public int FeatId { get; set; }
        public int ClassId { get; set; }

        public ClassFeat() { }
    }
}
