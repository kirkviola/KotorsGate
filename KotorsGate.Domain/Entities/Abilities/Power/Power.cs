using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Abilities.Power
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ToolTip { get; set; } = string.Empty;
        public int RequiredLevel { get; set; }
        public string Alignment { get; set; }
        public int BaseCost { get; set; }

        public virtual ICollection<ClassPower> ClassPowers { get; set; }
        public virtual ICollection<CharacterPower> CharacterPowers { get; set; }
        public virtual ICollection<PowerProgression> PowerProgressions { get; set; }

        public Power() {
        
        }
    }
}
