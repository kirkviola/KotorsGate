using KotorsGate.Domain.Entities.User;

namespace KotorsGate.Domain.Entities.Characters
{
    public class Party
    {
        public int Id { get; set; }
        public int UserCampaignId { get; set; }

        public UserCampaign UserCampaign { get; set; }
        public IEnumerable<CharacterParty> CharacterParties { get; set; }

        public Party() 
        {
            UserCampaign = new UserCampaign();
        }
    }
}
