namespace KotorsGate.Domain.Entities.Permissions
{
    public class Permission
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<Role> Roles { get; set; }

        public Permission() { 
            this.Roles = new List<Role>();
        }
    }
}
