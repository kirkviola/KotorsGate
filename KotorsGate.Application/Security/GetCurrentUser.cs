using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Security.Interfaces;
using KotorsGate.Application.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Security
{
    public class GetCurrentUser : IGetCurrentUser
    {
        private readonly IKotorsGateDbContext _context;
        private readonly IGetUserPermissions _getUserPermissions;

        public GetCurrentUser(IKotorsGateDbContext context, IGetUserPermissions getUserPermissions) {
            _context = context;
            _getUserPermissions = getUserPermissions;
        }

        public async Task<UserAuth> GetAsync(int id) {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            var permissions = await _getUserPermissions.GetAsync(id);

            if (user == null && permissions == null) {
                throw new NoUserWithGivenIdException(id);
            } else {
                return new UserAuth(
                id,
                user.Username,
                permissions.Select(p => p.Name)
              );
            } 
        }
    }
}
