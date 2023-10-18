using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Dialogue
{
    public class CharacterDialogue
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }

        public Character Character { get; set; }

        public CharacterDialogue() { 
            this.Character = new Character();
        }
    }
}
