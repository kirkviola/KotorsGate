using KotorsGate.Application.Security.Models;

namespace KotorsGate.Application.Security.Interfaces
{
    public interface IGetCurrentUser
    {
        public Task<UserAuth> GetAsync(int id);
    }
}
