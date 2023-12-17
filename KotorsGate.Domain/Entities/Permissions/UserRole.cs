using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Domain.Entities.Permissions
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }

        public UserRole() {
            this.User = new User();
            this.Role = new Role();
        }
    }
}
