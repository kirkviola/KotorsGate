using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Security.Interfaces;
using KotorsGate.Application.Security.Roles;
using KotorsGate.Application.Users.Interfaces;
using KotorsGate.Domain.Entities.Permissions;
using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Application.Security
{
    public class RegisterNewUser : IRegisterNewUser
    {
        private readonly IKotorsGateDbContext _context;
        private readonly IFindOneUserByUsername _findOneUserByUsername;

        public RegisterNewUser(IKotorsGateDbContext context,
                               IFindOneUserByUsername findByUsername
            ) {
            _context = context;
            _findOneUserByUsername = findByUsername;
        }

        public async Task<User> RegisterAsync(User user) {
            var existingUser = await _findOneUserByUsername.GetAsync(user.Username);

            if (existingUser != null) {
                throw new UsernameTakenException(user.Username);
            }

            _context.Users.Add(user);

            // Default to give new users the player role and therefore permissions
            _context.UserRoles.Add(new UserRole(user.Id, RoleDefinition.Player.Role));
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
