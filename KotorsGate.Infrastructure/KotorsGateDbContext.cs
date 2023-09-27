﻿using KotorsGate.Application.Interfaces;
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

            builder.Entity<Campaign>(campaign =>
            {
                campaign.ToTable("Campaigns");
                campaign.HasKey(campaign => campaign.Id);
                campaign.Property(campaign => campaign.Name).HasMaxLength(64).IsRequired();
                campaign.HasIndex(campaign => campaign.Name).IsUnique();
                campaign.Property(campaign => campaign.Description).HasMaxLength(2048).IsRequired();
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
        }

    }
}
