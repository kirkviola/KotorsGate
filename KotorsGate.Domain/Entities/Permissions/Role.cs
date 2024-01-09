using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Domain.Entities.Permissions
{
    public class Role
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }

        public Role() {
            this.Users = new List<User>();
            this.Permissions = new List<Permission>();
        }
    }
}
