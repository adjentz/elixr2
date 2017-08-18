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

        private IEnumerable<Creature> AddCreatures(List<Characteristic> characteristics, List<Armor> armors, List<Weapon> weapons,
        List<Spell> spells, List<Template> templates, List<SpellCharacteristic> spellCharacteristics, List<WeaponCharacteristic> weaponCharacteristics)
        {
            CreatureBuilderContext context = new CreatureBuilderContext
            {
                Characteristics = characteristics,
                Armors = armors,
                Weapons = weapons,
                Spells = spells,
                Templates = templates,
                Setting = standardCampaignSetting,
                WeaponCharacteristics = weaponCharacteristics,
                SpellCharacteristics = spellCharacteristics
            };

            var creatures = AddCreaturesStartingWithA(context);
            foreach (var creature in creatures)
            {
                yield return creature;
            }

            creatures = AddCreaturesStartingWithB(context);
            foreach (var creature in creatures)
            {
                yield return creature;
            }

            creatures = AddCreaturesStartingWithC(context);
            foreach (var creature in creatures)
            {
                yield return creature;
            }
            // creatures = AddCreaturesStartingWithT(context);
            // foreach (var creature in creatures)
            // {
            //     yield return creature;
            // }

        }

        private IEnumerable<Creature> AddCreaturesStartingWithA(CreatureBuilderContext ctx)
        {
            const string atWillSpell = "At Will Spell";

            var builder = new CreatureBuilder(ctx);
            var creature = builder.HasName("Aasimar Warrior")
                                .HasDescriptionFile(@"Content\Templates\aasimar.md")
                                .HasSkills(medicine: 4, recall: 1, initiative: 4)
                                .WithTemplate("Aasimar")
                                .WithMod("Defense", 0)
                                .WithMod("Speed", 60)
                                .WithMod("Strength Score", 13)
                                .WithMod("Agility Score", 11)
                                .WithMod("Focus Score", 12)
                                .WithMod("Charm Score", 8)
                                .WithArmor("Scale Mail")
                                .WithArmor("Shield")
                                .WithWeapon("Sword, long")
                                .WithWeaponCharacteristic("Sword, long", "Weapon Training, 1")
                                .WithMod("Energy", 5)
                                .BuildAndReset();

            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Achaierai")
                                           .HasDescriptionFile(@"Content\Creatures\Achaierai\description.md")
                                           .HasAverageHeight("15ft")
                                           .HasAverageWeight("750lbs")
                                           .HasRacialAbilityScores(strength: 17, agility: 15, focus: 12, charm: 16)
                                           .HasSkills(acrobatics: 9, climb: 9, diplomacy: 2, stealth: 9, athletics: 17, insight: 10, perception: 10)
                                           .WithMod("Speed", 90)
                                           .WithMod("Energy", 39)
                                           .WithMod("Defense", 10)
                                           .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6")
                                           .WithWeaponCharacteristic("Claw", "Weapon Training, 5")
                                           .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "4d6")
                                           .WithCharacteristic("Large", "Tall")
                                           .WithCharacteristic("Speak Language", "Infernal")
                                           .WithCharacteristic("Darkvision")
                                           .WithCharacteristic("Resistance, Cold")
                                           .WithCharacteristic("Resistance, Acid")
                                           .WithCharacteristic("Resistance, Electric")
                                           .WithCharacteristic("Resistance, Light")
                                           .WithCharacteristic("Resistance, Shadow")
                                           .WithCharacteristic("Resistance, Fire")
                                           .WithSpecialCharacteristic("Black Cloud", @"Content\Creatures\Achaierai\black-cloud.md", 30)
                                           .BuildAndReset();

            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Arrowhawk, Adult")
                                .HasDescriptionFile(@"Content\Creatures\Arrowhawk\description.md")
                                .HasAverageHeight("10ft long/15ft wingspan")
                                .HasAverageWeight("100lbs")
                                .HasLifespan("11 to 40 years")
                                .HasRacialAbilityScores(strength: 14, agility: 21, focus: 11, charm: 13)
                                .HasSkills(initiative: 5, diplomacy: 2, escapeArtist: 10, recall: 10, perception: 10, insight: 10, stealth: 10, survival: 12)
                                .WithMod("Energy", 38)
                                .WithMod("Defense", 6)
                                .WithMod("Speed", 60)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "2d8")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 7")
                                .WithWeaponCharacteristic("Bite", "Weapon Specialization, 1")
                                .WithNaturalWeapon("Electricity Ray", WeaponUseAbility.Agility, WeaponUseAbility.Focus, "2d8")
                                .WithWeaponCharacteristic("Electricity Ray", "Ignores Armor")
                                .WithWeaponCharacteristic("Electricity Ray", "Weapon Training, 7")
                                .WithCharacteristic("Speak Language", "Auran")
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Immunity, Acid")
                                .WithCharacteristic("Immunity, Electric")
                                .WithCharacteristic("Immunity, All Poison")
                                .WithCharacteristic("Resistance, Cold")
                                .WithCharacteristic("Resistance, Fire")
                                .BuildAndReset();


            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Air Elemental, Medium")
                                .HasDescriptionFile(@"Content\Creatures\AirElemental\description.md")
                                .HasAverageHeight("10-30ft")
                                .HasAverageWeight("2lbs")
                                .HasRacialAbilityScores(strength: 12, agility: 21, focus: 7, charm: 11)
                                .HasSkills(initiative: 3, perception: 6)
                                .WithMod("Energy", 26)
                                .WithMod("Defense", 3)
                                .WithMod("Speed", 200)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 3")
                                .WithCharacteristic("Speak Language", "Auran")
                                .WithCharacteristic("Natural Flyer")
                                .WithSpecialCharacteristic("Whirlwind", @"Content\Creatures\AirElemental\whirlwind.md", 22, CharacteristicType.Feature, "2", "30", "13", "1d6")
                                .BuildAndReset();


            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Air Mephit")
                            .HasDescriptionFile(@"Content\Creatures\AirMephit\description.md")
                            .HasAverageHeight("4ft")
                            .HasAverageWeight("1lbs")
                            .HasRacialAbilityScores(strength: 12, agility: 15, focus: 8, charm: 15)
                            .HasSkills(initiative: 4, deception: 6, escapeArtist: 6, stealth: 8, diplomacy: 2, intimidate: 4, perception: 7, survival: 4, perform: 1)
                            .WithMod("Energy", 13)
                            .WithMod("Defense", 3)
                            .WithMod("Speed", 70)
                            .WithNaturalWeapon("Claw", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d3")
                            .WithWeaponCharacteristic("Claw", "Weapon Training, 1")
                            .WithCharacteristic("Speak Language", "Auran")
                            .WithCharacteristic("Small")
                            .WithCharacteristic("Natural Flyer")
                            .WithCharacteristic("Darkvision")
                            .WithCharacteristic("Resistance, Slashing")
                            .WithCharacteristic("Resistance, Bludgeoning")
                            .WithCharacteristic("Resistance, Piercing")
                            .WithSpecialCharacteristic("Breath Weapon", @"Content\Creatures\AirMephit\breath-weapon.md", 11)
                            .WithCharacteristic("Fast Healing, 2", "Air mephits can only heal if exposed to moving air, be it a breeze, a draft, a spell effect, or even the mephit fanning itself.")
                            .WithSpell("Blur", "Air mephit surrounds itself with vapor")
                            .WithSpell("Gust")
                            .WithSpellCharacteristic("Blur", atWillSpell)
                            .WithSpellCharacteristic("Gust", atWillSpell)
                            .BuildAndReset();


            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Allip")
                            .HasDescriptionFile(@"Content\Creatures\Allip\description.md")
                            .HasAverageHeight("As in life")
                            .HasAverageWeight("0lbs")
                            .WithTemplate("Incorporeal")
                            .WithTemplate("Undead")
                            .HasRacialAbilityScores(strength: 0, agility: 12, focus: 11, charm: 18)
                            .HasSkills(initiative: 4, stealth: 8, intimidate: 7, insight: 4, perception: 7, survival: 1)
                            .WithMod("Energy", 26)
                            .WithMod("Defense", 4)
                            .WithMod("Speed", 60)
                            .WithNaturalWeapon("Incorporeal Touch", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "0d0")
                            .WithSpecialWeaponCharacteristic("Incorporeal Touch", "Focus Drain", @"Content\Creatures\Allip\focus-drain.md", 6)
                            .WithCharacteristic("Natural Flyer")
                            .WithSpecialCharacteristic("Babble", @"Content\Creatures\Allip\babble.md", 4)
                            .WithSpecialCharacteristic("Madness", @"Content\Creatures\Allip\madness.md", 5)
                            .BuildAndReset();


            yield return creature;



            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Ankheg")
                                .HasDescriptionFile(@"Content\Creatures\Ankheg\description.md")
                                .HasAverageHeight("10ft long")
                                .HasAverageWeight("800lbs")
                                .HasRacialAbilityScores(strength: 19, agility: 12, focus: 2, charm: 6)
                                .HasSkills(initiative: 0, climb: 3, perception: 9, survival: 5, insight: 5)
                                .WithMod("Energy", 28)
                                .WithMod("Defense", 10)
                                .WithMod("Speed", 60)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6", reach: true)
                                .WithWeaponCharacteristic("Bite", "Acid, 1d4")
                                .WithWeaponCharacteristic("Bite", "Latch")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 1")
                                .WithCharacteristic("Cat Like Vision")
                                .WithCharacteristic("Tremorsense, 60ft")
                                .WithCharacteristic("Large", "Long")
                                .WithCharacteristic("Darkvision")
                                .WithSpecialCharacteristic("Spit Acid", @"Content\Creatures\Ankheg\spit-acid.md", 7)
                                .BuildAndReset();


            yield return creature;

            var annisRend = (new WeaponCharacteristicBuilder(standardCampaignSetting))
                            .HasName("Rend")
                            .HasDescriptionFile(@"Content\Characteristics\Weapons\rend.md")
                            .HasExtraDamage("2d6")
                            .HasDamageBonusMod(10)
                            .Build();

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Annis")
                            .HasDescriptionFile(@"Content\Creatures\Annis\description.md")
                            .HasAverageHeight("8ft tall")
                            .HasAverageWeight("325lbs")
                            .HasRacialAbilityScores(strength: 23, agility: 14, focus: 13, charm: 10)
                            .HasSkills(initiative: 0, deception: 8, diplomacy: 2, perform: 2, stealth: 6, perception: 9)
                            .WithMod("Energy", 45)
                            .WithMod("Defense", 10)
                            .WithMod("Speed", 70)
                            .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                            .WithWeaponCharacteristic("Claw", "Rake")
                            .WithSpecialWeaponCharacteristic("Claw", annisRend)
                            .WithWeaponCharacteristic("Claw", "Latch")
                            .WithCharacteristic("Resistance, Fire")
                            .WithCharacteristic("Resistance, Cold")
                            .WithCharacteristic("Resistance, Light")
                            .WithCharacteristic("Resistance, Shadow")
                            .WithCharacteristic("Resistance, Acid")
                            .WithCharacteristic("Resistance, Electric")
                            .WithCharacteristic("Darkvision")
                            .WithCharacteristic("Large", "Tall")
                            .WithSpell("Illusion", "Only on self")
                            .WithSpell("Fog Cloud")
                            .WithSpellCharacteristic("Illusion", atWillSpell)
                            .WithSpellCharacteristic("Fog Cloud", atWillSpell)
                            .BuildAndReset();


            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Ape")
                            .HasDescription("These powerful omnivores resemble gorillas but are far more aggressive; they kill and eat anything they can catch.")
                            .HasAverageHeight("5-1/2 to 6ft tall")
                            .HasAverageWeight("300-400lbs")
                            .HasRacialAbilityScores(strength: 19, agility: 17, focus: 2, charm: 7)
                            .HasSkills(initiative: 0, climb: 9, perception: 10, survival: 5, insight: 5)
                            .WithMod("Energy", 29)
                            .WithMod("Defense", 4)
                            .WithMod("Speed", 60)
                            .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                            .WithWeaponCharacteristic("Claw", "Weapon Training, 2")
                            .WithCharacteristic("Large")
                            .BuildAndReset();


            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Aranea")
                            .HasDescriptionFile(@"Content\Creatures\Aranea\description.md")
                            .HasAverageHeight("8ft long")
                            .HasAverageWeight("150lbs")
                            .HasRacialAbilityScores(strength: 11, agility: 15, focus: 14, charm: 14)
                            .HasSkills(initiative: 4, climb: 14, concentration: 6, escapeArtist: 3, athletics: 13, perception: 4)
                            .WithMod("Energy", 22)
                            .WithMod("Defense", 1)
                            .WithMod("Speed", 100)
                            .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d6")
                            .WithWeaponCharacteristic("Bite", "Poison, 1d6 Str")
                            .WithWeaponCharacteristic("Bite", "Weapon Training, 3")
                            .WithSpecialCharacteristic("Web, Medium", @"Content\Creatures\Aranea\web.md", 3)
                            .WithSpecialCharacteristic("Change Shape", @"Content\Creatures\Aranea\change-shape.md", 3)
                            .WithSpell("Illusion")
                            .WithSpell("Detect Energy")
                            .WithSpell("Energy Blast, Light")
                            .WithSpell("Mage Armor")
                            .WithSpell("Sleep")
                            .WithSpell("Ward")
                            .WithSpell("Daze")
                            .BuildAndReset();


            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Assassin Vine")
                            .HasDescriptionFile(@"Content\Creatures\AssassinVine\description.md")
                            .HasRacialAbilityScores(strength: 18, agility: 12, focus: 13, charm: 9)
                            .HasSkills(initiative: 0)
                            .WithTemplate("Plant")
                            .WithMod("Energy", 30)
                            .WithMod("Defense", 6)
                            .WithMod("Speed", 30)
                            .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6", reach: true)
                            .WithWeaponCharacteristic("Slam", "Latch")
                            .WithWeaponCharacteristic("Slam", "Weapon Training, 2")
                            .WithWeaponCharacteristic("Slam", "Weapon Specialization, 2")
                            .WithWeaponCharacteristic("Slam", "Constrict")
                            .WithCharacteristic("Camoflage")
                            .WithCharacteristic("Blindsight")
                            .WithCharacteristic("Immunity, Electric")
                            .WithCharacteristic("Resistance, Cold")
                            .WithCharacteristic("Resistance, Fire")
                            .WithCharacteristic("Large")
                            .WithCharacteristic("Gimped")
                            .WithSpell("Entangle")
                            .WithSpellCharacteristic("Entangle", atWillSpell)
                            .BuildAndReset();

            yield return creature;

            builder = new CreatureBuilder(ctx);
            creature = builder.HasName("Avoral")
                                        .HasDescriptionFile(@"Content\Creatures\Avoral\description.md")
                                        .HasAverageHeight("7ft tall")
                                        .HasAverageWeight("120lbs")
                                        .WithTemplate("Outsider")
                                        .WithCharacteristic("Fly")
                                        .WithCharacteristic("Cat Like Vision")
                                        .WithCharacteristic("Resistance, Fire")
                                        .WithCharacteristic("Resistance, Cold")
                                        .WithCharacteristic("Resistance, Light")
                                        .WithCharacteristic("Resistance, Shadow")
                                        .WithCharacteristic("Resistance, Electric")
                                        .WithCharacteristic("Resistance, Acid")
                                        .WithCharacteristic("Vulnerability, Material", "Silver")
                                        .HasRacialAbilityScores(strength: 15, agility: 23, focus: 15, charm: 16)
                                        .HasSkills(initiative: 4, deception: 10, concentration: 13, diplomacy: 4, perform: 2, animalHandling: 10, stealth: 10, intimidate: 3, recall: 10, perception: 15, acrobatics: 8, insight: 11)
                                        .WithMod("Energy", 66)
                                        .WithMod("Defense", 8)
                                        .WithMod("Speed", 80)
                                        .WithNaturalWeapon("Claw", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "2d6")
                                        .WithNaturalWeapon("Wing", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "2d8", notes: "Only on ground.")
                                        .WithWeaponCharacteristic("Wing", "Weapon Training, 7")
                                        .WithSpecialCharacteristic("Fear Aura", @"Creatures\Avoral\fear-aura.md", 6)
                                        .WithSpecialCharacteristic("Visual Acuity", "An avoral’s visual acuity is virtually unmatched: It can see detail on objects up to 10 miles away and is said to be able to discern the color of a creature’s eyes at 200 paces.", 4)
                                        .WithSpell("Transfer Energy")
                                        .WithSpellCharacteristic("Transfer Energy", atWillSpell)
                                        .WithSpell("Tongues")
                                        .WithSpellCharacteristic("Tongues", atWillSpell)
                                        .WithSpell("Reveal")
                                        .WithSpellCharacteristic("Reveal", atWillSpell)
                                        .WithSpell("Speak With Entity, Animals")
                                        .WithSpellCharacteristic("Speak With Entity, Animals", atWillSpell)
                                        .WithSpell("Compel")
                                        .WithSpell("Detect Energy")
                                        .WithSpell("Teleport")
                                        .WithSpell("Gust")
                                        .WithSpell("Energy Blast, Light")
                                        .WithSpell("Energy Blast, Electric")
                                        .WithSpell("Ward")
                                        .WithSpellCharacteristic("Ward", atWillSpell)
                                        .BuildAndReset();


            yield return creature;
        }

        private IEnumerable<Creature> AddCreaturesStartingWithB(CreatureBuilderContext ctx)
        {
            const string atWillSpell = "At Will Spell";

            var builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Baboon")
                                .WithTemplate("Animal")
                                .HasDescriptionFile(@"Content\Creatures\Baboon\description.md")
                                .HasAverageWeight("Up to 90lbs")
                                .HasAverageHeight("2-4ft")
                                .HasRacialAbilityScores(strength: 15, agility: 14, focus: 0, charm: 4)
                                .HasSkills(climb: 8, perception: 5)
                                .WithMod("Defense", 1)
                                .WithMod("Energy", 5)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Bite", "Weapon Specialization, 1")
                                .WithCharacteristic("Cat Like Vision")
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Badger")
                                .HasAverageWeight("25-35lbs")
                                .HasAverageHeight("2-3ft")
                                .WithTemplate("Animal")
                                .WithCharacteristic("Small")
                                .HasDescription("The badger is a furry animal with a squat, powerful body. Its strong forelimbs are armed with long claws for digging.")
                                .HasRacialAbilityScores(strength: 10, agility: 15, focus: 0, charm: 6)
                                .HasSkills(acrobatics: 3, escapeArtist: 7, perception: 3)
                                .WithMod("Energy", 6)
                                .WithMod("Defense", 1)
                                .WithMod("Speed", 70)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d2")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 1")
                                .WithSpecialCharacteristic("Badger Rage", "A badger that takes damage in combat flies into a berserk rage on its next turn, clawing and biting madly until either it or its opponent is dead. It gains +4 to Strength, +2 to Energy Buffer, and –2 to Defense. The creature cannot end its rage voluntarily.", 3)
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Baleen Whale")
                                .HasAverageWeight("77,000–130,000lbs")
                                .HasAverageHeight("30-60ft long")
                                .WithTemplate("Animal")
                                .WithCharacteristic("Massive", "Long")
                                .HasDescription("The statistics here describe a plankton-feeding whale between 30 and 60 feet long, such as gray, humpback, and right whales. These massive creatures are surprisingly gentle. If harassed or provoked, they are as likely to flee as they are to retaliate.")
                                .HasRacialAbilityScores(strength: 27, agility: 17, focus: 0, charm: 6)
                                .HasSkills(perception: 15, swim: 8)
                                .WithMod("Energy", 132)
                                .WithMod("Defense", 9)
                                .WithMod("Speed", 80)
                                .WithCharacteristic("Natural Swimmer")
                                .WithNaturalWeapon("Tail Slap", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Tail Slap", "Weapon Training, 5")
                                .WithWeaponCharacteristic("Tail Slap", "Weapon Specialization, 6")
                                .WithCharacteristic("Blindsight", "120ft; Echolocation.")
                                .BuildAndReset();

            var fearInducing = (new WeaponCharacteristicBuilder(standardCampaignSetting)).HasName("Fear Inducing")
                                                                                         .HasDescriptionFile(@"Content\Creatures\BarbedDevil\fear-inducing.md")
                                                                                         .HasSpecificPower(9)
                                                                                         .Build();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Barbed Devil")
                                .WithTemplate("Devil")
                                .HasAverageHeight("7ft")
                                .HasAverageWeight("300lbs")
                                .HasDescriptionFile(@"Content\Creatures\BarbedDevil\description.md")
                                .HasRacialAbilityScores(strength: 23, agility: 23, focus: 13, charm: 18)
                                .HasSkills(concentration: 20, diplomacy: 2, stealth: 15, intimidate: 13, recall: 15, perception: 18, insight: 16, survival: 2)
                                .WithMod("Energy", 126)
                                .WithMod("Defense", 13)
                                .WithMod("Speed", 60)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8")
                                .WithSpecialWeaponCharacteristic("Claw", fearInducing)
                                .WithWeaponCharacteristic("Claw", "Latch")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 12")
                                .WithSpecialCharacteristic("Barbed Defense", @"Content\Creatures\BarbedDevil\barbed-defense.md", 11)
                                .WithSpecialCharacteristic("Impale", @"Content\Creatures\BarbedDevil\impale.md", 13)
                                .WithSpell("Illusion")
                                .WithSpell("Energy Blast, Fire")
                                .WithSpell("Compel")
                                .WithSpell("Teleport")
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Barghest")
                                .WithTemplate("Outsider")
                                .HasSkin("Bluishred-Blue")
                                .HasEyes("Orange; glow when excited")
                                .HasAverageHeight("6ft long")
                                .HasAverageWeight("180lbs")
                                .HasDescriptionFile(@"Content\Creatures\Barghest\description.md")
                                .HasRacialAbilityScores(strength: 17, agility: 15, focus: 14, charm: 14)
                                .HasSkills(initiative: 4, deception: 12, perform: 2, stealth: 9, intimidate: 10, athletics: 9, insight: 9, survival: 9)
                                .WithMod("Energy", 33)
                                .WithMod("Defense", 6)
                                .WithMod("Speed", 60)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 6")
                                .WithCharacteristic("Resistance, Bludgeoning")
                                .WithCharacteristic("Resistance, Slashing")
                                .WithCharacteristic("Resistance, Piercing")
                                .WithSpecialCharacteristic("Feed", @"Content\Creatures\Barghest\feed.md", 16)
                                .WithSpecialCharacteristic("Change Shape", @"Content\Creatures\Barghest\change-shape.md", 4)
                                .WithCharacteristic("Speak Language", "Goblin")
                                .WithCharacteristic("Speak Language", "Worg")
                                .WithCharacteristic("Speak Language", "Infernal")
                                .WithSpell("Fly")
                                .WithSpell("Charm")
                                .WithSpell("Teleport")
                                .WithSpell("Despair")
                                .WithSpell("Plane Shift")
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Basilisk")
                                .HasSkin("Dull brown with a yellowish underbelly.")
                                .HasAverageWeight("300lbs")
                                .HasAverageHeight("6ft long, plus a 5-7ft tail")
                                .HasDescriptionFile(@"Content\Creatures\Basilisk\description.md")
                                .HasRacialAbilityScores(strength: 15, agility: 8, focus: 2, charm: 11)
                                .HasSkills(insight: 4, survival: 4, stealth: 1, perception: 11)
                                .WithMod("Defense", 7)
                                .WithMod("Energy", 45)
                                .WithMod("Speed", 40)
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Cat Like Vision")
                                .WithSpecialCharacteristic("Motionless", "The basilisk’s dull coloration and its ability to remain motionless for long periods of time grant it Advantage on Stealth checks in natural settings.", 1)
                                .WithSpecialCharacteristic("Petrifying Gaze", @"Content\Creatures\Basilisk\petrifying-gaze.md", 13)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 6")
                                .WithWeaponCharacteristic("Bite", "Weapon Specialization, 1")
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bat")
                                .WithTemplate("Animal")
                                .WithCharacteristic("Tiny")
                                .HasDescription("Bats are nocturnal flying mammals.")
                                .HasRacialAbilityScores(strength: 5, agility: 11, focus: 0, charm: 4)
                                .HasSkills(stealth: 12, perception: 8)
                                .WithMod("Energy", 1)
                                .WithMod("Speed", 80)
                                .WithMod("Defense", 2)
                                .WithCharacteristic("Blindsight", "Echolocation. Up to 20 ft.")
                                .WithCharacteristic("Natural Flyer")
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bat Swarm")
                                .WithTemplate("Animal")
                                .WithTemplate("Swarm")
                                .WithCharacteristic("Tiny")
                                .HasDescriptionFile(@"Content\Creatures\BatSwarm\description.md")
                                .HasRacialAbilityScores(strength: 7, agility: 11, focus: 0, charm: 4)
                                .HasSkills(perception: 11)
                                .WithMod("Energy", 13)
                                .WithMod("Speed", 80)
                                .WithMod("Defense", 2)
                                .WithSpecialCharacteristic("Swarm Attack", "At the end of its turn, any creatures that the swarm is sharing a space with automatically takes 1d6 of damage.", 4)
                                .WithSpecialCharacteristic("Wounding", @"Content\Creatures\BatSwarm\wounding.md", 2)
                                .WithSpecialCharacteristic("Distraction", "If a creature begins their sharing a space with the swarm, they must make a Difficulty 11 Concentration check or have their Speed Halved for that turn.", 2)
                                .WithCharacteristic("Blindsight", "Echolocation. Up to 20 ft.")
                                .WithCharacteristic("Natural Flyer")
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bearded Devil")
                                .HasDescriptionFile(@"Content\Creatures\BeardedDevil\description.md")
                                .WithTemplate("Devil")
                                .HasAverageHeight("6ft")
                                .HasAverageWeight("225lbs")
                                .HasRacialAbilityScores(strength: 15, agility: 15, focus: 10, charm: 10)
                                .HasSkills(initiative: 4, climb: 9, diplomacy: 2, stealth: 7, perception: 9, insight: 9)
                                .WithMod("Speed", 80)
                                .WithMod("Energy", 45)
                                .WithMod("Defense", 7)
                                .WithWeapon("Glaive")
                                .WithSpecialWeaponCharacteristic("Glaive", "Infernal Wound", @"Content\Creatures\BeardedDevil\infernal-wound.md", 7)
                                .WithWeaponCharacteristic("Glaive", "Weapon Training, 7")
                                .WithWeaponCharacteristic("Glaive", "Weapon Specialization, 1")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6", slash: true, pierce: true)
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 6")
                                .WithSpecialWeaponCharacteristic("Claw", "Beard", @"Content\Creatures\BeardedDevil\beard.md", 13)
                                .WithCharacteristic("Resistance, Bludgeoning")
                                .WithCharacteristic("Resistance, Slashing")
                                .WithCharacteristic("Resistance, Piercing")
                                .WithCharacteristic("Vulnerability, Material", "Silver")
                                .WithSpecialCharacteristic("Battle Frenzy", @"Content\Creatures\BeardedDevil\battle-frenzy.md", 5)
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bebilith")
                                .WithCharacteristic("Huge")
                                .WithTemplate("Outsider")
                                .HasDescriptionFile(@"Content\Creatures\Bebilith\description.md")
                                .HasRacialAbilityScores(strength: 24, agility: 16, focus: 12, charm: 13)
                                .HasSkills(initiative: 4, climb: 15, diplomacy: 2, stealth: 19, athletics: 19, perception: 15, survival: 1, insight: 14)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6")
                                .WithWeaponCharacteristic("Bite", "Poison, 1d6 Energy")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 10")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d4")
                                .WithSpecialWeaponCharacteristic("Claw", "Rend Armor", @"Content\Creatures\Bebilith\rend-armor.md", 9)
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 5")
                                .WithSpecialCharacteristic("Web", @"Content\Creatures\Bebilith\web.md", 13)
                                .WithSpell("Plane Shift")
                                .WithSpellCharacteristic("Plane Shift", atWillSpell)
                                .WithSpell("Telepathy")
                                .WithSpellCharacteristic("Telepathy", atWillSpell)
                                .WithMod("Energy", 150)
                                .WithMod("Speed", 70)
                                .WithMod("Defense", 13)
                                .BuildAndReset();

            var gimpedClaw = (new WeaponCharacteristicBuilder(standardCampaignSetting)).HasName("Gimped")
                                                                            .HasDamageBonusMod(-4)
                                                                            .HasDescription("A Behir cannot make normal attacks with their claws. Instead, they must be in control of grapple, and make use of the Rake Characteristic applied to the Claw attack.")
                                                                            .HasSpecificPower(-6)
                                                                            .Build();
            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Behir")
                                .HasDescriptionFile(@"Content\Creatures\Behir\description.md")
                                .WithCharacteristic("Huge", "Long")
                                .HasAverageHeight("40ft long")
                                .HasAverageWeight("4,000lbs")
                                .HasSkin("Hues of blue scales, sometimes with bands of gray-brown. The belly is pale blue.")
                                .HasRacialAbilityScores(strength: 22, agility: 17, focus: 10, charm: 12)
                                .HasSkills(climb: 8, stealth: 8, perception: 4, survival: 2)
                                .WithMod("Defense", 11)
                                .WithMod("Energy", 94)
                                .WithMod("Speed", 60)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d4")
                                .WithWeaponCharacteristic("Bite", "Latch")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 7")
                                .WithWeaponCharacteristic("Bite", "Weapon Specialization, 4")
                                .WithNaturalWeapon("Crush", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "2d8", bludgeon: true)
                                .WithWeaponCharacteristic("Crush", "Constrict")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d4")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 6")
                                .WithSpecialWeaponCharacteristic("Claw", gimpedClaw)
                                .WithWeaponCharacteristic("Claw", "Rake")
                                .WithSpell("Energy Blast, Electric", "The blast is expelled from the creature's mouth")
                                .WithSpellCharacteristic("Energy Blast, Electric", atWillSpell)
                                .WithSpecialCharacteristic("Swallow Whole", @"Content\Creatures\Behir\swallow-whole.md", 13)
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Cat Like Vision")
                                .WithCharacteristic("Immunity, Electric")
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Belker")
                                .HasDescriptionFile(@"Content\Creatures\Belker\description.md")
                                .WithCharacteristic("Large")
                                .HasAverageHeight("7ft long")
                                .HasAverageWeight("8lbs")
                                .HasRacialAbilityScores(strength: 12, agility: 23, focus: 6, charm: 11)
                                .HasSkills(perception: 9, stealth: 6, insight: 2, survival: 2)
                                .WithMod("Defense", 8)
                                .WithMod("Energy", 38)
                                .WithMod("Speed", 50)
                                .WithCharacteristic("Fly")
                                .WithNaturalWeapon("Wing", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d6", bludgeon: true)
                                .WithWeaponCharacteristic("Wing", "Weapon Training, 4")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d4")
                                .WithWeaponCharacteristic("Bite", "Clumsy Weapon, 1")
                                .WithWeaponCharacteristic("Bite", "Weak Weapon, 1")
                                .WithCharacteristic("Speak Language", "Auran")
                                .WithSpell("Gaseous Form")
                                .WithSpellCharacteristic("Gaseous Form", atWillSpell)
                                .WithSpecialCharacteristic("Smoke Claws", @"Content\Creatures\Belker\smoke-claws.md", 6)
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bison")
                                .HasDescriptionFile(@"Content\Creatures\Bison\description.md")
                                .HasAverageHeight("6ft tall at the shoulder, 9-12ft long")
                                .HasAverageWeight("1,800-2,400lbs")
                                .WithCharacteristic("Large")
                                .WithTemplate("Animal")
                                .HasRacialAbilityScores(strength: 20, agility: 12, focus: 0, charm: 4)
                                .HasSkills(perception: 6)
                                .WithNaturalWeapon("Gore", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Gore", "Weapon Training, 2")
                                .WithWeaponCharacteristic("Gore", "Weapon Specialization, 3")
                                .WithSpecialCharacteristic("Stampede", @"Content\Creatures\Bison\stampede.md", 11)
                                .WithMod("Defense", 4)
                                .WithMod("Energy", 37)
                                .WithMod("Speed", 70)
                                .BuildAndReset();

            var weakJaw = (new WeaponCharacteristicBuilder(standardCampaignSetting)).HasName("Weak Jaw")
                                                                                                .HasDamageBonusMod(-2)
                                                                                                .Build();
            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bear, Black")
                                .HasDescription("The black bear is a forest-dwelling omnivore that usually is not dangerous unless an interloper threatens its cubs or food supply.")
                                .WithTemplate("Animal")
                                .HasHair("Black, blond, or cinnamon fur")
                                .HasAverageHeight("< 5ft long")
                                .HasRacialAbilityScores(strength: 19, agility: 13, focus: 0, charm: 6)
                                .HasSkills(perception: 4, swim: 4)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d4", slash: true)
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 2")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d6")
                                .WithSpecialWeaponCharacteristic("Bite", weakJaw)
                                .WithMod("Defense", 2)
                                .WithMod("Energy", 19)
                                .WithMod("Speed", 70)
                                .BuildAndReset();

            var puddingAcid = (new WeaponCharacteristicBuilder(standardCampaignSetting)).HasName("Acid")
                                                                                        .HasExtraDamage("2d6")
                                                                                        .HasDescriptionFile(@"Content\Creatures\BlackPudding\acid-slam.md")
                                                                                        .HasSpecificPower(18) // It disolves the targets armor...
                                                                                        .Build();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Black Pudding")
                                .HasDescriptionFile(@"Content\Creatures\BlackPudding\description.md")
                                .HasAverageHeight("15ft across x 2ft thick")
                                .HasAverageWeight("18,000lbs")
                                .WithTemplate("Ooze")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 13, agility: 5, focus: 0, charm: 1)
                                .HasSkills(climb: 8)
                                .WithMod("Energy", 115)
                                .WithMod("Speed", 60)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6")
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 5")
                                .WithWeaponCharacteristic("Slam", "Weapon Specialization, 1")
                                .WithWeaponCharacteristic("Slam", "Constrict")
                                .WithSpecialWeaponCharacteristic("Slam", puddingAcid)
                                .WithWeaponCharacteristic("Slam", "Latch")
                                .WithSpecialCharacteristic("Split", @"Content\Creatures\BlackPudding\split.md", 4)
                                .WithSpecialCharacteristic("Acid Body", @"Content\Creatures\BlackPudding\acid-body.md", 11)
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Blink Dog")
                                .HasDescription("The blink dog is an intelligent canine that has a limited teleportation ability.")
                                .HasRacialAbilityScores(strength: 10, agility: 17, focus: 11, charm: 11)
                                .HasSkills(perception: 5, insight: 3, survival: 4)
                                .WithMod("Defense", 3)
                                .WithMod("Energy", 22)
                                .WithMod("Speed", 80)
                                .WithCharacteristic("Darkvision")
                                .WithSpell("Blink")
                                .WithSpellCharacteristic("Blink", atWillSpell)
                                .WithSpell("Teleport")
                                .WithSpellCharacteristic("Teleport", atWillSpell)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 1")
                                .WithSpecialCharacteristic("Special Language", "Blink dogs have their own language, a mixture of barks yaps, whines, and growls that can transmit complex information.\n\nOther creatures can learn this language (through the Speak Language Feature), but are unlikely to have the vocal chords necessary to articulate it.", 1)
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Boar")
                                .HasDescription("Though not carnivores, these wild swine are bad-tempered and usually charge anyone who disturbs them.")
                                .HasHair("Coarse, grayish-black fur")
                                .HasAverageHeight("4ft long and 3ft high at the shoulder")
                                .WithTemplate("Animal")
                                .HasRacialAbilityScores(strength: 15, agility: 10, focus: 0, charm: 4)
                                .HasSkills(perception: 6)
                                .WithMod("Energy", 25)
                                .WithMod("Defense", 6)
                                .WithMod("Speed", 80)
                                .WithNaturalWeapon("Gore", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Gore", "Weapon Training, 2")
                                .WithWeaponCharacteristic("Gore", "Weapon Specialization, 1")
                                .WithCharacteristic("Ferocity")
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bone Devil")
                                .HasDescriptionFile(@"Content\Creatures\BoneDevil\description.md")
                                .HasAverageHeight("9ft tall")
                                .HasAverageWeight("500lbs")
                                .WithCharacteristic("Large")
                                .WithTemplate("Devil")
                                .HasRacialAbilityScores(strength: 19, agility: 23, focus: 14, charm: 14)
                                .HasSkills(deception: 13, concentration: 16, diplomacy: 4, perform: 2, intimidate: 12, stealth: 13, recall: 13, perception: 15, insight: 13, survival: 2)
                                .WithMod("Speed", 80)
                                .WithMod("Defense", 11)
                                .WithMod("Energy", 95)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 9")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.None, "1d4")
                                .WithWeaponCharacteristic("Claw", "Weapon Specialization, 2")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 7")
                                .WithNaturalWeapon("Sting", WeaponUseAbility.Agility, WeaponUseAbility.None, "3d4")
                                .WithWeaponCharacteristic("Sting", "Weapon Specialization, 2")
                                .WithWeaponCharacteristic("Sting", "Weapon Training, 7")
                                .WithWeaponCharacteristic("Sting", "Poison, 2d6 Str")
                                .WithSpell("Teleport")
                                .WithSpell("Invisibility")
                                .WithSpell("Fly")
                                .WithSpell("Plane Anchor")
                                .WithSpell("Ice Wall")
                                .WithSpecialCharacteristic("Fear Aura", @"Content\Creatures\BoneDevil\fear-aura.md", 3)
                                .BuildAndReset();


            weakJaw = (new WeaponCharacteristicBuilder(standardCampaignSetting)).HasName("Weak Jaw")
                                                                                .HasDamageBonusMod(-4)
                                                                                .HasAttackBonusMod(-2)
                                                                                .Build();
            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bear, Brown")
                                .HasDescription("These massive carnivores are bad-tempered and territorial.")
                                .WithTemplate("Animal")
                                .WithCharacteristic("Large")
                                .HasHair("Brown fur")
                                .HasAverageHeight("About 9ft tall")
                                .HasAverageWeight("> 1,800lbs")
                                .HasRacialAbilityScores(strength: 25, agility: 15, focus: 0, charm: 6)
                                .HasSkills(perception: 7, swim: 4)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8", slash: true)
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 3")
                                .WithWeaponCharacteristic("Claw", "Latch")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6", pierce: true, bludgeon: true)
                                .WithSpecialWeaponCharacteristic("Bite", weakJaw)
                                .WithMod("Defense", 5)
                                .WithMod("Energy", 51)
                                .WithMod("Speed", 70)
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bugbear Warrior")
                                .HasDescriptionFile(@"Content\Templates\bugbear.md")
                                .WithTemplate("Bugbear")
                                .HasRacialAbilityScores(strength: 11, agility: 10, focus: 10, charm: 11)
                                .HasSkills(climb: 1, stealth: 3, perception: 4)
                                .WithArmor("Leather")
                                .WithArmor("Buckler")
                                .WithWeapon("Morningstar")
                                .WithWeapon("Javelin")
                                .WithMod("Energy", 18)
                                .WithMod("Speed", 60)
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bugbear Zombie")
                                .HasDescription("Zombies are corpses reanimated through dark and sinister magic.\n\nBecause of their utter lack of intelligence, the instructions given to a newly created zombie must be very simple. Note their very reduced Speed.")
                                .WithTemplate("Bugbear")
                                .WithTemplate("Undead")
                                .HasRacialAbilityScores(strength: 13, agility: 8, focus: 10, charm: 3)
                                .HasSkills()
                                .WithArmor("Buckler")
                                .WithWeapon("Morningstar")
                                .WithWeaponCharacteristic("Morningstar", "Weapon Training, 3")
                                .WithWeapon("Javelin")
                                .WithWeaponCharacteristic("Javelin", "Weapon Training, 3")
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 3")
                                .WithMod("Energy", 44)
                                .WithMod("Speed", 30)
                                .WithMod("Defense", 2, "Natural (Zombie)")
                                .WithCharacteristic("Resistance, Bludgeoning")
                                .WithCharacteristic("Resistance, Piercing")
                                .BuildAndReset();

            builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Bulette")
                                .HasDescriptionFile(@"Content\Creatures\Bulette\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(perception: 10, survival: 5, recall: 5, insight: 5, athletics: 10)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6", slash: true)
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Cat Like Vision")
                                .WithCharacteristic("Tremorsense, 60ft")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .WithSpecialCharacteristic("Burrow", @"Content\Creatures\Bulette\burrow.md", 4)
                                .BuildAndReset();


        }
        private IEnumerable<Creature> AddCreaturesStartingWithC(CreatureBuilderContext ctx)
        {
            var builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Camel")
                                .HasDescriptionFile(@"Content\Creatures\Camel\description.md")
                                .WithCharacteristic("Large")
                                .WithTemplate("Animal")
                                .HasRacialAbilityScores(strength: 16, agility: 18, focus: 0, charm: 4)
                                .HasSkills(perception: 5)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.None, WeaponUseAbility.Strength, "1d4", bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weak Weapon, 2")
                                .WithMod("Energy", 19)
                                .WithMod("Defense", 1)
                                .WithMod("Speed", 100)
                                .WithSpecialCharacteristic("Carrying Capacity", "A light load for a camel is up to 300lbs; a medium load, 301–600lbs; and a heavy load, 601–900lbs. A camel can drag 4,500lbs.", 2)
                                .BuildAndReset();

            yield break;

            yield return builder.HasName("Cat")
                                .HasDescriptionFile(@"Content\Creatures\Cat\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Celestial Charger")
                                .HasDescriptionFile(@"Content\Creatures\CelestialCharger\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Centaur")
                                .HasDescriptionFile(@"Content\Creatures\Centaur\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Centipede Swarm")
                                .HasDescriptionFile(@"Content\Creatures\CentipedeSwarm\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Chain Devil")
                                .HasDescriptionFile(@"Content\Creatures\ChainDevil\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Chaos Beast")
                                .HasDescriptionFile(@"Content\Creatures\ChaosBeast\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Cheetah")
                                .HasDescriptionFile(@"Content\Creatures\Cheetah\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Chimera")
                                .HasDescriptionFile(@"Content\Creatures\Chimera\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Chimera Skeleton")
                                .HasDescriptionFile(@"Content\Creatures\CelestialCharger\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Choker")
                                .HasDescriptionFile(@"Content\Creatures\Choker\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Chuul")
                                .HasDescriptionFile(@"Content\Creatures\Chuul\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("CelestialCharger")
                                .HasDescriptionFile(@"Content\Creatures\CelestialCharger\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Cloaker")
                                .HasDescriptionFile(@"Content\Creatures\Cloaker\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Cloud Giant")
                                .HasDescriptionFile(@"Content\Creatures\CloudGiants\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Cloud Giant Skeleton")
                                .HasDescriptionFile(@"Content\Creatures\CloudGiantSkeleton\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Cockatrice")
                                .HasDescriptionFile(@"Content\Creatures\Cockatrice\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Centipede, Colossal")
                                .HasDescriptionFile(@"Content\Creatures\CentipedeColossal\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Couatl")
                                .HasDescriptionFile(@"Content\Creatures\Couatl\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Criosphinx")
                                .HasDescriptionFile(@"Content\Creatures\CentipedeColossal\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Crocodile")
                                .HasDescriptionFile(@"Content\Creatures\CentipedeColossal\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();
        }

        private IEnumerable<Creature> AddCreaturesStartingWithG(CreatureBuilderContext ctx)
        {
            var builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Golem, Clay")
                                .HasDescriptionFile(@"Content\Creatures\NightmareCauchemar\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();
        }

        private IEnumerable<Creature> AddCreaturesStartingWithN(CreatureBuilderContext ctx)
        {
            var builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Nightmare, Cauchemar")
                                .HasDescriptionFile(@"Content\Creatures\NightmareCauchemar\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();
        }

        private IEnumerable<Creature> AddCreaturesStartingWithS(CreatureBuilderContext ctx)
        {
            var builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Sperm Whale") //Cachalot
                                .HasDescriptionFile(@"Content\Creatures\SpermWhale\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Scorpion, Colossal")
                                .HasDescriptionFile(@"Content\Creatures\CelestialCharger\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Spider, Colossal")
                                .HasDescriptionFile(@"Content\Creatures\SpiderColossal\description.md")
                                .WithCharacteristic("Huge")
                                .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
                                .HasSkills(initiative: 0)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 94)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
                                .BuildAndReset();

            yield return builder.HasName("Snake, Constrictor")
            .HasDescriptionFile(@"Content\Creatures\SnakeConstrictor\description.md")
            .WithCharacteristic("Huge")
            .HasRacialAbilityScores(strength: 23, agility: 19, focus: 2, charm: 6)
            .HasSkills(initiative: 0)
            .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true, bludgeon: true)
            .WithWeaponCharacteristic("Bite", "Weapon Training, 8")
            .WithCharacteristic("Darkvision")
            .WithMod("Energy", 94)
            .WithMod("Defense", 12)
            .WithMod("Speed", 80)
            .WithSpecialCharacteristic("Leap", @"Content\Creatures\Bulette\leap.md", 10)
            .BuildAndReset();
        }

        private IEnumerable<Creature> AddCreaturesStartingWithT(CreatureBuilderContext ctx)
        {
            var builder = new CreatureBuilder(ctx);
            var creature = builder.HasName("Tojanida, Adult")
                                .HasDescriptionFile(@"Creatures\Tojanida\adult-description.md")
                                .HasAverageHeight("6ft long")
                                .HasAverageWeight("220lbs")
                                .HasLifespan("26 to 80 years old")
                                .HasRacialAbilityScores(strength: 16, agility: 13, focus: 11, charm: 9)
                                .HasSkills(initiative: 1, diplomacy: 1, escapeArtist: 11, stealth: 11, recall: 6, perception: 13, insight: 11, survival: 1, swim: 11)
                                .WithMod("Energy", 45)
                                .WithMod("Defense", 22)
                                .WithMod("Speed", 20)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8")
                                .WithNaturalWeapon("Electricity Ray", WeaponUseAbility.Agility, WeaponUseAbility.Focus, "2d8")
                                .WithCharacteristic("Speak Language", "Aquan")
                                .WithCharacteristic("Cat Like Vision")
                                .WithSpecialCharacteristic("Ink Cloud", @"Creatures\Tojanida\ink-cloud-md", 3)
                                .WithSpecialCharacteristic("All-Around Vision", " The multiple apertures in a tojanida’s shell allow it to look in any direction. Opponents gain no flanking bonuses when attacking a tojanida.", 3)
                                .BuildAndReset();
            yield return creature;
        }

        private IEnumerable<Creature> AddDragons(CreatureBuilderContext ctx)
        {
            throw new System.NotImplementedException();
        }
    }
}