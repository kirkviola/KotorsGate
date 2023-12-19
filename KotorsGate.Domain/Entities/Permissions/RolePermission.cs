namespace KotorsGate.Domain.Entities.Permissions
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string PermissionId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }

        public RolePermission() {
            this.Role = new Role();
            this.Permission = new Permission();
        }
    }
}
