

using KotorsGate.Domain.Entities.Permissions;

namespace KotorsGate.Application.Security.Interfaces
{
    public interface IGetUserPermissions
    {
        public Task<IEnumerable<Permission>> GetAsync(int userId);
    }
}
