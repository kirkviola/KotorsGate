namespace KotorsGate.Domain.Entities.Permissions
{
    public class Role
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
        public virtual IEnumerable<RolePermission> RolePermissions { get; set; }

        public Role() {
            this.UserRoles = new List<UserRole>();
            this.RolePermissions = new List<RolePermission>();
        }
    }
}
