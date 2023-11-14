using KotorsGate.Domain.Entities.Abilities.Feat;

namespace KotorsGate.Domain.Entities.Characters
{
    public class CharacterFeat
    {
        public int Id { get; set; }
        public int FeatId { get; set; }
        public int CharacterId { get; set; }

        public Feat Feat { get; set; }
        public Character Character { get; set; }

        public CharacterFeat() 
        { 
            Feat = new Feat();
            Character = new Character();
        }
    }
}
