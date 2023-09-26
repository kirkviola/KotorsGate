using KotorsGate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Ability.Power
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ToolTip { get; set; } = string.Empty;
        public int RequiredLevel { get; set; }
        public Alignment Alignment { get; set; } = Alignment.Universal;
        public int BaseCost { get; set; }

        public Power() { }
    }
}
