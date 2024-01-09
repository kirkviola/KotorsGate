using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Abilities.Ability
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<CharacterAbility> CharacterAbilities { get; set; }

        public Ability() {
            this.CharacterAbilities = new List<CharacterAbility>();
        }
    }
}
