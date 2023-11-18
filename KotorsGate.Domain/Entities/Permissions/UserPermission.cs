using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Domain.Entities.Permissions
{
    public class UserPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public User User { get; set; }
        public Permission Permission { get; set; }

        public UserPermission() {
            this.User = new User();
            this.Permission = new Permission();
        }
    }
}
