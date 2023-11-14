using KotorsGate.Domain.Entities.Abilities.Skill;

namespace KotorsGate.Domain.Entities.Characters
{
    public class CharacterSkill
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
        public int Level { get; set; }

        public Character Character { get; set; }
        public Skill Skill { get; set; }

        public CharacterSkill() {
            this.Character = new Character();
            this.Skill = new Skill();
        }
    }
}
