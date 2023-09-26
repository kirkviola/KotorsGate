using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Campaign
{
    public class CampaignQuestObjective
    {
        public int Id { get; set; }
        public int QuestObjectiveId { get; set; }
        public int CampaignQuestId { get; set; }
        public bool IsComplete { get; set; } = false;
        
        public CampaignQuestObjective() { }
    }
}
