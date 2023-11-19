using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Users.Interfaces;
using KotorsGate.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Users
{
    public class FindOneUserByUsername : IFindOneUserByUsername
    {
        private readonly IKotorsGateDbContext _context;
        public FindOneUserByUsername(IKotorsGateDbContext context) {
            _context = context;
        }
        public async Task<User?> GetAsync(string username) {
            return await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
        }
    }
}
