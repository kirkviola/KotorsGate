using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Abilities.Feat
{
    public class Feat
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ToolTip { get; set; } = string.Empty;
        public int RequiredLevel { get; set; }

        public virtual IEnumerable<ClassFeat> ClassFeats { get; set; }
        public virtual IEnumerable<CharacterFeat> CharacterFeats { get; set; }
        public virtual IEnumerable<FeatProgression> FeatProgressions { get; set; }

        public Feat() { }
    }
}
