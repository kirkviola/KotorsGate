using KotorsGate.Domain.Entities.Abilities.Ability;

namespace KotorsGate.Domain.Entities.Characters
{
    public class CharacterAbility
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int AbilityId { get; set; }
        public int CharacterId { get; set; }

        public Ability Ability { get; set; }
        public Character Character { get; set; }

        public CharacterAbility() {
            this.Ability = new Ability();
            this.Character = new Character();
        }
    }
}
