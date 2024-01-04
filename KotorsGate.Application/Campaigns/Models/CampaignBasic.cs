using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Application.Campaigns.Models
{
    public record CampaignBasic(
            Campaign Campaign,
            IEnumerable<Planet> Planets
        );
}
