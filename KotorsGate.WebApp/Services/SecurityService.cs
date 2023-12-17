using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Security.Interfaces;
using KotorsGate.Domain.Entities.Permissions;

namespace KotorsGate.WebApp.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IGetUserPermissions _getUserPermissions;
        public SecurityService(IGetUserPermissions getUserPermissions) {
            _getUserPermissions = getUserPermissions;
        }

        public int? UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public async Task<bool> HasPermissionAsync(string permission) {
            if (this.UserId != null) {
                var permissions = await _getUserPermissions.GetAsync(this.UserId.Value);

                return permissions.Select(p => p.Name).Contains(permission);
            } 

            return false;
        }

        public void SetCurrentUser(int id) {
            throw new NotImplementedException();
        }
    }
}
