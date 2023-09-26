using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Location
{
    public class CampaignPlanet
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public int CampaignId { get; set; }

        public CampaignPlanet() { }
    }
}
