using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Users
{
    public class UserCampaign
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Campaign Campaign { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<UserCampaignCharacter> UserCampaignCharacters { get; set; }

        public UserCampaign() {}
    }
}
