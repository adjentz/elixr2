using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Elixr2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AgilityPenalty = table.Column<int>(nullable: false),
                    CampaignSettingId = table.Column<int>(nullable: false),
                    CopperCost = table.Column<int>(nullable: false),
                    DefenseBonus = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GoldCost = table.Column<int>(nullable: false),
                    IsDelisted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SilverCost = table.Column<int>(nullable: false),
                    SpeedPenalty = table.Column<int>(nullable: false),
                    WeightInPounds = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BaseDefense = table.Column<int>(nullable: false),
                    CharacteristicPointsEachLevel = table.Column<int>(nullable: false),
                    Code = table.Column<long>(nullable: false),
                    MaxAbilityScore = table.Column<int>(nullable: false),
                    MaxSkillRanksAboveLevel = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SkillPointsEachLevel = table.Column<int>(nullable: false),
                    StartingAbilityPoints = table.Column<int>(nullable: false),
                    StartingWealth = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CampaignSettingId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDelisted = table.Column<bool>(nullable: false),
                    IsTemplateOnly = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SpecifiedPowerAdjustment = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Age = table.Column<string>(nullable: true),
                    CampaignSettingId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Eyes = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Hair = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    IsCharacter = table.Column<bool>(nullable: false),
                    IsDelisted = table.Column<bool>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Skin = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CampaignSettingId = table.Column<int>(nullable: false),
                    CopperCost = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GoldCost = table.Column<int>(nullable: false),
                    IsDelisted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SilverCost = table.Column<int>(nullable: false),
                    WeightInPounds = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CampaignSettingId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DoesDamage = table.Column<bool>(nullable: false),
                    EnergyRequired = table.Column<string>(nullable: true),
                    IsConcentration = table.Column<bool>(nullable: false),
                    IsDelisted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CampaignSettingId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDelisted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SpecifiedPowerAdjustment = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellCharacteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CampaignSettingId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDelisted = table.Column<bool>(nullable: false),
                    IsRace = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AttackAbility = table.Column<int>(nullable: false),
                    CampaignSettingId = table.Column<int>(nullable: false),
                    CanBludgeon = table.Column<bool>(nullable: false),
                    CanPierce = table.Column<bool>(nullable: false),
                    CanSlash = table.Column<bool>(nullable: false),
                    CopperCost = table.Column<int>(nullable: false),
                    Damage = table.Column<string>(nullable: true),
                    DamageAbility = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GoldCost = table.Column<int>(nullable: false),
                    HasReach = table.Column<bool>(nullable: false),
                    IgnoresArmor = table.Column<bool>(nullable: false),
                    IsDelisted = table.Column<bool>(nullable: false),
                    IsTwoHanded = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Range = table.Column<int>(nullable: false),
                    SilverCost = table.Column<int>(nullable: false),
                    WeightInPounds = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AttackBonusMod = table.Column<int>(nullable: false),
                    CampaignSettingId = table.Column<int>(nullable: false),
                    DamageBonusMod = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExtraDamage = table.Column<string>(nullable: true),
                    IsDelisted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SpecifiedPowerAdjustment = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponCharacteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CampaignSettingId = table.Column<int>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Group = table.Column<int>(nullable: false),
                    MaxValue = table.Column<int>(nullable: false),
                    MaxValueFormula = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NonModdable = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    ParentStatId = table.Column<int>(nullable: true),
                    PowerRating = table.Column<int>(nullable: false),
                    Ratio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stat_CampaignSettings_CampaignSettingId",
                        column: x => x.CampaignSettingId,
                        principalTable: "CampaignSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stat_Stat_ParentStatId",
                        column: x => x.ParentStatId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedArmor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ArmorId = table.Column<int>(nullable: false),
                    CreatureId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SelectedAtMS = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedArmor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedArmor_Armor_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedArmor_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WealthAdjustment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AdjustedAtMS = table.Column<long>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    CreatureId = table.Column<int>(nullable: true),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WealthAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WealthAdjustment_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatureId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SelectedAtMS = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedItem_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedCharacteristic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CharacteristicId = table.Column<int>(nullable: false),
                    CreatureId = table.Column<int>(nullable: true),
                    IsTemplateCharacteristic = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TakenAtLevel = table.Column<int>(nullable: false),
                    TakenAtMS = table.Column<long>(nullable: false),
                    TemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedCharacteristic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedCharacteristic_Characteristics_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedCharacteristic_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedCharacteristic_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedSpell",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatureId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SelectedAtLevel = table.Column<int>(nullable: false),
                    SelectedAtMS = table.Column<long>(nullable: false),
                    SpellId = table.Column<int>(nullable: false),
                    TemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedSpell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedSpell_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedSpell_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedSpell_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatureId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SelectedAtMS = table.Column<long>(nullable: false),
                    TemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedTemplate_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedTemplate_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatureId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SelectedAtMS = table.Column<long>(nullable: false),
                    WeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedWeapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedWeapon_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedWeapon_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatMod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CampaignSettingId = table.Column<int>(nullable: true),
                    CampaignSettingId1 = table.Column<int>(nullable: true),
                    CharacteristicId = table.Column<int>(nullable: true),
                    Modifier = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    StatId = table.Column<int>(nullable: false),
                    TemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatMod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatMod_CampaignSettings_CampaignSettingId",
                        column: x => x.CampaignSettingId,
                        principalTable: "CampaignSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatMod_CampaignSettings_CampaignSettingId1",
                        column: x => x.CampaignSettingId1,
                        principalTable: "CampaignSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatMod_Characteristics_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatMod_Stat_StatId",
                        column: x => x.StatId,
                        principalTable: "Stat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatMod_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedSpellCharacteristic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CharacteristicId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SelectedSpellId = table.Column<int>(nullable: true),
                    TakenAtLevel = table.Column<int>(nullable: false),
                    TakenAtMS = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedSpellCharacteristic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedSpellCharacteristic_SpellCharacteristics_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "SpellCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedSpellCharacteristic_SelectedSpell_SelectedSpellId",
                        column: x => x.SelectedSpellId,
                        principalTable: "SelectedSpell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedWeaponCharacteristic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CharacteristicId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SelectedWeaponId = table.Column<int>(nullable: true),
                    TakenAtLevel = table.Column<int>(nullable: false),
                    TakenAtMS = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedWeaponCharacteristic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedWeaponCharacteristic_WeaponCharacteristics_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "WeaponCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedWeaponCharacteristic_SelectedWeapon_SelectedWeaponId",
                        column: x => x.SelectedWeaponId,
                        principalTable: "SelectedWeapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppliedStatMod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AppliedAtLevel = table.Column<int>(nullable: false),
                    AppliedAtUnixMS = table.Column<long>(nullable: false),
                    CreatureId = table.Column<int>(nullable: true),
                    StatModId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedStatMod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppliedStatMod_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppliedStatMod_StatMod_StatModId",
                        column: x => x.StatModId,
                        principalTable: "StatMod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppliedStatMod_CreatureId",
                table: "AppliedStatMod",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedStatMod_StatModId",
                table: "AppliedStatMod",
                column: "StatModId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedArmor_ArmorId",
                table: "SelectedArmor",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedArmor_CreatureId",
                table: "SelectedArmor",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCharacteristic_CharacteristicId",
                table: "SelectedCharacteristic",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCharacteristic_CreatureId",
                table: "SelectedCharacteristic",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCharacteristic_TemplateId",
                table: "SelectedCharacteristic",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedItem_CreatureId",
                table: "SelectedItem",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedItem_ItemId",
                table: "SelectedItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedSpell_CreatureId",
                table: "SelectedSpell",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedSpell_SpellId",
                table: "SelectedSpell",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedSpell_TemplateId",
                table: "SelectedSpell",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedSpellCharacteristic_CharacteristicId",
                table: "SelectedSpellCharacteristic",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedSpellCharacteristic_SelectedSpellId",
                table: "SelectedSpellCharacteristic",
                column: "SelectedSpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedTemplate_CreatureId",
                table: "SelectedTemplate",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedTemplate_TemplateId",
                table: "SelectedTemplate",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedWeapon_CreatureId",
                table: "SelectedWeapon",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedWeapon_WeaponId",
                table: "SelectedWeapon",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedWeaponCharacteristic_CharacteristicId",
                table: "SelectedWeaponCharacteristic",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedWeaponCharacteristic_SelectedWeaponId",
                table: "SelectedWeaponCharacteristic",
                column: "SelectedWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Stat_CampaignSettingId",
                table: "Stat",
                column: "CampaignSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_Stat_ParentStatId",
                table: "Stat",
                column: "ParentStatId");

            migrationBuilder.CreateIndex(
                name: "IX_StatMod_CampaignSettingId",
                table: "StatMod",
                column: "CampaignSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_StatMod_CampaignSettingId1",
                table: "StatMod",
                column: "CampaignSettingId1");

            migrationBuilder.CreateIndex(
                name: "IX_StatMod_CharacteristicId",
                table: "StatMod",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_StatMod_StatId",
                table: "StatMod",
                column: "StatId");

            migrationBuilder.CreateIndex(
                name: "IX_StatMod_TemplateId",
                table: "StatMod",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WealthAdjustment_CreatureId",
                table: "WealthAdjustment",
                column: "CreatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppliedStatMod");

            migrationBuilder.DropTable(
                name: "SelectedArmor");

            migrationBuilder.DropTable(
                name: "SelectedCharacteristic");

            migrationBuilder.DropTable(
                name: "SelectedItem");

            migrationBuilder.DropTable(
                name: "SelectedSpellCharacteristic");

            migrationBuilder.DropTable(
                name: "SelectedTemplate");

            migrationBuilder.DropTable(
                name: "SelectedWeaponCharacteristic");

            migrationBuilder.DropTable(
                name: "WealthAdjustment");

            migrationBuilder.DropTable(
                name: "StatMod");

            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SpellCharacteristics");

            migrationBuilder.DropTable(
                name: "SelectedSpell");

            migrationBuilder.DropTable(
                name: "WeaponCharacteristics");

            migrationBuilder.DropTable(
                name: "SelectedWeapon");

            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "Stat");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Creatures");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "CampaignSettings");
        }
    }
}
