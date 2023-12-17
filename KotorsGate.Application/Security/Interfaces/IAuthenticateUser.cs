using KotorsGate.Application.Security.Entities;
using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Application.Security.Interfaces
{
    public interface IAuthenticateUser
    {
        Task<User> IsValidUserAsync(Login login);
    }
}
