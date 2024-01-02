using KotorsGate.Domain.Entities.Locations;
using KotorsGate.Domain.Entities.Users;
using System.Text.Json.Serialization;

namespace KotorsGate.Domain.Entities.Campaigns
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual IEnumerable<UserCampaign>? UserCampaigns { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<CampaignQuest>? CampaignQuests { get; set; }
        public virtual List<CampaignPlanet>? CampaignPlanets { get; set; }

        public Campaign() {}
    }
}
