namespace KotorsGate.Domain.Entities.Character
{
    public class CharacterItem
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int ItemId { get; set; }

        public CharacterItem() { }
    }
}
