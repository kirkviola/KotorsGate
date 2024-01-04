using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Users
{
    public class UserCharacter
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CharacterId { get; set; }

        public User User { get; set; }
        public Character Character { get; set; }

        public UserCharacter() {
            this.User = new User();
            this.Character = new Character();
        
        }
    }
}
