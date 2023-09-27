using KotorsGate.Domain.Entities.Ability;
using KotorsGate.Domain.Entities.Ability.Feat;
using KotorsGate.Domain.Entities.Ability.Power;
using KotorsGate.Domain.Entities.Ability.Skill;
using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Characters;
using KotorsGate.Domain.Entities.Dialogue;
using KotorsGate.Domain.Entities.Item;
using KotorsGate.Domain.Entities.Location;
using KotorsGate.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Application.Interfaces
{
    public interface IKotorsGateDbContext
    {
        DbSet<Attribute> Attributes { get; }
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
        DbSet<CharacterAttribute> CharacterAttributes { get; }
        DbSet<CharacterFeat> CharacterFeats { get; }
        DbSet<CharacterItem> CharacterItems { get; }
        DbSet<CharacterParty> CharacterParties { get; }
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
        DbSet<BattlefieldSquareMap> BattlefieldSquareMaps { get; }
        DbSet<CampaignPlanet> CampaignPlanets { get; }
        DbSet<Location> Locations { get; }
        DbSet<LocationMap> LocationsMaps { get; }
        DbSet<Planet> Planets { get; }
        DbSet<User> Users { get; }
        DbSet<UserCampaign> UserCampaigns { get; }
        DbSet<UserCampaignCharacter> UserCampaignCharacters { get; }
        DbSet<UserCharacter> UserCharacters { get; }
    }
}
