using KotorsGate.Domain.Entities.Ability.Feat;
using KotorsGate.Domain.Entities.Ability.Power;

namespace KotorsGate.Domain.Entities.Ability
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
