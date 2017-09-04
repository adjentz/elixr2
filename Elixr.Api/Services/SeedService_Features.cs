using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Models;
using System.Linq;
using Elixr2.Api.Services.Seeding.Builders;

namespace Elixr2.Api.Services.Seeding
{
    public partial class SeedService
    {

        private void AddFeatures()
        {
            CharacteristicBuilder builder = new CharacteristicBuilder(standardCampaignSetting);
            var feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Animal Companion")
                    .HasDescriptionFile("Content\\Features\\animal-companion.md")
                    .HasSpecificPowerAdjustment(3)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Cat Like Vision")
                    .HasDescriptionFile("Content\\Features\\cat-like-vision.md")
                    .HasSpecificPowerAdjustment(2)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Darkvision")
                    .HasDescriptionFile("Content\\Features\\darkvision.md")
                    .HasSpecificPowerAdjustment(3)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Cohort")
                    .HasDescriptionFile("Content\\Features\\cohort.md")
                    .HasSpecificPowerAdjustment(5)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Dodge")
                    .HasDescriptionFile("Content\\Features\\dodge.md")
                    .HasSpecificPowerAdjustment(3)
                    .WithMod("Defense", 1)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Echolocation (20 ft)")
                    .HasDescriptionFile("Content\\Features\\echolocation-20ft.md")
                    .HasSpecificPowerAdjustment(5)
                    .Build();
            dbContext.Characteristics.Add(feature);

            for (int i = 1; i <= 5; i++)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                feature = builder.OfType(CharacteristicType.Feature)
                        .HasName($"Fast Healing, {i}")
                        .HasDescriptionFile("Content\\Features\\fast-healing.md")
                        .HasSpecificPowerAdjustment(i * 6)
                        .Build();
                dbContext.Characteristics.Add(feature);
            }


            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Fly")
                    .HasDescriptionFile("Content\\Features\\fly.md")
                    .Build();
            dbContext.Characteristics.Add(feature);

            string[] energyTypes = new string[] { "Fire", "Cold", "Light", "Shadow", "Electric", "Acid", "Sonic" };
            int energyResistancePower = 9;
            foreach (var type in energyTypes)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                feature = builder.OfType(CharacteristicType.Feature)
                        .HasName($"Resistance, {type}")
                        .HasDescriptionFile("Content\\Features\\resistance-attack.md", type)
                        .HasSpecificPowerAdjustment(energyResistancePower)
                        .Build();
                dbContext.Characteristics.Add(feature);

                builder = new CharacteristicBuilder(standardCampaignSetting);
                feature = builder.OfType(CharacteristicType.Feature)
                        .HasName($"Immunity, {type}")
                        .HasDescriptionFile("Content\\Features\\immunity-attack.md", type)
                        .HasSpecificPowerAdjustment(energyResistancePower * 2)
                        .Build();
                dbContext.Characteristics.Add(feature);
            }

            

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Resistance, Energy")
                    .HasDescriptionFile("Content\\Features\\resistance-attack.md", string.Join(", ", energyTypes))
                    .HasSpecificPowerAdjustment(energyTypes.Length * energyResistancePower)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Immunity, All Poison")
                    .HasDescriptionFile("Content\\Features\\immunity-all-poison.md")
                    .HasSpecificPowerAdjustment(9)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Immunity, Poison")
                    .HasDescriptionFile("Content\\Features\\immunity-poison.md")
                    .HasSpecificPowerAdjustment(6)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Resistance, Poison")
                    .HasDescriptionFile("Content\\Features\\resistance-poison.md")
                    .HasSpecificPowerAdjustment(3)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Resistance, Mind-Affecting")
                    .HasDescriptionFile("Content\\Features\\resistance-mind-affecting.md")
                    .HasSpecificPowerAdjustment(8)
                    .Build();
            dbContext.Characteristics.Add(feature);


            string[] physicalTypes = new string[] { "Piercing", "Bludgeoning", "Slashing" };
            foreach (var type in physicalTypes)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                feature = builder.OfType(CharacteristicType.Feature)
                        .HasName($"Resistance, {type}")
                        .HasDescriptionFile("Content\\Features\\resistance-attack.md", type)
                        .HasSpecificPowerAdjustment(10)
                        .Build();
                dbContext.Characteristics.Add(feature);

                builder = new CharacteristicBuilder(standardCampaignSetting);
                feature = builder.OfType(CharacteristicType.Feature)
                        .HasName($"Immunity, {type}")
                        .HasDescriptionFile("Content\\Features\\immunity-attack.md", type)
                        .HasSpecificPowerAdjustment(20)
                        .Build();
                dbContext.Characteristics.Add(feature);
            }

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Resistance, Physical")
                    .HasDescriptionFile("Content\\Features\\resistance-attack.md", "Bludgeoning, Piercing, or Slashing")
                    .HasSpecificPowerAdjustment(30)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                     .HasName("Learn Spell")
                     .HasDescriptionFile("Content\\Features\\learn-spell.md")
                     .HasSpecificPowerAdjustment(1)
                     .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Leech")
                    .HasDescriptionFile("Content\\Features\\leech.md")
                    .HasSpecificPowerAdjustment(12)
                    .Build();
            dbContext.Characteristics.Add(feature);


            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Speak Language")
                    .HasDescriptionFile("Content\\Features\\speak-language.md")
                    .HasSpecificPowerAdjustment(1)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Speed")
                    .WithMod("Speed", 5)
                    .HasDescriptionFile("Content\\Features\\speed.md")
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Two Weapon Training")
                    .HasDescriptionFile("Content\\Features\\two-weapon-training.md")
                    .HasSpecificPowerAdjustment(7)
                    .Build();
            dbContext.Characteristics.Add(feature);


            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Vitality")
                    .HasDescriptionFile("Content\\Features\\vitality.md")
                    .WithMod("Energy", 3)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Natural Flyer")
                    .HasDescriptionFile("Content\\Features\\natural-flyer.md")
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Natural Swimmer")
                    .HasDescriptionFile("Content\\Features\\natural-swimmer.md")
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Tremorsense, 30ft")
                    .HasDescriptionFile(@"Content\Features\tremorsense.md", 30)
                    .HasSpecificPowerAdjustment(3)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Tremorsense, 60ft")
                    .HasDescriptionFile(@"Content\Features\tremorsense.md", 60)
                    .HasSpecificPowerAdjustment(6)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Immunity, Mind-Affecting")
                    .HasDescriptionFile(@"Content\Features\immunity-mind-affecting.md")
                    .HasSpecificPowerAdjustment(13)
                    .Build());


            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Camoflage")
                    .HasDescriptionFile(@"Content\Features\camoflage.md")
                    .HasSpecificPowerAdjustment(2)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Ferocity")
                    .HasDescriptionFile(@"Content\Features\ferocity.md")
                    .HasSpecificPowerAdjustment(3)
                    .Build());

            for (int i = 1; i <= 12; i++)
            {
                int feet = i * 10;
                builder = new CharacteristicBuilder(standardCampaignSetting);
                dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                        .HasName($"Blindsight, {feet}ft")
                        .HasDescriptionFile(@"Content\Features\blind-sight.md", $"{feet}ft")
                        .HasSpecificPowerAdjustment(feet / 5)
                        .Build());
            }

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Ignores Critical Damage")
                    .HasDescription("Extra damage from a critical hit is automatically negated. Any damage the weapon deals normally is still applied.")
                    .HasSpecificPowerAdjustment(5)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Can't Be Flanked")
                    .HasDescription("Being surrounded by opponents does not grant them Advantage when making attacks.")
                    .HasSpecificPowerAdjustment(5)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Smite Foe")
                    .HasDescriptionFile(@"Content\Features\smite-foe.md")
                    .HasSpecificPowerAdjustment(4)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Blind Fight")
                    .HasDescriptionFile(@"Content\Features\blind-fight.md")
                    .HasSpecificPowerAdjustment(4)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Amphibious")
                    .HasDescription(@"A creature with this Feature can survive indefinitely both in land and water.")
                    .HasSpecificPowerAdjustment(1)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Combat Casting")
                    .HasDescriptionFile(@"Content\Features\combat-casting.md")
                    .HasSpecificPowerAdjustment(3)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Spell Defense")
                    .HasDescriptionFile(@"Content\Features\spell-defense.md")
                    .HasSpecificPowerAdjustment(6)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Spell Resistance")
                    .HasDescriptionFile(@"Content\Features\spell-resistance.md")
                    .HasSpecificPowerAdjustment(3)
                    .Build());

            for (int i = 0; i < 12; i++)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                        .HasName($"Lifesense, {(i + 1) * 5}ft")
                        .HasDescriptionFile("Content\\Features\\lifesense.md")
                        .HasSpecificPowerAdjustment(8 + i)
                        .Build());
            }
            for (int i = 0; i < 5; i++)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                        .HasName($"Regeneration, {i + 1}")
                        .HasDescriptionFile("Content\\Features\\regeneration.md", i + 1)
                        .HasSpecificPowerAdjustment(8 + i)
                        .Build());
            }

        }
    }
}