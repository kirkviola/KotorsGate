using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Ability;
using KotorsGate.Domain.Entities.Ability.Feat;
using KotorsGate.Domain.Entities.Ability.Power;
using KotorsGate.Domain.Entities.Ability.Skill;
using KotorsGate.Domain.Entities.Campaign;
using KotorsGate.Domain.Entities.Character;
using KotorsGate.Domain.Entities.Dialogue;
using KotorsGate.Domain.Entities.Item;
using KotorsGate.Domain.Entities.Location;
using KotorsGate.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Infrastructure
{
    public class KotorsGateDbContext : DbContext, IKotorsGateDbContext
    {
        public DbSet<Attribute> Attributes { get; set; }

        public DbSet<Feat> Feats { get; set; }

        public DbSet<FeatProgression> FeaturesProgressions { get; set; }

        public DbSet<ClassFeat> ClassFeats { get; set; }

        public DbSet<Power> Powers { get; set; }

        public DbSet<ClassPower> ClassPowers { get; set; }

        public DbSet<PowerProgression> PowerProgressions { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<CampaignQuest> CampaignQuests { get; set; }

        public DbSet<CampaignQuestObjective> CampaignQuestObjectives { get; set; }

        public DbSet<Quest> Quests { get; set; }

        public DbSet<QuestObjective> QuestsObjectives { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<CharacterAttribute> CharacterAttributes { get; set; }

        public DbSet<CharacterFeat> CharacterFeats { get; set; }

        public DbSet<CharacterItem> CharacterItems { get; set; }

        public DbSet<CharacterParty> CharacterParties { get; set; }

        public DbSet<CharacterSkill> CharacterSkills { get; set; }

        public DbSet<Party> Parties { get; set; }

        public DbSet<CharacterDialogue> CharacterDialogues { get; set; }

        public DbSet<DialogueLine> DialogueLines { get; set; }

        public DbSet<QuestDialogue> QuestDialogues { get; set; }

        public DbSet<Response> Responses { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemAttribute> ItemAttributes { get; set; }

        public DbSet<ItemClassification> ItemClassifications { get; set; }

        public DbSet<Battlefield> Battlefields { get; set; }

        public DbSet<BattlefieldSquare> BattlefieldSquares { get; set; }

        public DbSet<BattlefieldSquareMap> BattlefieldSquareMaps { get; set; }

        public DbSet<CampaignPlanet> CampaignPlanets { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<LocationMap> LocationsMaps { get; set; }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCampaign> UserCampaigns { get; set; }

        public DbSet<UserCampaignCharacter> UserCampaignCharacters { get; set; }

        public DbSet<UserCharacter> UserCharacters { get; set; }

        public KotorsGateDbContext(DbContextOptions<KotorsGateDbContext> options) : base(options) { }

        // Fluent API to go here. Oh boy.

    }
}
