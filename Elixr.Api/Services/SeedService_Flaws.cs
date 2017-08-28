using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Models;
using System.Linq;
using Elixr2.Api.Services.Seeding.Builders;

namespace Elixr2.Api.Services.Seeding
{
    public partial class SeedService
    {
        private void AddFlaws()
        {
            CharacteristicBuilder builder = new CharacteristicBuilder(standardCampaignSetting);
            var flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Bulky")
                    .HasDescriptionFile("Content\\Flaws\\bulky.md")
                    .WithMod("Speed", -5)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Blind")
                    .HasDescriptionFile("Content\\Flaws\\blind.md")
                    .HasSpecificPowerAdjustment(-8)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Deaf")
                    .HasDescriptionFile("Content\\Flaws\\deaf.md")
                    .HasSpecificPowerAdjustment(-5)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Illiterate")
                    .HasDescriptionFile("Content\\Flaws\\illiterate.md")
                    .HasSpecificPowerAdjustment(-1)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Light Sensitivity")
                    .HasDescriptionFile("Content\\Flaws\\light-sensitivity.md")
                    .HasSpecificPowerAdjustment(-2)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Gruff")
                    .HasDescriptionFile("Content\\Flaws\\gruff.md")
                    .WithMod("Charm Score", -2)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Large")
                    .WithMod("Racial Strength Score", 2)
                    .WithMod("Racial Agility Score", -2)
                    .WithMod("Speed", 10)
                    .WithMod("Defense", -1)
                    .WithMod("Stealth Misc.", -2)
                    .HasDescriptionFile("Content\\Flaws\\large.md")
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Huge")
                    .HasDescriptionFile("Content\\Flaws\\huge.md")
                    .WithMod("Racial Strength Score", 4)
                    .WithMod("Racial Agility Score", -4)
                    .WithMod("Speed", 20)
                    .WithMod("Defense", -2)
                    .WithMod("Stealth Misc.", -4)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Gargantuan")
                    .HasDescriptionFile("Content\\Flaws\\gargantuan.md")
                    .WithMod("Racial Strength Score", 8)
                    .WithMod("Racial Agility Score", -8)
                    .WithMod("Speed", 40)
                    .WithMod("Defense", -4)
                    .WithMod("Stealth Misc.", -8)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Colossal")
                    .HasDescriptionFile("Content\\Flaws\\colossal.md")
                    .WithMod("Racial Strength Score", 16)
                    .WithMod("Racial Agility Score", -16)
                    .WithMod("Speed", 80)
                    .WithMod("Defense", -8)
                    .WithMod("Stealth Misc.", -16)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Small")
                    .HasDescriptionFile("Content\\Flaws\\small.md")
                    .WithMod("Racial Strength Score", -2)
                    .WithMod("Racial Agility Score", 2)
                    .WithMod("Speed", -10)
                    .WithMod("Defense", 1)
                    .WithMod("Stealth Misc.", 2)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Tiny")
                    .HasDescriptionFile("Content\\Flaws\\tiny.md")
                    .WithMod("Racial Strength Score", -4)
                    .WithMod("Racial Agility Score", 4)
                    .WithMod("Speed", -20)
                    .WithMod("Defense", 2)
                    .WithMod("Stealth Misc.", 4)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Minute")
                    .HasDescriptionFile("Content\\Flaws\\minute.md")
                    .WithMod("Racial Strength Score", -8)
                    .WithMod("Racial Agility Score", 8)
                    .WithMod("Stealth Misc.", 8)
                    .WithMod("Speed", -40)
                    .WithMod("Defense", 4)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Unappealing")
                    .HasDescriptionFile("Content\\Flaws\\unappealing.md")
                    .WithMod("Charm Score", -2)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Weak Constitution")
                    .WithMod("Energy", -2)
                    .HasDescriptionFile("Content\\Flaws\\weak-constitution.md")
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Gimped")
                    .HasDescription("Travelling 5ft has a Movement Speed cost of 30ft.\n\nNormally travelling has a 1:1 with its Movement Speed (e.g. moving 10ft costs 10ft)")
                    .HasSpecificPowerAdjustment(-20)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Aversion")
                    .HasDescriptionFile(@"Content\Flaws\aversion.md")
                    .HasSpecificPowerAdjustment(-6)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            flaw = builder.OfType(CharacteristicType.Flaw)
                    .HasName("Vulnerability, Material")
                    .HasDescription("A weapon coated in the specified material deals double damage against you.")
                    .HasSpecificPowerAdjustment(-8)
                    .Build();
            dbContext.Characteristics.Add(flaw);

            string[] energyTypes = new string[] { "Fire", "Cold", "Light", "Shadow", "Electric", "Acid" };
            foreach (var type in energyTypes)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                flaw = builder.OfType(CharacteristicType.Flaw)
                        .HasName($"Vulnerability, {type}")
                        .HasDescriptionFile("Content\\Flaws\\vulnerability-energy.md")
                        .HasSpecificPowerAdjustment(-9)
                        .Build();
                dbContext.Characteristics.Add(flaw);
            }
        }
    }
}