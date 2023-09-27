﻿using KotorsGate.Domain.Entities.User;

namespace KotorsGate.Domain.Entities.Campaigns
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<UserCampaign> UserCampaigns { get; set; }

        public Campaign() { }
    }
}