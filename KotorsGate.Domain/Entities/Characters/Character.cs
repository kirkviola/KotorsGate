using KotorsGate.Domain.Entities.Dialogue;
using KotorsGate.Domain.Entities.Users;

namespace KotorsGate.Domain.Entities.Characters
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public int TotalHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int? TotalForcePoints { get; set; }
        public int? CurrentForcePoints { get; set; }
        public int Alignment { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<CharacterParty> CharacterParties { get; set; }
        public virtual ICollection<CharacterFeat> CharacterFeats { get; set; }
        public virtual ICollection<CharacterPower> CharacterPowers { get; set; }
        public virtual ICollection<UserCampaignCharacter> UserCampaignCharacters { get; set; }
        public virtual ICollection<CharacterDialogue> CharacterDialogues { get; set; }
        public virtual ICollection<CharacterAbility> CharacterAbilities { get; set; }
        public virtual ICollection<CharacterItem>? CharacterItems { get; set; }
        public virtual ICollection<CharacterSkill> CharacterSkills { get; set; }

        public Character() {
            this.Users = new List<User>();
            this.CharacterParties = new List<CharacterParty>();
            this.CharacterFeats = new List<CharacterFeat>();
            this.CharacterPowers = new List<CharacterPower>();
            this.CharacterDialogues = new List<CharacterDialogue>();
            this.CharacterAbilities = new List<CharacterAbility>();
            this.UserCampaignCharacters = new List<UserCampaignCharacter>();
            this.CharacterSkills = new List<CharacterSkill>();
        }

    }
}
