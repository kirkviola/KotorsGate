using KotorsGate.Domain.Entities.Abilities.Feat;
using KotorsGate.Domain.Entities.Abilities.Power;

namespace KotorsGate.Domain.Entities.Abilities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<ClassFeat> ClassFeats { get; set; }
        public virtual IEnumerable<ClassPower> ClassPowers { get; set; }
        public Class() { }
    }
}
