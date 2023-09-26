using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Ability.Power
{
    public class ClassPower
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int PowerId { get; set; }

        public ClassPower() { }
    }
}
