using KotorsGate.Domain.Entities.Ability.Feat;

namespace KotorsGate.Domain.Entities.Ability
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<ClassFeat> ClassFeats { get; set; }
        public Class() { }
    }
}
