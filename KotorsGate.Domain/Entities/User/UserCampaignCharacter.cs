using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.User
{
    public class UserCampaignCharacter
    {
        public int Id { get; set; }
        public int UserCampaignId { get; set;}
        public int CharacterId { get; set; }

        public UserCampaign UserCampaign { get; set; }
        public Character Character { get; set; }

        public UserCampaignCharacter()
        { 
            UserCampaign = new UserCampaign();
            Character = new Character();
        }
    }
}
