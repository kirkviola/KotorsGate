using KotorsGate.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KotorsGate.WebApp.Services.AuthRequirements.AuthHandlers
{
    public class PlanetCreateRequirementHandler : AuthorizationHandler<PlanetCreateRequirement>
    {
        private readonly ISecurityService _securityService;

        public PlanetCreateRequirementHandler(ISecurityService securityService) {
            _securityService = securityService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PlanetCreateRequirement requirement) {
            if (await _securityService.HasPermissionAsync(SecurityRule.PlanetCreate)) {
                context.Succeed(requirement);
            } else {
                context.Fail();
            }
        }
    }
}
