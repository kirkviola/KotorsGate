namespace KotorsGate.Domain.Entities.Permissions
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<UserPermission> UserPermissions { get; set; }

        public Permission() { }
    }
}
