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
            AddSkillFeatures();
            AddAbilityFeatures();

            CharacteristicBuilder builder = new CharacteristicBuilder(standardCampaignSetting);
            var feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Animal Companion")
                    .HasDescriptionFile("Content\\Features\\animal-companion.md")
                    .HasSpecificCombatPower(2)
                    .HasSpecificEnvironmentPower(1)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Cohort")
                    .HasDescriptionFile("Content\\Features\\cohort.md")
                    .HasSpecificCombatPower(5)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName(Features.LowLightVision)
                    .HasDescriptionFile("Content\\Features\\low-light-vision.md") // todo power scaling
                    .HasSpecificEnvironmentPower(CampaignSetting.DetectionScalePer10Ft * 1)
                    .WithCondition("A source of light must still exist", 0, 1, 0)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Darkvision") // todo: power scaling
                    .HasDescriptionFile("Content\\Features\\darkvision.md")
                    .HasSpecificEnvironmentPower(CampaignSetting.DetectionScalePer10Ft * 5)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Dodge")
                    .HasDescriptionFile("Content\\Features\\dodge.md")
                    .HasSpecificCombatPower(CampaignSetting.DefenseScale)
                    .WithCondition("Must specify subject", -1, 0, 0)
                    .WithCondition("Any time you lose your Agility Bonus to your Defense (such as being caught unaware), this effect is also lost.")
                    .AsUpgradable("Each time this Feature is upgraded, an additional subject may be selected", 1)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Echolocation")
                    .HasDescriptionFile("Content\\Features\\echolocation.md")
                    .HasSpecificEnvironmentPower(CampaignSetting.DetectionScalePer10Ft)
                    .WithCondition("Doesn't reveal color", 0, 1, 0);
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Fast Healing")
                    .HasDescriptionFile("Content\\Features\\fast-healing.md")
                    .HasSpecificCombatPower(CampaignSetting.EnergyScale * (int)CampaignSetting.RepeatingMultiplier.OncePerRound)
                    .AsUpgradable("The creature this is applied to heals for an additional 1 point of Energy for every time this Feature is upgraded.", CampaignSetting.EnergyScale * (int)CampaignSetting.RepeatingMultiplier.OncePerRound)
                    .Build();
            dbContext.Characteristics.Add(feature);


            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Fly")
                    .HasDescriptionFile("Content\\Features\\fly.md")
                    .HasSpecificEnvironmentPower(CampaignSetting.FlyScalePer10ft)
                    .AsUpgradable("The creature this applies to can fly an additional 10ft per turn", 0, CampaignSetting.FlyScalePer10ft)
                    .Build();
            dbContext.Characteristics.Add(feature);

            string[] energyTypes = new string[] { "Fire", "Cold", "Light", "Shadow", "Electric", "Acid", "Sonic" };
            foreach (var type in energyTypes)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                feature = builder.OfType(CharacteristicType.Feature)
                        .HasName($"Resistance, {type}")
                        .HasDescriptionFile("Content\\Features\\resistance-attack.md", type)
                        .HasSpecificCombatPower(CampaignSetting.ResistanceEnergy)
                        .Build();
                dbContext.Characteristics.Add(feature);


                builder = new CharacteristicBuilder(standardCampaignSetting);
                feature = builder.OfType(CharacteristicType.Feature)
                        .HasName($"Immunity, {type}")
                        .HasDescriptionFile("Content\\Features\\immunity-attack.md", type)
                        .HasSpecificCombatPower(CampaignSetting.ImmunityEnergy)
                        .Build();
                dbContext.Characteristics.Add(feature);
            }

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Resistance, Energy")
                    .HasDescriptionFile("Content\\Features\\resistance-attack.md", string.Join(", ", energyTypes))
                    .HasSpecificCombatPower(energyTypes.Length * CampaignSetting.ResistanceEnergy)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Immunity, All Poison")
                    .HasDescriptionFile("Content\\Features\\immunity-all-poison.md")
                    .HasSpecificCombatPower(CampaignSetting.ImmunityAnyPoision)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Immunity, Poison")
                    .HasDescriptionFile("Content\\Features\\immunity-poison.md")
                    .HasSpecificCombatPower(CampaignSetting.ImmunityPoision)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Resistance, Poison")
                    .HasDescriptionFile("Content\\Features\\resistance-poison.md")
                    .HasSpecificCombatPower(CampaignSetting.ResistancePoison)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Resistance, Mind-Affecting")
                    .HasDescriptionFile("Content\\Features\\resistance-mind-affecting.md")
                    .HasSpecificCombatPower(CampaignSetting.ResistanceMindAffecting)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Immunity, Mind-Affecting")
                    .HasDescriptionFile(@"Content\Features\immunity-mind-affecting.md")
                    .HasSpecificCombatPower(CampaignSetting.ImmunityMindAffecting)
                    .Build());


            string[] physicalTypes = new string[] { "Piercing", "Bludgeoning", "Slashing" };
            foreach (var type in physicalTypes)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                feature = builder.OfType(CharacteristicType.Feature)
                        .HasName($"Resistance, {type}")
                        .HasDescriptionFile("Content\\Features\\resistance-attack.md", type)
                        .HasSpecificCombatPower(CampaignSetting.ResistancePhysical)
                        .Build();
                dbContext.Characteristics.Add(feature);

                builder = new CharacteristicBuilder(standardCampaignSetting);
                feature = builder.OfType(CharacteristicType.Feature)
                        .HasName($"Immunity, {type}")
                        .HasDescriptionFile("Content\\Features\\immunity-attack.md", type)
                        .HasSpecificCombatPower(CampaignSetting.ImmunityPhysical)
                        .Build();
                dbContext.Characteristics.Add(feature);
            }

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName($"Resistance, Physical")
                    .HasDescriptionFile("Content\\Features\\resistance-attack.md", "Bludgeoning, Piercing, or Slashing")
                    .HasSpecificCombatPower(CampaignSetting.ResistancePhysical * physicalTypes.Length)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                     .HasName("Learn Spell")
                     .HasDescriptionFile("Content\\Features\\learn-spell.md")
                     .HasSpecificCombatPower(CampaignSetting.LearnSpell)
                     .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Speak Language")
                    .HasDescriptionFile("Content\\Features\\speak-language.md")
                    .HasSpecificPresencePower(CampaignSetting.SpeakLanguageScale)
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Speed")
                    .WithMod("Speed", CampaignSetting.SpeedScalePer5ft)
                    .HasDescriptionFile("Content\\Features\\speed.md")
                    .Build();
            dbContext.Characteristics.Add(feature);

            builder = new CharacteristicBuilder(standardCampaignSetting);
            feature = builder.OfType(CharacteristicType.Feature)
                    .HasName("Vitality")
                    .HasDescriptionFile("Content\\Features\\vitality.md")
                    .WithMod("Energy", CampaignSetting.EnergyScale)
                    .AsUpgradable("Your Max Energy is increased an additional 1 point.", CampaignSetting.EnergyScale, 0, 0, 3)
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
                    .HasName("Tremorsense")
                    .HasDescriptionFile(@"Content\Features\tremorsense.md")
                    .HasSpecificEnvironmentPower(CampaignSetting.DetectionScalePer10Ft)
                    .AsUpgradable("Range is increased an additional 10ft")
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Camoflage")
                    .HasDescriptionFile(@"Content\Features\camoflage.md")
                    .HasSpecificEnvironmentPower(2)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Ferocity")
                    .HasDescriptionFile(@"Content\Features\ferocity.md")
                    .HasSpecificCombatPower(3)
                    .Build());

            for (int i = 1; i <= 12; i++)
            {
                int feet = i * 10;
                builder = new CharacteristicBuilder(standardCampaignSetting);
                dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                        .HasName($"Blindsight, {feet}ft")
                        .HasDescriptionFile(@"Content\Features\blind-sight.md", $"{feet}ft")
                        .HasSpecificEnvironmentPower(feet / 5)
                        .Build());
            }

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Ignores Critical Damage")
                    .HasDescription("Extra damage from a critical hit is automatically negated. Any damage the weapon deals normally is still applied.")
                    .HasSpecificCombatPower(5)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Can't Be Flanked")
                    .HasDescription("Being surrounded by opponents does not grant them Advantage when making attacks.")
                    .HasSpecificCombatPower(5)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Smite Foe")
                    .HasDescriptionFile(@"Content\Features\smite-foe.md")
                    .HasSpecificCombatPower(4)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Blind Fight")
                    .HasDescriptionFile(@"Content\Features\blind-fight.md")
                    .HasSpecificCombatPower(4)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Amphibious")
                    .HasDescription(@"A creature with this Feature can survive indefinitely both in land and water.")
                    .HasSpecificEnvironmentPower(1)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Combat Casting")
                    .HasDescriptionFile(@"Content\Features\combat-casting.md")
                    .HasSpecificCombatPower(3)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Spell Defense")
                    .HasDescriptionFile(@"Content\Features\spell-defense.md")
                    .HasSpecificCombatPower(6)
                    .Build());

            builder = new CharacteristicBuilder(standardCampaignSetting);
            dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                    .HasName("Spell Resistance")
                    .HasDescriptionFile(@"Content\Features\spell-resistance.md")
                    .HasSpecificCombatPower(15)
                    .Build());

            for (int i = 0; i < 12; i++)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                        .HasName($"Lifesense, {(i + 1) * 5}ft")
                        .HasDescriptionFile("Content\\Features\\lifesense.md")
                        .HasSpecificEnvironmentPower(8 + i)
                        .Build());
            }
            for (int i = 0; i < 5; i++)
            {
                builder = new CharacteristicBuilder(standardCampaignSetting);
                dbContext.Characteristics.Add(builder.OfType(CharacteristicType.Feature)
                        .HasName($"Regeneration, {i + 1}")
                        .HasDescriptionFile("Content\\Features\\regeneration.md", i + 1)
                        .HasSpecificCombatPower(8 + i)
                        .Build());
            }

        }

        private void AddSkillFeatures()
        {

            CharacteristicBuilder builder = new CharacteristicBuilder(standardCampaignSetting);

            var skillMiscs = standardCampaignSetting.Stats.Where(s => s.Group == StatGroup.SkillMisc);
            var skillFeatures = skillMiscs.Select(s =>
            builder.HasName($"Increase {s.DisplayName}")
                   .WithMod(new StatMod(s.Id, 1, $"Feature: Increase {s.DisplayName}")).Build());

            dbContext.Characteristics.AddRange(skillFeatures);
        }

        private void AddAbilityFeatures()
        {
            CharacteristicBuilder builder = new CharacteristicBuilder(standardCampaignSetting);

            var abilities = standardCampaignSetting.Stats.Where(s => s.Group == StatGroup.Ability);
            var abilityFeatures = abilities.Select(a => builder.HasName($"Increase {a.DisplayName}").WithMod(new StatMod(a.Id, 1, $"Feature: Increase {a.DisplayName}")).Build());
            dbContext.Characteristics.AddRange(abilityFeatures);
        }
    }
}