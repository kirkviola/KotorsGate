namespace KotorsGate.Domain.Entities.User
{
    public class UserCampaignCharacter
    {
        public int Id { get; set; }
        public int CampaignId { get; set;}
        public int CharacterId { get; set; }

        public UserCampaignCharacter() { }
    }
}
