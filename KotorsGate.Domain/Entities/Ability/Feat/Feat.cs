using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Ability.Feat
{
    public class Feat
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ToolTip { get; set; } = string.Empty;
        public int RequiredLevel { get; set; }

        public virtual IEnumerable<ClassFeat> ClassFeats { get; set; }
        public virtual IEnumerable<CharacterFeat> CharacterFeats { get; set; }

        public Feat() { }
    }
}
