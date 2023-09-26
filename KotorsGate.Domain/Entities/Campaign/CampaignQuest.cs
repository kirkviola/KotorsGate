using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Campaign
{
    public class CampaignQuest
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int CampaignId { get; set; }

        public CampaignQuest() { }
    }
}
