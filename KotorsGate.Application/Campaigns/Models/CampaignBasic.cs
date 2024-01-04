using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Application.Campaigns.Models
{
    public class CampaignBasic 
    {
        public Campaign Campaign {  get; set; }
        public IEnumerable<Planet> Planets { get; set; }

        public CampaignBasic(Campaign campaign, IEnumerable<Planet> planets) {
            Campaign = campaign;
            Planets = planets;
        }
    }

}
