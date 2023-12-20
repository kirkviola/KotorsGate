namespace KotorsGate.WebApp.Services
{
    public sealed class SecurityRule
    {

        public static readonly SecurityRule CampaignCreator = new SecurityRule("CAMPAIGN_CREATOR");
        public static readonly SecurityRule PlanetCreate = new SecurityRule("PLANET_CREATE");

        public SecurityRule(string policy) {
            this.Policy = policy;
        }
        public string Policy { get; private set; }
    }
}
