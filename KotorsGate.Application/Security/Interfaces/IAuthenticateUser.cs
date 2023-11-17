using KotorsGate.Application.Security.Entities;

namespace KotorsGate.Application.Security.Interfaces
{
    public interface IAuthenticateUser
    {
        Task<bool> IsUserAsync(Login login);
    }
}
