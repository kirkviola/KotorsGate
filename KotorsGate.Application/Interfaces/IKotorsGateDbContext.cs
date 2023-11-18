using KotorsGate.Domain.Entities.Abilities;
using KotorsGate.Domain.Entities.Abilities.Ability;
using KotorsGate.Domain.Entities.Abilities.Feat;
using KotorsGate.Domain.Entities.Abilities.Power;
using KotorsGate.Domain.Entities.Abilities.Skill;
using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Characters;
using KotorsGate.Domain.Entities.Dialogue;
using KotorsGate.Domain.Entities.Items;
using KotorsGate.Domain.Entities.Location;
using KotorsGate.Domain.Entities.Permissions;
using KotorsGate.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Interfaces
{
    public interface IKotorsGateDbContext
    {
        DbSet<Ability> Abilities { get; }
        DbSet<Feat> Feats { get; }
        DbSet<FeatProgression> FeaturesProgressions { get; }
        DbSet<ClassFeat> ClassFeats { get; }
        DbSet<Power> Powers { get; }
        DbSet<ClassPower> ClassPowers { get; }
        DbSet<PowerProgression> PowerProgressions { get; }
        DbSet<Skill> Skills { get; }
        DbSet<Class> Classes { get; }
        DbSet<Campaign> Campaigns { get; }
        DbSet<CampaignQuest> CampaignQuests { get; }
        DbSet<CampaignQuestObjective> CampaignQuestObjectives { get; }
        DbSet<Quest> Quests { get; }
        DbSet<QuestObjective> QuestsObjectives { get; }
        DbSet<Character> Characters { get; }
        DbSet<CharacterAbility> CharacterAbilities { get; }
        DbSet<CharacterFeat> CharacterFeats { get; }
        DbSet<CharacterItem> CharacterItems { get; }
        DbSet<CharacterParty> CharacterParties { get; }
        DbSet<CharacterPower> CharacterPowers { get; }
        DbSet<CharacterSkill> CharacterSkills { get; }
        DbSet<Party> Parties { get; }
        DbSet<CharacterDialogue> CharacterDialogues { get; }
        DbSet<DialogueLine> DialogueLines { get; }
        DbSet<QuestDialogue> QuestDialogues { get; }
        DbSet<Response> Responses { get; }
        DbSet<Item> Items { get; }
        DbSet<ItemAttribute> ItemAttributes { get; }
        DbSet<ItemClassification> ItemClassifications { get; }
        DbSet<Battlefield> Battlefields { get; }
        DbSet<BattlefieldSquare> BattlefieldSquares { get; }
        DbSet<CampaignPlanet> CampaignPlanets { get; }
        DbSet<Location> Locations { get; }
        DbSet<LocationMap> LocationsMaps { get; }
        DbSet<Planet> Planets { get; }
        DbSet<User> Users { get; }
        DbSet<UserCampaign> UserCampaigns { get; }
        DbSet<UserCampaignCharacter> UserCampaignCharacters { get; }
        DbSet<UserCharacter> UserCharacters { get; }
        DbSet<Permission> Permissions { get; }
        DbSet<UserPermission> UserPermissions { get; }
    }
}
