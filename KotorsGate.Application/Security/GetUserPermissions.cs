using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Security.Interfaces;
using KotorsGate.Domain.Entities.Permissions;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Security
{
    public class GetUserPermissions : IGetUserPermissions
    {
        private readonly IKotorsGateDbContext _context;
        public GetUserPermissions(IKotorsGateDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Permission>> GetAsync(int userId) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) {
                return new List<Permission>();
            }

            return await (from p in _context.Permissions
                                     join rolePermission in _context.RolePermissions on p.Name equals rolePermission.PermissionId
                                     join userRole in _context.UserRoles on rolePermission.RoleId equals userRole.RoleId
                                     where userRole.UserId == userId 
                                     select p)
                                     .ToListAsync() ?? new List<Permission>();
        }
    }
}
