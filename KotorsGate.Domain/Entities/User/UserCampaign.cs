﻿using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.User
{
    public class UserCampaign
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Campaign Campaign { get; set; }
        public virtual IEnumerable<Party> Parties { get; set; }

        public UserCampaign() {}
    }
}
