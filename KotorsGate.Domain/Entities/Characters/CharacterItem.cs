using KotorsGate.Domain.Entities.Items;

namespace KotorsGate.Domain.Entities.Characters
{
    public class CharacterItem
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int ItemId { get; set; }

        public Character Character { get; set; }
        public Item Item { get; set; }

        public CharacterItem() {
            this.Character = new Character();
            this.Item = new Item();
        }
    }
}
