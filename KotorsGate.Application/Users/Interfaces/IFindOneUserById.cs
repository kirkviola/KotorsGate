using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Application.Users.Interfaces
{
    public interface IFindOneUserById
    {
        Task<User?> GetAsync(int id);
    }
}
