using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Security.Entities;
using KotorsGate.Application.Security.Interfaces;
using KotorsGate.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Security
{
    public class AuthenticateUser : IAuthenticateUser
    {
        private readonly IKotorsGateDbContext _context;

        public AuthenticateUser(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task<User> IsValidUserAsync(Login login) {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == login.Username);

            if (user == null) {
                throw new NoUserWithUsernameException(login.Username);
            } else {
                return user.Password == login.Password
                    ? user : throw new InvalidLoginException(login.Username);
            }
        }
    }
}
