using KotorsGate.Application.Interfaces;
using KotorsGate.Domain.Entities.Abilities;
using KotorsGate.Domain.Entities.Abilities.Feat;
using KotorsGate.Domain.Entities.Abilities.Ability;
using KotorsGate.Domain.Entities.Abilities.Power;
using KotorsGate.Domain.Entities.Abilities.Skill;
using KotorsGate.Domain.Entities.Campaigns;
using KotorsGate.Domain.Entities.Characters;
using KotorsGate.Domain.Entities.Dialogue;
using KotorsGate.Domain.Entities.Items;
using KotorsGate.Domain.Entities.Location;
using KotorsGate.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace KotorsGate.Infrastructure
{
    public class KotorsGateDbContext : DbContext, IKotorsGateDbContext
    {
        public virtual DbSet<Ability> Abilities { get; set; }
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
        public virtual DbSet<CharacterAbility> CharacterAbilities { get; set; }
        public virtual DbSet<CharacterFeat> CharacterFeats { get; set; }
        public virtual DbSet<CharacterItem> CharacterItems { get; set; }
        public virtual DbSet<CharacterParty> CharacterParties { get; set; }
        public virtual DbSet<CharacterPower> CharacterPowers { get; set; }
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

            builder.Entity<User>(user => {
                user.ToTable("Users");
                user.HasKey(user => user.Id);
                user.Property(user => user.Username).IsRequired().HasMaxLength(128);
                user.HasIndex(user => user.Username).IsUnique();
                user.Property(user => user.Password).IsRequired().HasMaxLength(256);
            });

            builder.Entity<Character>(character => {
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

            builder.Entity<UserCharacter>(userCharacter => {
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

            builder.Entity<Ability>(ability => {
                ability.ToTable("Abilities");
                ability.HasKey(ability => ability.Id);
                ability.Property(ability => ability.Name).IsRequired().HasMaxLength(64);
                ability.HasIndex(ability => ability.Name).IsUnique();
                ability.Property(ability => ability.Description).IsRequired().HasMaxLength(2048);
            });

            builder.Entity<CharacterAbility>(ca => {
                ca.ToTable("CharacterAbilities");
                ca.HasKey(ca => ca.Id);
                ca.Property(ca => ca.Value).IsRequired().HasDefaultValue(8).HasMaxLength(99);
                ca.HasOne(ca => ca.Character)
                    .WithMany(c => c.CharacterAbilities)
                    .HasForeignKey(ca => ca.CharacterId)
                    .OnDelete(DeleteBehavior.Cascade);
                ca.HasOne(ca => ca.Ability)
                    .WithMany(a => a.CharacterAbilities)
                    .HasForeignKey(ca => ca.AbilityId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Campaign>(campaign => {
                campaign.ToTable("Campaigns");
                campaign.HasKey(campaign => campaign.Id);
                campaign.Property(campaign => campaign.Name).HasMaxLength(64).IsRequired();
                campaign.HasIndex(campaign => campaign.Name).IsUnique();
                campaign.Property(campaign => campaign.Description).HasMaxLength(2048).IsRequired();
            });

            builder.Entity<UserCampaign>(userCampaign => {
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

            builder.Entity<UserCampaignCharacter>(uCampChar => {
                uCampChar.ToTable("UserCampaignCharacters");
                uCampChar.HasKey(uCampChar =>  uCampChar.Id);
                uCampChar.HasOne(uCampChar => uCampChar.UserCampaign)
                    .WithMany(uCamp => uCamp.UserCampaignCharacters)
                    .HasForeignKey(uCampChar => uCampChar.UserCampaignId)
                    .OnDelete(DeleteBehavior.Cascade);
                uCampChar.HasOne(uCampChar => uCampChar.Character)
                    .WithMany(character => character.UserCampaignCharacters)
                    .HasForeignKey(uCampChar => uCampChar.CharacterId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Class>(c => {
                c.ToTable("Classes");
                c.HasKey(c => c.Id);
                c.Property(c => c.Name).HasMaxLength(64).IsRequired();
                c.HasIndex(c => c.Name).IsUnique();
                c.Property(c => c.Description).HasMaxLength(2048).IsRequired();
            });

            builder.Entity<Feat>(feat => {
                feat.ToTable("Feats");
                feat.HasKey(feat => feat.Id);
                feat.Property(feat => feat.Name).HasMaxLength(64).IsRequired();
                feat.HasIndex(feat => feat.Name).IsUnique();
                feat.Property(feat => feat.ToolTip).HasMaxLength(2048).IsRequired();
                feat.Property(feat => feat.RequiredLevel).IsRequired().HasDefaultValue(0);
            });

            builder.Entity<ClassFeat>(classFeat => {
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

            builder.Entity<CharacterFeat>(characterFeat => {
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

            builder.Entity<FeatProgression>(progression => {
                progression.ToTable("FeatProgressions");
                progression.HasKey(progression => progression.Id);
                progression.HasOne(progression => progression.Feat)
                    .WithMany(feat => feat.FeatProgressions)
                    .HasForeignKey(progression => progression.RequiredFeatId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Power>(power => {
                power.ToTable("Powers");
                power.HasKey(power => power.Id);
                power.Property(power => power.Name).HasMaxLength(64).IsRequired();
                power.HasIndex(power => power.Name).IsUnique();
                power.Property(power => power.ToolTip).HasMaxLength(2048).IsRequired();
                power.Property(power => power.RequiredLevel).IsRequired().HasDefaultValue(0);
                power.Property(power => power.Alignment).HasMaxLength(12).IsRequired();
                power.Property(power => power.BaseCost).IsRequired();
            });

            builder.Entity<ClassPower>(classPower => {
                classPower.ToTable("ClassPowers");
                classPower.HasKey(classPower => classPower.Id);
                classPower.HasOne(classPower => classPower.Class)
                    .WithMany(c => c.ClassPowers)
                    .HasForeignKey(classPower => classPower.ClassId)
                    .OnDelete(DeleteBehavior.Cascade);
                classPower.HasOne(classPower => classPower.Power)
                    .WithMany(power => power.ClassPowers)
                    .HasForeignKey(classPower => classPower.PowerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<CharacterPower>(characterPower => {
                characterPower.ToTable("CharacterPowers");
                characterPower.HasKey(characterPower => characterPower.Id);
                characterPower.HasOne(characterPower => characterPower.Character)
                    .WithMany(character => character.CharacterPowers)
                    .HasForeignKey(characterPower => characterPower.CharacterId)
                    .OnDelete(DeleteBehavior.Cascade);
                characterPower.HasOne(characterPower => characterPower.Power)
                    .WithMany(power => power.CharacterPowers)
                    .HasForeignKey(characterPower => characterPower.PowerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PowerProgression>(progression => {
                progression.ToTable("PowerProgressions");
                progression.HasKey(progression => progression.Id);
                progression.HasOne(prog => prog.Power)
                    .WithMany(power => power.PowerProgressions)
                    .HasForeignKey(prog => prog.RequiredPowerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Quest>(quest => {
                quest.ToTable("Quests");
                quest.HasKey(quest => quest.Id);
                quest.Property(quest => quest.Name).HasMaxLength(64).IsRequired();
                quest.Property(quest => quest.Description).HasMaxLength(2048).IsRequired();
                quest.Property(quest => quest.IsMainQuest).IsRequired().HasDefaultValue(false);
            });

            builder.Entity<QuestObjective>(objective => {
                objective.ToTable("QuestObjectives");
                objective.HasKey(objective => objective.Id);
                objective.Property(objective => objective.Name).HasMaxLength(64).IsRequired();
                objective.Property(objective => objective.Description).HasMaxLength(2048).IsRequired();
                objective.Property(objective => objective.SequencePosition).HasMaxLength(128).IsRequired();
                objective.HasOne(objective => objective.Quest)
                    .WithMany(quest => quest.QuestObjectives)
                    .HasForeignKey(objective => objective.QuestId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<CampaignQuest>(cQuest => {
                cQuest.ToTable("CampaignQuests");
                cQuest.HasKey(cQuest => cQuest.Id);
                cQuest.HasOne(cQuest => cQuest.Campaign)
                    .WithMany(campaign => campaign.CampaignQuests)
                    .HasForeignKey(cQuest => cQuest.CampaignId)
                    .OnDelete(DeleteBehavior.NoAction);
                cQuest.HasOne(cQuest => cQuest.Quest)
                    .WithMany(quest => quest.CampaignQuests)
                    .HasForeignKey(cQuest => cQuest.QuestId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<CampaignQuestObjective>(cObjective => {
                cObjective.ToTable("CampaignQuestObjectives");
                cObjective.HasKey(cObjective => cObjective.Id);
                cObjective.Property(cObjective => cObjective.IsComplete).IsRequired().HasDefaultValue(false);
                cObjective.HasOne(cObjective => cObjective.CampaignQuest)
                    .WithMany(cQuest => cQuest.CampaignQuestObjectives)
                    .HasForeignKey(cObjective => cObjective.CampaignQuestId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<ItemClassification>(classification => {
                classification.ToTable("ItemClassifications");
                classification.HasKey(classification => classification.Id);
                classification.Property(classification => classification.Name).HasMaxLength(64).IsRequired();
            });

            builder.Entity<Item>(item => {
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

            builder.Entity<ItemAttribute>(attribute => {
                attribute.ToTable("ItemAttributes");
                attribute.HasKey(attribute => attribute.Id);
                attribute.Property(attribute => attribute.Name).HasMaxLength(64).IsRequired();
                attribute.Property(attribute => attribute.MinValue).IsRequired(false).HasDefaultValue(null).HasMaxLength(1028);
                attribute.Property(attribute => attribute.MaxValue).IsRequired(false).HasDefaultValue(null).HasMaxLength(1028);
                attribute.Property(attribute => attribute.SingleValue).IsRequired(false).HasDefaultValue(null).HasMaxLength(1028);
                attribute.HasOne(attribute => attribute.Item)
                    .WithMany(item => item.ItemAttributes)
                    .HasForeignKey(attribute => attribute.ItemId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<CharacterItem>(ci => {
                ci.ToTable("CharacterItems");
                ci.HasKey(ci => ci.Id);
                ci.HasOne(ci => ci.Character)
                    .WithMany(c => c.CharacterItems)
                    .HasForeignKey(ci => ci.CharacterId) 
                    .OnDelete(DeleteBehavior.Cascade);
                ci.HasOne(ci => ci.Item)
                    .WithMany(i => i.CharacterItems)
                    .HasForeignKey(ci => ci.ItemId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Party>(party => {
                party.ToTable("Parties");
                party.HasKey(party => party.Id);
                party.HasOne(party => party.UserCampaign)
                    .WithMany(campaign => campaign.Parties)
                    .HasForeignKey(party => party.UserCampaignId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<CharacterParty>(characterParty => {
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

            builder.Entity<Skill>(skill => {
                skill.ToTable("Skills");
                skill.HasKey(skill => skill.Id);
                skill.Property(skill => skill.Name).HasMaxLength(64).IsRequired();
                skill.HasIndex(skill => skill.Name).IsUnique();
                skill.Property(skill => skill.Description).HasMaxLength(1028).IsRequired();
            });

            builder.Entity<CharacterSkill>(cs => {
                cs.ToTable("CharacterSkills");
                cs.HasKey(cs => cs.Id);
                cs.HasOne(cs => cs.Character)
                    .WithMany(c => c.CharacterSkills)
                    .HasForeignKey(cs => cs.CharacterId)
                    .OnDelete(DeleteBehavior.Cascade);
                cs.HasOne(cs => cs.Skill)
                    .WithMany(s => s.CharacterSkills)
                    .HasForeignKey(cs => cs.SkillId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<QuestDialogue>(dialogue => {
                dialogue.ToTable("QuestDialogues");
                dialogue.HasKey(dialogue => dialogue.Id);
                dialogue.HasOne(d => d.Quest)
                    .WithMany(q => q.QuestDialogues)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<CharacterDialogue>(cd => {
                cd.ToTable("CharacterDialogues");
                cd.HasKey(cd => cd.Id);
                cd.HasOne(cd => cd.Character)
                    .WithMany(c => c.CharacterDialogues)
                    .HasForeignKey(cd => cd.CharacterId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<DialogueLine>(dl => {
                dl.ToTable("DialogueLines");
                dl.HasKey(dl => dl.Id);
                dl.Property(dl => dl.Text).IsRequired().HasMaxLength(1028);
                dl.HasOne(dl => dl.QuestDialogue)
                    .WithMany(qd => qd.DialogueLines)
                    .HasForeignKey(dl => dl.DialogueId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Response>(r => {
                r.ToTable("Responses");
                r.HasKey(r => r.Id);
                r.Property(r => r.Text).HasMaxLength(1028).IsRequired();
                r.HasOne(r => r.DialogueLine)
                    .WithMany(dl => dl.Responses)
                    .HasForeignKey(r => r.DialogueLineId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Planet>(p => {
                p.ToTable("Planets");
                p.HasKey(p => p.Id);
                p.Property(p => p.Name).HasMaxLength(64).IsRequired();
                p.HasIndex(p => p.Name).IsUnique();
                p.Property(p => p.Description).HasMaxLength(2048).IsRequired();
            });

            builder.Entity<CampaignPlanet>(campP => {
                campP.ToTable("CampaignPlanets");
                campP.HasKey(campP => campP.Id);
                campP.HasOne(campP => campP.Campaign)
                    .WithMany(c => c.CampaignPlanets)
                    .HasForeignKey(campP => campP.CampaignId)
                    .OnDelete(DeleteBehavior.Restrict);
                campP.HasOne(campP => campP.Planet)
                    .WithMany(p => p.CampaignPlanets)
                    .HasForeignKey(campP => campP.PlanetId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Location>(l => {
                l.ToTable("Locations");
                l.HasKey(l => l.Id);
                l.Property(l => l.Name).HasMaxLength(64).IsRequired();
                l.HasOne(l => l.CampaignPlanet)
                    .WithMany(campP => campP.Locations)
                    .HasForeignKey(l => l.CampaignPlanetId)
                    .OnDelete(DeleteBehavior.Cascade);              
            });

            builder.Entity<LocationMap>(map => {
                map.ToTable("LocationMaps");
                map.HasKey(l => l.Id);
                map.HasOne(map => map.Location)
                    .WithMany(l => l.LocationMaps)
                    .HasForeignKey(map => map.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Battlefield>(b => {
                b.ToTable("Battlefields");
                b.HasKey(l => l.Id);
                b.HasOne(b => b.Location)
                    .WithMany(l => l.Battlefields)
                    .HasForeignKey(b => b.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<BattlefieldSquare>(bs => {
                bs.ToTable("BattlefieldSquares");
                bs.HasKey(bs => bs.Id);
                bs.Property(bs => bs.XCoordinate).HasMaxLength(64).IsRequired();
                bs.Property(bs => bs.YCoordinate).HasMaxLength(64).IsRequired();
                bs.HasOne(bs => bs.Battlefield)
                    .WithMany(b => b.BattlefieldSquares)
                    .HasForeignKey(bs => bs.BattlefieldId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
