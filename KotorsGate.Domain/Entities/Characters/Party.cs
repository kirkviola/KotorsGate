using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Domain.Entities.Characters
{
    public class Party
    {
        public int Id { get; set; }
        public int UserCampaignId { get; set; }

        public UserCampaign UserCampaign { get; set; }
        public ICollection<CharacterParty> CharacterParties { get; set; }

        public Party() 
        {
            UserCampaign = new UserCampaign();
        }
    }
}
