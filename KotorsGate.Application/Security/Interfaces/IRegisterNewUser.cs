using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Application.Security.Interfaces
{
    public interface IRegisterNewUser
    {
        Task<User> RegisterAsync(User user);
    }
}
