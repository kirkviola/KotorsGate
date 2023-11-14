using KotorsGate.Domain.Constants;
using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Abilities.Power
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ToolTip { get; set; } = string.Empty;
        public int RequiredLevel { get; set; }
        public Alignment Alignment { get; set; } = Alignment.Universal;
        public int BaseCost { get; set; }

        public virtual IEnumerable<ClassPower> ClassPowers { get; set; }
        public virtual IEnumerable<CharacterPower> CharacterPowers { get; set; }
        public virtual IEnumerable<PowerProgression> PowerProgressions { get; set; }

        public Power() { }
    }
}
