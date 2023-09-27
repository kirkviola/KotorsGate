using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Constants;
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

namespace KotorsGate.Infrastructure
{
    public class KotorsGateDbContext : DbContext, IKotorsGateDbContext
    {
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Feat> Feats { get; set; }
        public virtual DbSet<FeatProgression> FeaturesProgressions { get; set; }
        public virtual DbSet<ClassFeat> ClassFeats { get; set; }
        public virtual DbSet<Power> Powers { get; set; }
        public virtual DbSet<ClassPower> ClassPowers { get; set; }
        public virtual DbSet<PowerProgression> PowerProgressions { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<CampaignQuest> CampaignQuests { get; set; }
        public virtual DbSet<CampaignQuestObjective> CampaignQuestObjectives { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<QuestObjective> QuestsObjectives { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterAttribute> CharacterAttributes { get; set; }
        public virtual DbSet<CharacterFeat> CharacterFeats { get; set; }
        public virtual DbSet<CharacterItem> CharacterItems { get; set; }
        public virtual DbSet<CharacterParty> CharacterParties { get; set; }
        public virtual DbSet<CharacterSkill> CharacterSkills { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<CharacterDialogue> CharacterDialogues { get; set; }
        public virtual DbSet<DialogueLine> DialogueLines { get; set; }
        public virtual DbSet<QuestDialogue> QuestDialogues { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemAttribute> ItemAttributes { get; set; }
        public virtual DbSet<ItemClassification> ItemClassifications { get; set; }
        public virtual DbSet<Battlefield> Battlefields { get; set; }
        public virtual DbSet<BattlefieldSquare> BattlefieldSquares { get; set; }
        public virtual DbSet<BattlefieldSquareMap> BattlefieldSquareMaps { get; set; }
        public virtual DbSet<CampaignPlanet> CampaignPlanets { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationMap> LocationsMaps { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCampaign> UserCampaigns { get; set; }
        public virtual DbSet<UserCampaignCharacter> UserCampaignCharacters { get; set; }
        public virtual DbSet<UserCharacter> UserCharacters { get; set; }

        public KotorsGateDbContext(DbContextOptions<KotorsGateDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(user =>
            {
                user.ToTable("Users");
                user.HasKey(user => user.Id);
                user.Property(user => user.Name).HasMaxLength(64).IsRequired();
                user.HasIndex(user => user.Name).IsUnique();
                user.Property(user => user.Password).HasMaxLength(64).IsRequired();
            });

            builder.Entity<Character>(character => 
            {
                character.ToTable("Characters");
                character.HasKey(character => character.Id);
                character.Property(character => character.Name).HasMaxLength(64).IsRequired();
                character.Property(character => character.Level).HasDefaultValue(1).IsRequired();
                character.Property(character => character.TotalHitPoints).HasMaxLength(5000).IsRequired();
                character.Property(character => character.CurrentHitPoints).HasMaxLength(5000).IsRequired();
                character.Property(character => character.TotalForcePoints).HasMaxLength(5000).IsRequired(false).HasDefaultValue(null);
                character.Property(character => character.CurrentForcePoints).HasMaxLength(5000).IsRequired(false).HasDefaultValue(null);
                character.Property(character => character.Alignment).IsRequired(true).HasDefaultValue(0);
            });

            builder.Entity<UserCharacter>(userCharacter => 
            {
                userCharacter.ToTable("UserCharacters");
                userCharacter.HasKey(userCharacter => userCharacter.Id);
                userCharacter.HasOne(userCharacter => userCharacter.User)
                    .WithMany(user => user.UserCharacters)
                    .HasForeignKey(userCharacter => userCharacter.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                userCharacter.HasOne(userCharacter => userCharacter.Character)
                    .WithMany(character => character.UserCharacters)
                    .HasForeignKey(userCharacter => userCharacter.CharacterId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Campaign>(campaign =>
            {
                campaign.ToTable("Campaigns");
                campaign.HasKey(campaign => campaign.Id);
                campaign.Property(campaign => campaign.Name).HasMaxLength(64).IsRequired();
                campaign.HasIndex(campaign => campaign.Name).IsUnique();
                campaign.Property(campaign => campaign.Description).HasMaxLength(2048).IsRequired();
            });

            builder.Entity<UserCampaign>(userCampaign =>
            {
                userCampaign.ToTable("UserCampaigns");
                userCampaign.HasKey(campaign => campaign.Id);
                userCampaign.HasOne(userCampaign => userCampaign.User)
                    .WithMany(user => user.UserCampaigns)
                    .HasForeignKey(userCampaign => userCampaign.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                userCampaign.HasOne(userCampaign => userCampaign.Campaign)
                    .WithMany(campaign => campaign.UserCampaigns)
                    .HasForeignKey(userCampaign => userCampaign.CampaignId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Class>(c =>
            {
                c.ToTable("Classes");
                c.HasKey(c => c.Id);
                c.Property(c => c.Name).HasMaxLength(64).IsRequired();
                c.HasIndex(c => c.Name).IsUnique();
                c.Property(c => c.Description).HasMaxLength(2048).IsRequired();
            });

            builder.Entity<Feat>(feat =>
            {
                feat.ToTable("Feats");
                feat.HasKey(feat => feat.Id);
                feat.Property(feat => feat.Name).HasMaxLength(64).IsRequired();
                feat.HasIndex(feat => feat.Name).IsUnique();
                feat.Property(feat => feat.ToolTip).HasMaxLength(2048).IsRequired();
                feat.Property(feat => feat.RequiredLevel).IsRequired(false).HasDefaultValue(null);
            });

            builder.Entity<ClassFeat>(classFeat =>
            {
                classFeat.ToTable("ClassFeats");
                classFeat.HasKey(classFeat => classFeat.Id);
                classFeat.HasOne(classFeat => classFeat.Class)
                    .WithMany(c => c.ClassFeats)
                    .HasForeignKey(classFeat => classFeat.ClassId)
                    .OnDelete(DeleteBehavior.Cascade);
                classFeat.HasOne(classFeat => classFeat.Feat)
                    .WithMany(feat => feat.ClassFeats)
                    .HasForeignKey(classFeat => classFeat.FeatId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<CharacterFeat>(characterFeat =>
            {
                characterFeat.ToTable("CharacterFeats");
                characterFeat.HasKey(characterFeat => characterFeat.Id);
                characterFeat.HasOne(characterFeat => characterFeat.Character)
                    .WithMany(character => character.CharacterFeats)
                    .HasForeignKey(characterFeat => characterFeat.CharacterId) 
                    .OnDelete(DeleteBehavior.Cascade);
                characterFeat.HasOne(characterFeat => characterFeat.Feat)
                    .WithMany(feat => feat.CharacterFeats)
                    .HasForeignKey(characterFeat => characterFeat.FeatId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Power>(power =>
            {
                power.ToTable("Powers");
                power.HasKey(power => power.Id);
                power.Property(power => power.Name).HasMaxLength(64).IsRequired();
                power.HasIndex(power => power.Name).IsUnique();
                power.Property(power => power.ToolTip).HasMaxLength(2048).IsRequired();
                power.Property(power => power.RequiredLevel).IsRequired(false).HasDefaultValue(null);
                power.Property(power => power.Alignment).HasMaxLength(12).IsRequired().HasDefaultValue(Alignment.Universal.Value);
                power.Property(power => power.BaseCost).IsRequired();
            });

            builder.Entity<Quest>(quest =>
            {
                quest.ToTable("Quests");
                quest.HasKey(quest => quest.Id);
                quest.Property(quest => quest.Name).HasMaxLength(64).IsRequired();
                quest.Property(quest => quest.Description).HasMaxLength(2048).IsRequired();
                quest.Property(quest => quest.IsMainQuest).IsRequired().HasDefaultValue(false);
            });

            builder.Entity<ItemClassification>(classification =>
            {
                classification.ToTable("ItemClassifications");
                classification.HasKey(classification => classification.Id);
                classification.Property(classification => classification.Name).HasMaxLength(64).IsRequired();
            });

            builder.Entity<Item>(item => 
            {
                item.ToTable("Items");
                item.HasKey(item => item.Id);
                item.Property(item => item.Name).HasMaxLength(64).IsRequired();
                item.HasIndex(item => item.Name).IsUnique();
                item.Property(item => item.Description).HasMaxLength(2048).IsRequired();
                item.Property(item => item.IsConsumable).IsRequired().HasDefaultValue(false);
                item.HasOne(item => item.ItemClassification)
                    .WithMany(classification => classification.Items)
                    .HasForeignKey(item => item.ItemTypeId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Party>(party =>
            {
                party.ToTable("Parties");
                party.HasKey(party => party.Id);
                party.HasOne(party => party.UserCampaign)
                    .WithMany(campaign => campaign.Parties)
                    .HasForeignKey(party => party.UserCampaignId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<CharacterParty>(characterParty =>
            {
                characterParty.ToTable("CharacterParties");
                characterParty.HasKey(characterParty => characterParty.Id);
                characterParty.HasOne(characterParty => characterParty.Character)
                    .WithMany(character => character.CharacterParties)
                    .HasForeignKey(characterParty => characterParty.CharacterId)
                    .OnDelete(DeleteBehavior.Cascade);
                characterParty.HasOne(characterParty => characterParty.Party)
                    .WithMany(party => party.CharacterParties)
                    .HasForeignKey(characterParty => characterParty.PartyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
