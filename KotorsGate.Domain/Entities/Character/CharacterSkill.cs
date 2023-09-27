namespace KotorsGate.Domain.Entities.Character
{
    public class CharacterSkill
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int SkillId { get; set; }
        public int Level { get; set; }

        public CharacterSkill() { }
    }
}
