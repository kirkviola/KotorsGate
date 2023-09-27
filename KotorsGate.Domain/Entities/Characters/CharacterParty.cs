namespace KotorsGate.Domain.Entities.Characters
{
    public class CharacterParty
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int CharacterId { get; set; }

        public Character Character { get; set; }
        public Party Party { get; set; }

        public CharacterParty() { }
    }
}
