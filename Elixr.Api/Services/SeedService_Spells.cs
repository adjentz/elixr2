using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Models;
using System.Linq;
using Elixr2.Api.Services.Seeding.Builders;

namespace Elixr2.Api.Services.Seeding
{
    public partial class SeedService
    {
        private void AddSpells()
        {
            AddSpellCharacteristics();

            SpellBuilder builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Automate")
                                .HasDescriptionFile("Content\\Spells\\automate.md")
                                .HasEnergyRequirement("Proportional to how hard it would be to do manually.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Clairvoyance")
                                .HasDescriptionFile("Content\\Spells\\clairvoyance.md")
                                .HasEnergyRequirement("1d6/Channeled to overcome a creature's Concentration Defense.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Compel")
                                .HasDescriptionFile("Content\\Spells\\compel.md")
                                .HasEnergyRequirement("1d6/Channeled to overcome a creature's Concentration Defense.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Conjure Object")
                                .HasDescriptionFile("Content\\Spells\\conjure-object.md")
                                .HasEnergyRequirement("1 per 5 pounds of mass conjured.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Divinate")
                                .HasDescriptionFile("Content\\Spells\\divinate.md")
                                .HasEnergyRequirement("1d4/Channeled to discern information.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            string[] energyTypes = new string[] { "Light", "Shadow", "Fire", "Cold", "Electric", "Acid" };
            foreach (var type in energyTypes)
            {
                builder = new SpellBuilder(standardCampaignSetting);
                dbContext.Spells.Add(builder.HasName($"Energy Blast, {type}")
                                    .HasDescriptionFile("Content\\Spells\\energy-blast.md")
                                    .HasEnergyRequirement("Up to Current Energy")
                                    .MarkConcentration(false)
                                    .MarkDoesDamage(true)
                                    .Build());
            }

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Fly")
                                .HasDescriptionFile("Content\\Spells\\fly.md")
                                .HasEnergyRequirement("1 per 5ft of flying you wish to do.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Illusion")
                                .HasDescriptionFile("Content\\Spells\\illusion.md")
                                .HasEnergyRequirement("1d6/Channeled to overcome a creature's Concentration Defense.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Invisibility")
                                .HasDescriptionFile("Content\\Spells\\illusion.md")
                                .HasEnergyRequirement("1 / 200 pounds of mass you want to turn invisible.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Mind Read")
                                .HasDescriptionFile("Content\\Spells\\mind-read.md")
                                .HasEnergyRequirement("1d6/Channeled to overcome a creature's Concentration Defense.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Necromancy")
                                .HasDescriptionFile("Content\\Spells\\necromancy.md")
                                .HasEnergyRequirement("2 for every corpse/skeleton you wish to animate.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Plane Shift")
                                .HasDescriptionFile("Content\\Spells\\plane-shift.md")
                                .HasEnergyRequirement("1 for every 100 pounds of mass you wish to shift.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Plane Anchor")
                                .HasDescriptionFile("Content\\Spells\\plane-shift.md")
                                .HasEnergyRequirement("1/5ft of radius the anchor extends.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Resurrect")
                                .HasDescriptionFile("Content\\Spells\\resurrect.md")
                                .HasEnergyRequirement("What you want the target's new Max Energy to be. See Description.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Reveal")
                                .HasDescriptionFile("Content\\Spells\\reveal.md")
                                .HasEnergyRequirement("1d6/Channeled to overcome a creature's Concentration Defense.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Reveal")
                                .HasDescriptionFile("Content\\Spells\\reveal.md")
                                .HasEnergyRequirement("1d6/Channeled to overcome a creature's Concentration Defense.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            string[] entities = new string[] { "Animals", "Plants", "Dead" };
            foreach (var entity in entities)
            {
                builder = new SpellBuilder(standardCampaignSetting);
                dbContext.Spells.Add(builder.HasName($"Speak with Entity, {entity}")
                                    .HasDescriptionFile("Content\\Spells\\speak-with-entity.md")
                                    .HasEnergyRequirement("1 per hour into the past you want the entity to be able to remember.")
                                    .MarkConcentration(true)
                                    .MarkDoesDamage(false)
                                    .Build());
            }

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Spider Walk")
                                .HasDescriptionFile("Content\\Spells\\spider-walk.md")
                                .HasEnergyRequirement("1 per 5ft of surface you want to walk up.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Telekinesis")
                                .HasDescriptionFile("Content\\Spells\\telekinesis.md")
                                .HasEnergyRequirement("1 per 10lbs of mass you want to move.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(true)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Telepathy")
                                .HasDescriptionFile("Content\\Spells\\telepathy.md")
                                .HasEnergyRequirement("1 per creature beyond yourself involved in the telpathic link.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Teleport")
                                .HasDescriptionFile("Content\\Spells\\teleport.md")
                                .HasEnergyRequirement("1 per 200 pounds of mass you want to transport.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Tongues")
                                .HasDescriptionFile("Content\\Spells\\tongues.md")
                                .HasEnergyRequirement("1 per language you want to understand/speak.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Transfer Energy")
                                .HasDescriptionFile("Content\\Spells\\transfer-energy.md")
                                .HasEnergyRequirement("Equal to the amount of Energy you want to transfer.")
                                .MarkConcentration(false)
                                .MarkDoesDamage(true)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Transmute Object")
                                .HasDescriptionFile("Content\\Spells\\transmute-object.md")
                                .HasEnergyRequirement("1 per 10 pounds of mass you want to transmute.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Wild Shape")
                                .HasDescriptionFile("Content\\Spells\\transmute-object.md")
                                .HasEnergyRequirement("Equal to the Power of the Creature, divided by 10.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Wild Shape")
                                .HasDescriptionFile("Content\\Spells\\transmute-object.md")
                                .HasEnergyRequirement("Equal to the Power of the Creature, divided by 10.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Daylight")
                                .HasDescriptionFile("Content\\Spells\\daylight.md")
                                .HasEnergyRequirement("1 for every 5ft of radius you want the spell to have.")
                                .MarkConcentration(false)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Darkness")
                                .HasDescriptionFile("Content\\Spells\\darkness.md")
                                .HasEnergyRequirement("1 for every 5ft of radius you want the spell to have.")
                                .MarkConcentration(false)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Gust")
                                .HasDescriptionFile("Content\\Spells\\gust.md")
                                .HasEnergyRequirement("1d4/Energy Channeled to overcome Acrobatics Defense")
                                .MarkConcentration(false)
                                .MarkDoesDamage(true)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Blur")
                                .HasDescriptionFile("Content\\Spells\\blur.md")
                                .HasEnergyRequirement("1 for every 5% of concealment")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Fog Cloud")
                                .HasDescriptionFile(@"Content\Spells\fog-cloud.md")
                                .HasEnergyRequirement("1/diameter of cloud")
                                .MarkConcentration(false)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Entangle")
                                .HasDescriptionFile(@"Content\Spells\entangle.md")
                                .HasEnergyRequirement("1/1d6 to overcome Acrobatics Defense.")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Detect Energy")
                                .HasDescriptionFile(@"Content\Spells\detect-energy.md")
                                .HasEnergyRequirement("At least 1/2 the source's Energy")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Confusion")
                                .HasDescriptionFile(@"Content\Spells\confusion.md")
                                .HasEnergyRequirement("1d4/Channeled to overcome a target's Concentration Defense")
                                .MarkConcentration(false)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Hypnotism")
                                .HasDescriptionFile(@"Content\Spells\hypnotism.md")
                                .HasEnergyRequirement("1d4/Channeled to overcome a target's Concentration Defense")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Mage Armor")
                                .HasDescriptionFile(@"Content\Spells\mage-armor.md")
                                .HasEnergyRequirement("3/+1 to Defense")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Sleep")
                                .HasDescriptionFile(@"Content\Spells\sleep.md")
                                .HasEnergyRequirement("1/1d6 to overcome Concentration Defense")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Ward")
                                .HasDescriptionFile(@"Content\Spells\ward.md") // similar to "resistance"
                                .HasEnergyRequirement("2/+1 to a Skill Defense")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Daze")
                                .HasDescriptionFile(@"Content\Spells\daze.md")
                                .HasEnergyRequirement("1/1d6 to overcome Concentration Defense")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Charm")
                                .HasDescriptionFile(@"Content\Spells\charm.md")
                                .HasEnergyRequirement("1/1d8 to overcome target's Concentration Defense")
                                .MarkConcentration(false)
                                .MarkDoesDamage(false)
                                .Build());


            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Despair")
                                .HasDescriptionFile(@"Content\Spells\despair.md")
                                .HasEnergyRequirement("1/5ft of radius")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Hope")
                                .HasDescriptionFile(@"Content\Spells\hope.md")
                                .HasEnergyRequirement("1/5ft of radius")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Gaseous Form")
                                .HasDescriptionFile(@"Content\Spells\gaseous-form.md")
                                .HasEnergyRequirement("1/Creature made gaseous")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Blink")
                                .HasDescriptionFile(@"Content\Spells\blink.md")
                                .HasEnergyRequirement("1/5% of concealment gained")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Ice Wall")
                                .HasDescriptionFile(@"Content\Spells\ice-wall.md")
                                .HasEnergyRequirement("1/5ft² of wall created")
                                .MarkConcentration(false)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Detect Thoughts")
                                .HasDescriptionFile(@"Content\Spells\detect-thoughts.md")
                                .HasEnergyRequirement("1/1d8 to overcome target's Concentration Defense")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

            builder = new SpellBuilder(standardCampaignSetting);
            dbContext.Spells.Add(builder.HasName("Buff")
                                .HasDescriptionFile(@"Content\Spells\buff.md")
                                .HasEnergyRequirement("3/+1 to Ability Score")
                                .MarkConcentration(true)
                                .MarkDoesDamage(false)
                                .Build());

                                //TODO: Debuff, maybe?
        }

        private void AddSpellCharacteristics()
        {
            var builder = new SpellCharacteristicBuilder(standardCampaignSetting);
            dbContext.SpellCharacteristics.Add(builder.HasName("At Will Spell")
                                                       .HasSpecificPower(3)
                                                       .HasDescriptionFile(@"Content\Features\at-will-spell.md")
                                                       .Build());

            builder = new SpellCharacteristicBuilder(standardCampaignSetting);
            dbContext.SpellCharacteristics.Add(builder.HasName("Silent Spell")
                                                       .HasSpecificPower(2)
                                                       .HasDescriptionFile("Content\\Features\\silent-spell.md")
                                                       .Build());

            builder = new SpellCharacteristicBuilder(standardCampaignSetting);
            dbContext.SpellCharacteristics.Add(builder.HasName("Still Spell")
                                                       .HasSpecificPower(2)
                                                       .HasDescriptionFile("Content\\Features\\still-spell.md")
                                                       .Build());
        }
    }
}