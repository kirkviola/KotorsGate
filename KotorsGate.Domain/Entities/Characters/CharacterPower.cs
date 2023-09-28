using KotorsGate.Domain.Entities.Ability.Power;

namespace KotorsGate.Domain.Entities.Characters
{
    public class CharacterPower
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int PowerId { get; set; }

        public Character Character { get; set; }
        public Power Power { get; set; }

        public CharacterPower() 
        {
            Character = new Character();
            Power = new Power();
        }
    }
}
