using KotorsGate.Domain.Entities.Dialogue;
using KotorsGate.Domain.Entities.User;
using System.Security.Cryptography.X509Certificates;

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

        public virtual IEnumerable<UserCharacter> UserCharacters { get; set; }
        public virtual IEnumerable<CharacterParty> CharacterParties { get; set; }
        public virtual IEnumerable<CharacterFeat> CharacterFeats { get; set; }
        public virtual IEnumerable<CharacterPower> CharacterPowers { get; set; }
        public virtual IEnumerable<UserCampaignCharacter> UserCampaignCharacters { get; set; }
        public virtual IEnumerable<CharacterDialogue> CharacterDialogues { get; set; }
        public virtual IEnumerable<CharacterAbility> CharacterAbilities { get; set; }
        public virtual IEnumerable<CharacterItem>? CharacterItems { get; set; }
        public virtual IEnumerable<CharacterSkill> CharacterSkills { get; set; }

        public Character() {
            this.UserCharacters = new List<UserCharacter>();
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
