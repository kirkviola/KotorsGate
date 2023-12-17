namespace KotorsGate.Domain.Entities.Permissions
{
    public class Permission
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<RolePermission> RolePermissions { get; set; }

        public Permission() { 
            this.RolePermissions = new List<RolePermission>();
        }
    }
}
