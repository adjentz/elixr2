using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Models;
using System.Linq;
using Elixr2.Api.Services.Seeding.Builders;
using System.Collections.Generic;

namespace Elixr2.Api.Services.Seeding
{
    public partial class SeedService
    {

        private void AddTemplates(List<Characteristic> characteristics, List<Spell> spells, List<SpellCharacteristic> spellCharacteristics)
        {
            TemplateBuilder builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Elf")
                                  .HasDescriptionFile("Content\\Templates\\elf.md")
                                  .AsRace(true)
                                  .WithMod("Racial Agility Score", 2)
                                  .WithMod("Energy", -2)
                                  .WithCharacteristic("Speak Language", "Elvish")
                                  .WithCharacteristic("Cat Like Vision")
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Dwarf")
                                  .HasDescriptionFile("Content\\Templates\\dwarf.md")
                                  .AsRace(true)
                                  .WithMod("Speed", -5)
                                  .WithMod("Racial Charm Score", -2)
                                  .WithMod("Racial Strength Score", 2)
                                  .WithCharacteristic("Speak Language", "Dwarvish")
                                  .WithCharacteristic("Darkvision")
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Gnome")
                                  .HasDescriptionFile("Content\\Templates\\gnome.md")
                                  .AsRace(true)
                                  .WithMod("Racial Focus Score", 2)
                                  .WithCharacteristic("Small")
                                  .WithCharacteristic("Cat Like Vision")
                                  .WithCharacteristic("Speak Language", "Gnomish")
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Orc")
                                  .HasDescriptionFile("Content\\Templates\\orc.md")
                                  .AsRace(true)
                                  .WithMod("Racial Strength Score", 2)
                                  .WithMod("Racial Charm Score", -4)
                                  .WithCharacteristic("Darkvision")
                                  .WithCharacteristic("Speak Language", "Orcish")
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Halfling")
                                  .HasDescriptionFile("Content\\Templates\\halfling.md")
                                  .AsRace(true)
                                  .WithMod("Racial Charm Score", 2)
                                  .WithMod("Sleight of Hand Misc.", 1)
                                  .WithMod("Insight Misc.", 1)
                                  .WithCharacteristic("Small")
                                  .Build());

            //Humans might be proficient in any ability
            Dictionary<string, string> abilityDescriptions = new Dictionary<string, string>()
            {
                    {"Strength", "Strong"},
                    {"Agility", "Fast"},
                    {"Focus", "Smart"},
                    {"Charm", "Charismatic"},
            };
            foreach (var ability in abilityDescriptions.Keys)
            {
                builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
                dbContext.Templates.Add(builder.HasName($"Human, {abilityDescriptions[ability]}")
                                      .HasDescriptionFile("Content\\Templates\\human.md")
                                      .AsRace(true)
                                      .WithMod($"Racial {ability} Score", 2)
                                      .Build());
            }

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Aasimar")
                                  .HasDescriptionFile("Content\\Templates\\aasimar.md")
                                  .AsRace(true)
                                  .WithMod($"Racial Charm Score", 2)
                                  .WithMod($"Racial Charm Score", 2)
                                  .WithCharacteristic("Darkvision")
                                  .WithCharacteristic("Resistance, Acid")
                                  .WithCharacteristic("Resistance, Electric")
                                  .WithCharacteristic("Resistance, Cold")
                                  .WithSpell("Daylight")
                                  .WithSpellCharacteristic("Daylight", "At Will Spell")
                                  .WithMod("Perception Misc.", 2)
                                  .WithCharacteristic("Speak Language", "Celestial")
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Incorporeal")
                                  .HasDescriptionFile(@"Content\Templates\Incorporeal\description.md")
                                  .WithCharacteristic("Immunity, Slashing")
                                  .WithCharacteristic("Immunity, Piercing")
                                  .WithCharacteristic("Immunity, Bludgeoning")
                                  .WithSpecialCharacteristic("Pass Through Objects", @"Content\Templates\Incorporeal\pass-through-objects.md", 2)
                                  .WithSpecialCharacteristic("Ethreal Touch", @"Content\Templates\Incorporeal\ethreal-touch.md", 5)
                                  .WithSpecialCharacteristic("Traceless", @"Content\Templates\Incorporeal\traceless.md", 2) //silent, can't be smelled
                                  .WithSpecialCharacteristic("Strengthless", @"Content\Templates\Incorporeal\strengthless.md", -4, CharacteristicType.Flaw)
                                  .WithCharacteristic("Lifesense, 5ft")
                                  .WithCharacteristic("Aversion", "Salt")
                                  .AsRace(false)
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Plant")
                                  .HasDescription("This type comprises vegetable creatures.")
                                  .WithCharacteristic("Cat Like Vision")
                                  .WithCharacteristic("Immunity, Mind-Affecting")
                                  .WithCharacteristic("Immunity, All Poison")
                                  .WithSpecialCharacteristic("Plant Traits", "Cannot be paralyzed, stunned, polymorphed or affected by sleep effects.\n\nPlants do not sleep, but do need to breath and eat.", 4)
                                  .AsRace(false)
                                  .Build());

            var vulnerabilityLight = characteristics.FirstOrDefault(c => c.Name.ToLower() == "vulnerability, light");
            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Undead")
                                  .HasDescriptionFile(@"Content\Templates\Undead\description.md")
                                  .WithCharacteristic("Darkvision")
                                  .WithCharacteristic("Immunity, Mind-Affecting", "Mindless")
                                  .WithSpecialCharacteristic("No Metabolism", "Immunity to poision, sleep effects, stunning, and disease", 13)
                                  .WithCharacteristic("Vulnerability, Light")
                                  .WithSpecialCharacteristic("Shadow Thrive", "Damage from shadow attacks increases the undead's Energy, as opposed to decreasing it like other types of damage.", vulnerabilityLight.SpecifiedPowerAdjustment.Value * -1)
                                  .WithSpecialCharacteristic("Fleeting", "When reduced to 0 or less damage, the undead creature dies immediately, as opposed to being incapacitated.", -2, CharacteristicType.Flaw)
                                  .WithSpecialCharacteristic("Resurrection Differences", "The spell Resurrection can be used to bring an undead Creature back to life.\n\nThe time the undead creature spent reanimated counts against the rule regarding how long concentration is needed for the Resurrection spell.", -1, CharacteristicType.Flaw)
                                  .AsRace(false)
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Outsider")
                                  .HasDescriptionFile(@"Content\Templates\Outsider\description.md")
                                  .WithCharacteristic("Darkvision")
                                  .WithSpecialCharacteristic("Metabolism Differences", "An outsider must be able to breathe, but may choose to sleep or eat as they desire.", 2)
                                  .WithSpecialCharacteristic("Resurrection Differences", @"Content\Templates\Outsider\resurrection-differences.md", -1, CharacteristicType.Flaw)
                                  .AsRace(false)
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Animal")
                                  .HasDescription("An animal is a living, nonhuman creature, usually a vertebrate with no magical abilities and no innate capacity for language or culture.")
                                  .WithCharacteristic("Cat Like Vision")
                                  .WithMod("Survival", 4)
                                  .WithMod("Insight", 4, "Instinct")
                                  .WithMod("Perception", 4)
                                  .AsRace(false)
                                  .WithMod("Racial Focus Score", 2)
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Devil")
                                  .HasDescription("Fiends from the Infernal Plane of existence. While usually evil, they do generally have a code of conduct.")
                                  .WithCharacteristic("Resistance, Acid")
                                  .WithCharacteristic("Resistance, Cold")
                                  .WithCharacteristic("Immunity, Fire")
                                  .WithCharacteristic("Immunity, All Poison")
                                  .WithCharacteristic("Darkvision")
                                  .WithSpell("Telepathy")
                                  //.WithSpell("Summon", "Others of their kind.") TODO
                                  .AsRace(false)
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Swarm")
                                  .HasDescription("A swarm is a collection of Minute or Tiny creatures that acts as a single creature.")
                                  .WithCharacteristic("Ignores Critical Damage")
                                  .WithCharacteristic("Can't Be Flanked")
                                  .WithSpecialCharacteristic("Move in occupied space.", "Since it crawls all over its prey, a swarm does not take penalties for sharing a space with other Creatures", 1)
                                  .WithSpecialCharacteristic("Incapacitated Differences", "When brought below 0 Energy, rather than becoming Incapacitated, a Swarm instead separates and disperses.", 0)
                                  .WithSpecialCharacteristic("No Maneuvers", "Grappling, Pushing, Tripping, and other Maneuvers cannot be performed against a swarm. Likewise, a swarm cannot an initiate a Maneuver.", 1, CharacteristicType.Flaw)
                                  .WithCharacteristic("Resistance, Bludgeoning")
                                  .WithCharacteristic("Resistance, Piercing")
                                  .WithCharacteristic("Resistance, Slashing")
                                  .WithSpecialCharacteristic("Spell Differences", "Spells that target a single creature or a specified number of creatures have no effect, with the exception of mind-affecting spells if the swarm has a Focus Score greater than 0 or a hive mind.", 2)
                                  .WithSpecialCharacteristic("Area of Effect Weakness", "Swarms take half again as much damage (+50%) from splash attacks or spells that target an area.", -2, CharacteristicType.Flaw)
                                  .AsRace(false)
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Ooze")
                                  .HasDescription("An ooze is an amorphous or mutable creature.")
                                  .WithCharacteristic("Ignores Critical Damage")
                                  .WithCharacteristic("Can't Be Flanked")
                                  .WithCharacteristic("Immunity, Mind-Affecting", "Mindless")
                                  .WithCharacteristic("Immunity, All Poison")
                                  .WithCharacteristic("Blind")
                                  .WithCharacteristic("Blindsight")
                                  .WithSpecialCharacteristic("Incapacitated Differences", "When brought below 0 Energy, rather than becoming Incapacitated, an Ooze trickles away into a liquid that is washed away in time.", 0)
                                  .WithSpecialCharacteristic("No Focus", "Any Focus Score given in a creature with this template should be ignored.", -5, CharacteristicType.Flaw)
                                  .WithSpecialCharacteristic("Metabolism Differences", "An ooze does not need to sleep, but must eat and breath", 1)
                                  .AsRace(false)
                                  .Build());

            builder = new TemplateBuilder(standardCampaignSetting, characteristics, spells, spellCharacteristics);
            dbContext.Templates.Add(builder.HasName("Bugbear")
                                  .HasDescriptionFile("Content\\Templates\\bugbear.md")
                                  .AsRace(true)
                                  .WithMod("Racial Strength Score", 4)
                                  .WithMod("Racial Agility Score", 2)
                                  .WithMod("Racial Charm Score", -2)
                                  .WithMod("Energy", -2)
                                  .WithCharacteristic("Speak Language", "Goblin")
                                  .WithCharacteristic("Darkvision")
                                  .WithMod("Defense", 3, "Natural")
                                  .WithMod("Stealth Misc.", 4)
                                  .Build());
        }

    }
}
