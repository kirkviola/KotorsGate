using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.User
{
    public class UserCharacter
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CharacterId { get; set; }

        public User User { get; set; }
        public Character Character { get; set; }

        public UserCharacter() { }
    }
}
