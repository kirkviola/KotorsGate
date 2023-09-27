namespace KotorsGate.Domain.Entities.Character
{
    public class CharacterAttribute
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int AttributeId { get; set; }
        public int CharacterId { get; set; }

        public CharacterAttribute() { }
    }
}
