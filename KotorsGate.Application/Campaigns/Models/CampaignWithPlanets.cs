using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Application.Campaigns.Models
{
    public record CampaignWithPlanets(
            Campaign Campaign,
            IEnumerable<Planet> Planets
        );
}
