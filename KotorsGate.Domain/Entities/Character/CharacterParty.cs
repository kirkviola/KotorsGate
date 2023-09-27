namespace KotorsGate.Domain.Entities.Character
{
    public class CharacterParty
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int CharacterId { get; set; }

        public CharacterParty() { }
    }
}
