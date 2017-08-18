using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Elixr2.Api.Services;
using Elixr2.Api.Models;

namespace Elixr2.Migrations
{
    [DbContext(typeof(ElixrDbContext))]
    partial class ElixrDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Elixr2.Api.Models.AppliedStatMod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppliedAtLevel");

                    b.Property<long>("AppliedAtUnixMS");

                    b.Property<int?>("CreatureId");

                    b.Property<int>("StatModId");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.HasIndex("StatModId");

                    b.ToTable("AppliedStatMod");
                });

            modelBuilder.Entity("Elixr2.Api.Models.Armor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgilityPenalty");

                    b.Property<int>("CampaignSettingId");

                    b.Property<int>("CopperCost");

                    b.Property<int>("DefenseBonus");

                    b.Property<string>("Description");

                    b.Property<int>("GoldCost");

                    b.Property<bool>("IsDelisted");

                    b.Property<string>("Name");

                    b.Property<int>("SilverCost");

                    b.Property<int>("SpeedPenalty");

                    b.Property<float>("WeightInPounds");

                    b.HasKey("Id");

                    b.ToTable("Armor");
                });

            modelBuilder.Entity("Elixr2.Api.Models.CampaignSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BaseDefense");

                    b.Property<int>("CharacteristicPointsEachLevel");

                    b.Property<long>("Code");

                    b.Property<int>("MaxAbilityScore");

                    b.Property<int>("MaxSkillRanksAboveLevel");

                    b.Property<string>("Name");

                    b.Property<int>("SkillPointsEachLevel");

                    b.Property<int>("StartingAbilityPoints");

                    b.Property<float>("StartingWealth");

                    b.HasKey("Id");

                    b.ToTable("CampaignSettings");
                });

            modelBuilder.Entity("Elixr2.Api.Models.Characteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampaignSettingId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDelisted");

                    b.Property<bool>("IsTemplateOnly");

                    b.Property<string>("Name");

                    b.Property<int?>("SpecifiedPowerAdjustment");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("Elixr2.Api.Models.Creature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Age");

                    b.Property<int>("CampaignSettingId");

                    b.Property<string>("Description");

                    b.Property<string>("Eyes");

                    b.Property<string>("Gender");

                    b.Property<string>("Hair");

                    b.Property<string>("Height");

                    b.Property<bool>("IsCharacter");

                    b.Property<bool>("IsDelisted");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("Skin");

                    b.Property<string>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Creatures");
                });

            modelBuilder.Entity("Elixr2.Api.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampaignSettingId");

                    b.Property<int>("CopperCost");

                    b.Property<string>("Description");

                    b.Property<int>("GoldCost");

                    b.Property<bool>("IsDelisted");

                    b.Property<string>("Name");

                    b.Property<int>("SilverCost");

                    b.Property<float>("WeightInPounds");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedArmor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArmorId");

                    b.Property<int?>("CreatureId");

                    b.Property<string>("Notes");

                    b.Property<long>("SelectedAtMS");

                    b.HasKey("Id");

                    b.HasIndex("ArmorId");

                    b.HasIndex("CreatureId");

                    b.ToTable("SelectedArmor");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacteristicId");

                    b.Property<int?>("CreatureId");

                    b.Property<bool>("IsTemplateCharacteristic");

                    b.Property<string>("Notes");

                    b.Property<int>("TakenAtLevel");

                    b.Property<long>("TakenAtMS");

                    b.Property<int?>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("CharacteristicId");

                    b.HasIndex("CreatureId");

                    b.HasIndex("TemplateId");

                    b.ToTable("SelectedCharacteristic");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatureId");

                    b.Property<int>("ItemId");

                    b.Property<string>("Notes");

                    b.Property<long>("SelectedAtMS");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.HasIndex("ItemId");

                    b.ToTable("SelectedItem");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedSpell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatureId");

                    b.Property<string>("Notes");

                    b.Property<int>("SelectedAtLevel");

                    b.Property<long>("SelectedAtMS");

                    b.Property<int>("SpellId");

                    b.Property<int?>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.HasIndex("SpellId");

                    b.HasIndex("TemplateId");

                    b.ToTable("SelectedSpell");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedSpellCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacteristicId");

                    b.Property<string>("Notes");

                    b.Property<int?>("SelectedSpellId");

                    b.Property<int>("TakenAtLevel");

                    b.Property<long>("TakenAtMS");

                    b.HasKey("Id");

                    b.HasIndex("CharacteristicId");

                    b.HasIndex("SelectedSpellId");

                    b.ToTable("SelectedSpellCharacteristic");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatureId");

                    b.Property<string>("Notes");

                    b.Property<long>("SelectedAtMS");

                    b.Property<int>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.HasIndex("TemplateId");

                    b.ToTable("SelectedTemplate");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatureId");

                    b.Property<string>("Notes");

                    b.Property<long>("SelectedAtMS");

                    b.Property<int>("WeaponId");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.HasIndex("WeaponId");

                    b.ToTable("SelectedWeapon");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedWeaponCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacteristicId");

                    b.Property<string>("Notes");

                    b.Property<int?>("SelectedWeaponId");

                    b.Property<int>("TakenAtLevel");

                    b.Property<long>("TakenAtMS");

                    b.HasKey("Id");

                    b.HasIndex("CharacteristicId");

                    b.HasIndex("SelectedWeaponId");

                    b.ToTable("SelectedWeaponCharacteristic");
                });

            modelBuilder.Entity("Elixr2.Api.Models.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampaignSettingId");

                    b.Property<string>("Description");

                    b.Property<bool>("DoesDamage");

                    b.Property<string>("EnergyRequired");

                    b.Property<bool>("IsConcentration");

                    b.Property<bool>("IsDelisted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SpellCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampaignSettingId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDelisted");

                    b.Property<string>("Name");

                    b.Property<int?>("SpecifiedPowerAdjustment");

                    b.HasKey("Id");

                    b.ToTable("SpellCharacteristics");
                });

            modelBuilder.Entity("Elixr2.Api.Models.Stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CampaignSettingId");

                    b.Property<string>("DisplayName");

                    b.Property<int>("Group");

                    b.Property<int>("MaxValue");

                    b.Property<string>("MaxValueFormula");

                    b.Property<string>("Name");

                    b.Property<bool>("NonModdable");

                    b.Property<int>("Order");

                    b.Property<int?>("ParentStatId");

                    b.Property<int>("PowerRating");

                    b.Property<int>("Ratio");

                    b.HasKey("Id");

                    b.HasIndex("CampaignSettingId");

                    b.HasIndex("ParentStatId");

                    b.ToTable("Stat");
                });

            modelBuilder.Entity("Elixr2.Api.Models.StatMod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CampaignSettingId");

                    b.Property<int?>("CampaignSettingId1");

                    b.Property<int?>("CharacteristicId");

                    b.Property<int>("Modifier");

                    b.Property<string>("Reason");

                    b.Property<int>("StatId");

                    b.Property<int?>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("CampaignSettingId");

                    b.HasIndex("CampaignSettingId1");

                    b.HasIndex("CharacteristicId");

                    b.HasIndex("StatId");

                    b.HasIndex("TemplateId");

                    b.ToTable("StatMod");
                });

            modelBuilder.Entity("Elixr2.Api.Models.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampaignSettingId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDelisted");

                    b.Property<bool>("IsRace");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("Elixr2.Api.Models.WealthAdjustment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AdjustedAtMS");

                    b.Property<float>("Amount");

                    b.Property<int?>("CreatureId");

                    b.Property<string>("Reason");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.ToTable("WealthAdjustment");
                });

            modelBuilder.Entity("Elixr2.Api.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AttackAbility");

                    b.Property<int>("CampaignSettingId");

                    b.Property<bool>("CanBludgeon");

                    b.Property<bool>("CanPierce");

                    b.Property<bool>("CanSlash");

                    b.Property<int>("CopperCost");

                    b.Property<string>("Damage");

                    b.Property<int>("DamageAbility");

                    b.Property<string>("Description");

                    b.Property<int>("GoldCost");

                    b.Property<bool>("HasReach");

                    b.Property<bool>("IgnoresArmor");

                    b.Property<bool>("IsDelisted");

                    b.Property<bool>("IsTwoHanded");

                    b.Property<string>("Name");

                    b.Property<int>("Range");

                    b.Property<int>("SilverCost");

                    b.Property<float>("WeightInPounds");

                    b.HasKey("Id");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("Elixr2.Api.Models.WeaponCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AttackBonusMod");

                    b.Property<int>("CampaignSettingId");

                    b.Property<int>("DamageBonusMod");

                    b.Property<string>("Description");

                    b.Property<string>("ExtraDamage");

                    b.Property<bool>("IsDelisted");

                    b.Property<string>("Name");

                    b.Property<int?>("SpecifiedPowerAdjustment");

                    b.HasKey("Id");

                    b.ToTable("WeaponCharacteristics");
                });

            modelBuilder.Entity("Elixr2.Api.Models.AppliedStatMod", b =>
                {
                    b.HasOne("Elixr2.Api.Models.Creature")
                        .WithMany("Mods")
                        .HasForeignKey("CreatureId");

                    b.HasOne("Elixr2.Api.Models.StatMod", "StatMod")
                        .WithMany()
                        .HasForeignKey("StatModId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedArmor", b =>
                {
                    b.HasOne("Elixr2.Api.Models.Armor", "Armor")
                        .WithMany()
                        .HasForeignKey("ArmorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elixr2.Api.Models.Creature")
                        .WithMany("SelectedArmor")
                        .HasForeignKey("CreatureId");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedCharacteristic", b =>
                {
                    b.HasOne("Elixr2.Api.Models.Characteristic", "Characteristic")
                        .WithMany()
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elixr2.Api.Models.Creature")
                        .WithMany("SelectedCharacteristics")
                        .HasForeignKey("CreatureId");

                    b.HasOne("Elixr2.Api.Models.Template")
                        .WithMany("AppliedCharacteristics")
                        .HasForeignKey("TemplateId");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedItem", b =>
                {
                    b.HasOne("Elixr2.Api.Models.Creature")
                        .WithMany("SelectedItems")
                        .HasForeignKey("CreatureId");

                    b.HasOne("Elixr2.Api.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedSpell", b =>
                {
                    b.HasOne("Elixr2.Api.Models.Creature")
                        .WithMany("SelectedSpells")
                        .HasForeignKey("CreatureId");

                    b.HasOne("Elixr2.Api.Models.Spell", "Spell")
                        .WithMany()
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elixr2.Api.Models.Template")
                        .WithMany("SelectedSpells")
                        .HasForeignKey("TemplateId");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedSpellCharacteristic", b =>
                {
                    b.HasOne("Elixr2.Api.Models.SpellCharacteristic", "Characteristic")
                        .WithMany()
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elixr2.Api.Models.SelectedSpell")
                        .WithMany("SelectedCharacteristics")
                        .HasForeignKey("SelectedSpellId");
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedTemplate", b =>
                {
                    b.HasOne("Elixr2.Api.Models.Creature")
                        .WithMany("SelectedTemplates")
                        .HasForeignKey("CreatureId");

                    b.HasOne("Elixr2.Api.Models.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedWeapon", b =>
                {
                    b.HasOne("Elixr2.Api.Models.Creature")
                        .WithMany("SelectedWeapons")
                        .HasForeignKey("CreatureId");

                    b.HasOne("Elixr2.Api.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elixr2.Api.Models.SelectedWeaponCharacteristic", b =>
                {
                    b.HasOne("Elixr2.Api.Models.WeaponCharacteristic", "Characteristic")
                        .WithMany()
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elixr2.Api.Models.SelectedWeapon")
                        .WithMany("AppliedCharacteristics")
                        .HasForeignKey("SelectedWeaponId");
                });

            modelBuilder.Entity("Elixr2.Api.Models.Stat", b =>
                {
                    b.HasOne("Elixr2.Api.Models.CampaignSetting")
                        .WithMany("Stats")
                        .HasForeignKey("CampaignSettingId");

                    b.HasOne("Elixr2.Api.Models.Stat", "ParentStat")
                        .WithMany()
                        .HasForeignKey("ParentStatId");
                });

            modelBuilder.Entity("Elixr2.Api.Models.StatMod", b =>
                {
                    b.HasOne("Elixr2.Api.Models.CampaignSetting")
                        .WithMany("InitialMods")
                        .HasForeignKey("CampaignSettingId");

                    b.HasOne("Elixr2.Api.Models.CampaignSetting")
                        .WithMany("ModsEachLevel")
                        .HasForeignKey("CampaignSettingId1");

                    b.HasOne("Elixr2.Api.Models.Characteristic")
                        .WithMany("Mods")
                        .HasForeignKey("CharacteristicId");

                    b.HasOne("Elixr2.Api.Models.Stat", "Stat")
                        .WithMany()
                        .HasForeignKey("StatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elixr2.Api.Models.Template")
                        .WithMany("Mods")
                        .HasForeignKey("TemplateId");
                });

            modelBuilder.Entity("Elixr2.Api.Models.WealthAdjustment", b =>
                {
                    b.HasOne("Elixr2.Api.Models.Creature")
                        .WithMany("WealthAdjustments")
                        .HasForeignKey("CreatureId");
                });
        }
    }
}
