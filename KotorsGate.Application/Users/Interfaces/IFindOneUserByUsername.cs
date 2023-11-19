using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Application.Users.Interfaces
{
    public interface IFindOneUserByUsername
    {
        Task<User?> GetAsync(string username);
    }
}
