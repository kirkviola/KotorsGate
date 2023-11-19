using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Permissions
{
    public class Role
    {
        public int Id { get; set; }
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
