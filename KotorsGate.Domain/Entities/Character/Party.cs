using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Character
{
    public class Party
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }

        public Party() { }
    }
}
