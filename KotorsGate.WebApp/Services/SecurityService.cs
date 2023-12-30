using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Security.Interfaces;

namespace KotorsGate.WebApp.Services
{
    public class SecurityService : ISecurityService
    {
  
        private readonly IServiceScopeFactory _scopeFactory;
        public SecurityService( IServiceScopeFactory scopeFactory) {
            _scopeFactory = scopeFactory;
        }

        public int? UserId { get; set; }


        public async Task<bool> HasPermissionAsync(string permission) {

            using (var scope = _scopeFactory.CreateScope()) {
                var getUserPermissions = scope.ServiceProvider.GetRequiredService<IGetUserPermissions>();
                if (this.UserId != null) {
                    var permissions = await getUserPermissions.GetAsync(this.UserId.Value);

                    return permissions.Select(p => p.Name).Contains(permission);
                } 
            }

            return false;
        }

        public void SetCurrentUser(int id) {
            this.UserId = id;
        }
    }
}
