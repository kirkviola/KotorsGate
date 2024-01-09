using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Abilities.Skill
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<CharacterSkill> CharacterSkills { get; set; }

        public Skill() {
            this.CharacterSkills = new List<CharacterSkill>();
        }
    }
}
