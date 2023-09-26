using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.User
{
    public class UserCampaign
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int UserId { get; set; }

        public UserCampaign() { }
    }
}
