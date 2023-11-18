using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Security.Entities;
using KotorsGate.Application.Security.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Security
{
    public class AuthenticateUser : IAuthenticateUser
    {
        private readonly IKotorsGateDbContext _context;

        public AuthenticateUser(IKotorsGateDbContext context) {
            _context = context;
        }

        public async Task<bool> IsUserAsync(Login login) {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == login.username);

            if (user == null) {
                throw new NoUserWithUsernameException(login.username);
            } else {
                return user.Password == login.password;
            }
        }
    }
}
