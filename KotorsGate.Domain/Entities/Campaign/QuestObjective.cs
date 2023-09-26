using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Campaign
{
    public class QuestObjective
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? NextObjectiveId { get; set; }
        public int? PreviousObjectiveId { get; set; }
        public int QuestId { get; set; }

        public QuestObjective() { }
    }
}
