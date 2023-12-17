using KotorsGate.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KotorsGate.WebApp.Services.AuthRequirements.AuthHandlers
{
    public class CampaignCreatorRequirementHandler : AuthorizationHandler<CampaignCreatorRequirement>
    {
        private readonly ISecurityService _securityService;

        public CampaignCreatorRequirementHandler(ISecurityService securityService) {
            _securityService = securityService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CampaignCreatorRequirement requirement) {
            if (await _securityService.HasPermissionAsync(SecurityRule.CampaignCreator.Policy)) {
                context.Succeed(requirement);
            } else {
                context.Fail();
            }
        }
    }
}
