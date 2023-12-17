namespace KotorsGate.Application.Security.Roles
{
    // Application side definition for roles
    public sealed class RoleDefinition
    {

        public static readonly RoleDefinition CampaignCreator = new RoleDefinition("Campaign Creator");
        public static readonly RoleDefinition Admin = new RoleDefinition("Admin");
        public static readonly RoleDefinition Player = new RoleDefinition("Player");

        private RoleDefinition(string role) { 
            Role = role;
        }

        public string Role { get; private set; }
    }
}
