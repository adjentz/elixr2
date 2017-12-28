using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Models;
using System.Linq;
using Elixr2.Api.Services.Seeding.Builders;
using System.Collections.Generic;
using System;

namespace Elixr2.Api.Services.Seeding
{
    public partial class SeedService
    {
        const string atWillSpell = "At Will Spell"; // todo: there should be a spell characteristic for specifying how much Energy
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

            var fuctions = new Func<CreatureBuilderContext, IEnumerable<Creature>>[]
            {
                AddCreaturesStartingWithA, AddCreaturesStartingWithB, AddCreaturesStartingWithC,
                AddCreaturesStartingWithD, AddCreaturesStartingWithE, SeedCreaturesStartingWithF,
                SeedCreaturesStartingWithG, SeedCreaturesStartingWithH, SeedCreaturesStartingWithJ,
                SeedCreaturesStartingWithK, SeedCreaturesStartingWithL, SeedCreaturesStartingWithM,
                SeedCreaturesStartingWithN, SeedCreaturesStartingWithO, SeedCreaturesStartingWithP,
                SeedCreaturesStartingWithR, SeedCreaturesStartingWithS, SeedCreaturesStartingWithT,
                AddCreaturesStartingWithU, SeedCreaturesStartingWithV, SeedCreaturesStartingWithW,
                AddDragons
            };

            foreach (var func in fuctions)
            {
                var creatures = func(context);
                foreach (var creature in creatures)
                {
                    yield return creature;
                }
            }
        }

        private IEnumerable<Creature> AddCreaturesStartingWithA(CreatureBuilderContext ctx)
        {

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
                                .WithSpecialCharacteristic("WhirlwinWhirlwind", @"Content\Creatures\Shared\whirlwind.md", 22, CharacteristicType.Feature, "2", "30", "13", "1d6")
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
                            .WithCharacteristic("Blindsight, 60ft")
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
                                .WithCharacteristic("Gargantuan", "Long")
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
                                .WithCharacteristic("Blindsight, 120ft", "Echolocation")
                                .BuildAndReset();

            var fearInducing = (new WeaponCharacteristicBuilder(standardCampaignSetting)).HasName("Fear Inducing")
                                                                                         .HasDescriptionFile(@"Content\Creatures\BarbedDevil\fear-inducing.md")
                                                                                         .HasSpecificCombatPower(9)
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
                                .WithCharacteristic("Blindsight, 20ft", "Echolocation")
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
                                .WithCharacteristic("Blindsight, 20ft", "Echolocation")
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
                                                                            .HasSpecificCombatPower(-6)
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
                                                                                        .HasSpecificCombatPower(18) // It disolves the targets armor...
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
                                .HasDescription("Camels are known for their ability to travel long distances without food or water.")
                                .HasAverageHeight("7ft at the shoulder, with its hump rising 1 ft higher")
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

            yield return builder.HasName("Cat")
                                .HasDescription("A common housecat.")
                                .WithTemplate("Animal")
                                .WithCharacteristic("Tiny")
                                .HasRacialAbilityScores(strength: 7, agility: 11, focus: 0, charm: 7)
                                .HasSkills(acrobatics: 8, climb: 10, stealth: 10, athletics: 14, perception: 3)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d2", slash: true)
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 2")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d3", pierce: true)
                                .WithWeaponCharacteristic("Bite", "Clumsy Weapon, 3")
                                .WithMod("Energy", 2)
                                .WithMod("Defense", 0)
                                .WithMod("Speed", 60)
                                .BuildAndReset();



            yield return builder.HasName("Centaur")
                                .HasDescriptionFile(@"Content\Templates\centaur.md")
                                .WithTemplate("Centaur")
                                .HasAverageHeight("7ft tall")
                                .HasAverageWeight("2,100lbs")
                                .HasRacialAbilityScores(strength: 10, agility: 10, focus: 12, charm: 11)
                                .HasSkills(perception: 1, stealth: 4, survival: 0)
                                .WithMod("Energy", 24)
                                .WithMod("Defense", 0)
                                .WithMod("Speed", 80)
                                .WithWeapon("Sword, long")
                                .WithWeaponCharacteristic("Sword, long", "Weapon Training, 3")
                                .WithWeaponCharacteristic("Sword, long", "Weapon Specialization, 2")
                                .WithWeapon("Bow, long (composite)")
                                .WithNaturalWeapon("Hooves", WeaponUseAbility.Agility, WeaponUseAbility.Agility, "1d6")
                                .WithWeaponCharacteristic("Hooves", "Weapon Training, 1")
                                .WithCharacteristic("Dodge")
                                .BuildAndReset();

            yield return builder.HasName("Centipede Swarm")
                                .HasDescription("A 10ft by 10ft swarm of centipedes.")
                                .WithTemplate("Swarm")
                                .WithCharacteristic("Minute")
                                .HasRacialAbilityScores(strength: 1, agility: 11, focus: 1, charm: 2)
                                .HasSkills(climb: 16, perception: 8)
                                .WithMod("Energy", 31)
                                .WithMod("Defense", 0)
                                .WithMod("Speed", 40)
                                .WithNaturalWeapon("Swarm", WeaponUseAbility.None, WeaponUseAbility.None, "2d6", pierce: true)
                                .WithSpecialWeaponCharacteristic("Swarm", "Automatic", "At the end of its turn, any creatures that the swarm is sharing a space with automatically takes 2d6 of damage. The swarm does not ever make an attack roll to use this weapon.", 2)
                                .WithWeaponCharacteristic("Swarm", "Poison, 1d4 Agility")
                                .WithCharacteristic("Tremorsense, 30ft")
                                .BuildAndReset();

            yield return builder.HasName("Chain Devil")
                                .HasDescriptionFile(@"Content\Creatures\ChainDevil\description.md")
                                .HasAverageHeight("6ft")
                                .HasAverageWeight("300lbs, including chains")
                                .WithTemplate("Devil")
                                .HasRacialAbilityScores(strength: 15, agility: 15, focus: 8, charm: 12)
                                .HasSkills(initiative: 4, climb: 11, engineer: 18, escapeArtist: 11, intimidate: 10, perception: 14, survival: 3)
                                .WithMod("Energy", 52)
                                .WithMod("Defense", 8)
                                .WithMod("Speed", 60)
                                .WithNaturalWeapon("Chain", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d4", bludgeon: true)
                                .WithWeaponCharacteristic("Chain", "Weapon Training, 8")
                                .WithCharacteristic("Vulnerability, Material", "Silver")
                                .WithCharacteristic("Resistance, Physical")
                                .WithCharacteristic("Immunity, Cold")
                                .WithCharacteristic("Regeneration, 2")
                                .WithCharacteristic("Speak Language", "Infernal")
                                .WithSpecialCharacteristic("Unnerving Gaze", @"Content\Creatures\ChainDevil\unnerving-gaze.md", 3)
                                .WithSpecialCharacteristic("Dancing Chains", @"Content\Creatures\ChainDevil\dancing-chains.md", 32)
                                .BuildAndReset();

            yield return builder.HasName("Chaos Beast")
                                .HasDescriptionFile(@"Content\Creatures\ChaosBeast\description.md")
                                .WithTemplate("Outsider")
                                .HasRacialAbilityScores(strength: 14, agility: 13, focus: 10, charm: 10)
                                .HasSkills(initiative: 4, climb: 11, escapeArtist: 11, stealth: 11, athletics: 7, perception: 11, survival: 2, acrobatics: 13)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d3", slash: true)
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 8")
                                .WithSpecialWeaponCharacteristic("Claw", "Corporeal Instability", @"Content\Creatures\ChaosBeast\corporeal-instability.md", 20)
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 44)
                                .WithMod("Defense", 5)
                                .WithMod("Speed", 40)
                                .WithCharacteristic("Darkvision")
                                .WithSpecialCharacteristic("Immune to transformation", "No spell or special ability can transform a Chaos Beast", 2)
                                .BuildAndReset();

            yield return builder.HasName("Cheetah")
                                .HasDescription("Cheetahs are swift feline predators of the plains.")
                                .HasAverageHeight("3-5ft long")
                                .HasAverageWeight("110-130lbs")
                                .WithTemplate("Animal")
                                .HasRacialAbilityScores(strength: 16, agility: 19, focus: 2, charm: 6)
                                .HasSkills(stealth: 2, perception: 4)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d6", pierce: true)
                                .WithWeaponCharacteristic("Bite", "Tripping")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 19)
                                .WithMod("Defense", 1)
                                .WithMod("Speed", 100)
                                .WithSpecialCharacteristic("Sprint", "Once per hour, a cheetah can move 5 times its normal speed (500 feet) when it makes a charge.", 13)
                                .BuildAndReset();

            var multiplePartsCharacteristic = (new CharacteristicBuilder(ctx.Setting)).HasName("Multiple Parts")
                                                                                      .HasDescriptionFile(@"Content\Creatures\Chimera\multiple-parts.md")
                                                                                      .HasSpecificCombatPower(40)
                                                                                      .Build();

            Dictionary<string, string> lineEnergyTypesByColor = new Dictionary<string, string>
            {
                {"Black", "Acid"},
                {"Blue", "Electric"}
            };
            foreach (var key in lineEnergyTypesByColor.Keys)
            {
                var energyType = lineEnergyTypesByColor[key];
                yield return builder.HasName($"Chimera, {key}")
                                .HasDescriptionFile(@"Content\Creatures\Chimera\description.md")
                                .WithCharacteristic("Large")
                                .HasAverageHeight("5ft tall at the shoulder, 10ft long")
                                .HasAverageWeight("4,000lbs")
                                .HasRacialAbilityScores(strength: 17, agility: 15, focus: 4, charm: 10)
                                .HasSkills(perception: 12, insight: 3, survival: 3, stealth: 1)
                                .WithMod("Energy", 76)
                                .WithMod("Defense", 9)
                                .WithMod("Speed", 50)
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Cat Like Vision")
                                .WithCharacteristic("Fly")
                                .WithNaturalWeapon("Dragon's Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6")
                                .WithWeaponCharacteristic("Dragon's Bite", "Weapon Training, 8")
                                .WithNaturalWeapon("Lion's Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Lion's Bite", "Weapon Training, 8")
                                .WithNaturalWeapon("Goat's Gore", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Goat's Gore", "Weapon Training, 8")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Agility, WeaponUseAbility.Agility, "1d6")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 1")
                                .WithWeaponCharacteristic("Claw", "Weapon Specialization, 1")
                                .WithNaturalWeapon($"{energyType} Breath", WeaponUseAbility.Agility, WeaponUseAbility.None, "0d0", range: 40)
                                .WithWeaponCharacteristic($"{energyType} Breath", $"{energyType}, 3d8")
                                .WithWeaponCharacteristic($"{energyType} Breath", "Targets Acrobatics Defense")
                                .WithWeaponCharacteristic($"{energyType} Breath", "Weapon Training, 4")
                                .WithWeaponCharacteristic($"{energyType} Breath", "Cooldown, 1d4")
                                .WithCharacteristic("Speak Language", "Draconic; rarely")
                                .WithSpecialCharacteristic(multiplePartsCharacteristic)
                                .BuildAndReset();
            }

            Dictionary<string, string> coneEnergyTypesByColor = new Dictionary<string, string>
            {
                {"Green", "Acid"},
                {"Red", "Fire"},
                {"White", "Cold"}
            };

            foreach (var key in coneEnergyTypesByColor.Keys)
            {
                var energyType = coneEnergyTypesByColor[key];
                yield return builder.HasName($"Chimera, {key}")
                                .HasDescriptionFile(@"Content\Creatures\Chimera\description.md")
                                .WithCharacteristic("Large")
                                .HasAverageHeight("5ft tall at the shoulder, 10ft long")
                                .HasAverageWeight("4,000lbs")
                                .HasRacialAbilityScores(strength: 17, agility: 15, focus: 4, charm: 10)
                                .HasSkills(perception: 12, insight: 3, survival: 3, stealth: 1)
                                .WithMod("Energy", 76)
                                .WithMod("Defense", 9)
                                .WithMod("Speed", 50)
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Cat Like Vision")
                                .WithCharacteristic("Fly")
                                .WithNaturalWeapon("Dragon's Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6")
                                .WithWeaponCharacteristic("Dragon's Bite", "Weapon Training, 8")
                                .WithNaturalWeapon("Lion's Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Lion's Bite", "Weapon Training, 8")
                                .WithNaturalWeapon("Goat's Gore", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Goat's Gore", "Weapon Training, 8")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Agility, WeaponUseAbility.Agility, "1d6")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 1")
                                .WithWeaponCharacteristic("Claw", "Weapon Specialization, 1")
                                .WithNaturalWeapon($"{energyType} Breath", WeaponUseAbility.Agility, WeaponUseAbility.None, "0d0")
                                .WithWeaponCharacteristic($"{energyType} Breath", $"{energyType}, 3d8")
                                .WithWeaponCharacteristic($"{energyType} Breath", "Targets Acrobatics Defense")
                                .WithWeaponCharacteristic($"{energyType} Breath", "Conic, 20ft")
                                .WithWeaponCharacteristic($"{energyType} Breath", "Weapon Training, 4")
                                .WithWeaponCharacteristic($"{energyType} Breath", "Cooldown, 1d4")
                                .WithCharacteristic("Speak Language", "Draconic; rarely")
                                .WithSpecialCharacteristic(multiplePartsCharacteristic)
                                .BuildAndReset();
            }

            yield return builder.HasName("Chimera Skeleton")
                                .HasDescription("Skeletons are the animated bones of the dead, mindless automatons that obey the orders of their evil masters.")
                                .WithCharacteristic("Large")
                                .WithTemplate("Undead")
                                .HasRacialAbilityScores(strength: 17, agility: 17, focus: 1, charm: 1)
                                .HasSkills(initiative: 0)
                                .WithMod("Energy", 58)
                                .WithMod("Defense", 2)
                                .WithMod("Speed", 50)
                                .WithNaturalWeapon("Dragon's Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6")
                                .WithWeaponCharacteristic("Dragon's Bite", "Weapon Training, 3")
                                .WithNaturalWeapon("Lion's Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Lion's Bite", "Weapon Training, 3")
                                .WithNaturalWeapon("Goat's Gore", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Goat's Gore", "Weapon Training, 3")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Agility, WeaponUseAbility.Agility, "1d6")
                                .WithSpecialCharacteristic(multiplePartsCharacteristic)
                                .WithCharacteristic("Immunity, Cold")
                                .WithCharacteristic("Resistance, Piercing")
                                .WithCharacteristic("Resistance, Slashing")
                                .BuildAndReset();

            yield return builder.HasName("Choker")
                                .HasDescription("These vicious little predators lurk underground, grabbing whatever prey happens by. Its hands and feet have spiny pads that help the choker grip almost any surface. They seem to be supernaturally quick.")
                                .WithCharacteristic("Small")
                                .HasAverageWeight("35lbs")
                                .HasRacialAbilityScores(strength: 18, agility: 12, focus: 4, charm: 7)
                                .HasSkills(perception: 3, survival: 3, insight: 3, climb: 9, stealth: 8)
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 16)
                                .WithMod("Defense", 4)
                                .WithMod("Speed", 70)
                                .WithNaturalWeapon("Tentacle", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d3")
                                .WithWeaponCharacteristic("Tentacle", "Weapon Training, 3")
                                .WithWeaponCharacteristic("Tentacle", "Latch")
                                .WithWeaponCharacteristic("Tentacle", "Constrict")
                                .WithCharacteristic("Speak Language", "Undercommon")
                                .BuildAndReset();

            yield return builder.HasName("Chuul")
                                .HasDescriptionFile(@"Content\Creatures\Chuul\description.md")
                                .WithCharacteristic("Large")
                                .HasAverageHeight("8ft long")
                                .HasAverageWeight("650lbs")
                                .HasRacialAbilityScores(strength: 18, agility: 18, focus: 10, charm: 5)
                                .HasSkills(perception: 9, insight: 2, survival: 2, stealth: 9, swim: 9, initiative: 4)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 7")
                                .WithWeaponCharacteristic("Claw", "Latch")
                                .WithWeaponCharacteristic("Claw", "Constrict")
                                .WithSpecialCharacteristic("Paralytic Tenatcles", @"Content\Creatures\Chuul\paralytic-tentacles.md", 18)
                                .WithMod("Energy", 93)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 50)
                                .WithCharacteristic("Amphibious", "Prefers land/shallow water")
                                .WithCharacteristic("Blind Fight")
                                .WithCharacteristic("Speak Language", "Undercommon")
                                .BuildAndReset();

            yield return builder.HasName("Cloaker")
                                .HasDescriptionFile(@"Content\Creatures\Cloaker\description.md")
                                .WithCharacteristic("Large")
                                .HasAverageHeight("8ft wingspan")
                                .HasAverageWeight("100lbs")
                                .HasRacialAbilityScores(strength: 19, agility: 18, focus: 14, charm: 15)
                                .HasSkills(perception: 11, stealth: 9, initiative: 4)
                                .WithNaturalWeapon("Tail Slap", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6", reach: true)
                                .WithWeaponCharacteristic("Tail Slap", "Weapon Training, 3")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Agility, "1d4")
                                .WithWeaponCharacteristic("Bite", "Weak Weapon, 1")
                                .WithMod("Energy", 45)
                                .WithMod("Defense", 7)
                                .WithMod("Speed", 70)
                                .WithCharacteristic("Natural Flyer")
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Speak Language", "Undercommon")
                                .WithSpecialCharacteristic("Moan", @"Content\Creatures\Cloaker\moan.md", 9)
                                .WithSpecialCharacteristic("Engulf", @"Content\Creatures\Cloaker\engulf.md", 4)
                                .WithSpecialCharacteristic("Shadow Shift", @"Content\Creatures\Cloaker\shadow-shift.md", 8)
                                .BuildAndReset();

            yield return builder.HasName("Cloud Giant")
                                .HasDescriptionFile(@"Content\Creatures\CloudGiant\description.md")
                                .WithCharacteristic("Huge")
                                .HasSkin("Milky white to light sky blue")
                                .HasHair("Silvery white or brass")
                                .HasEyes("Iridescent blue")
                                .HasAverageHeight("18ft tall")
                                .HasAverageWeight("5,000lbs")
                                .HasLifespan("Up to 400 years")
                                .HasRacialAbilityScores(strength: 31, agility: 17, focus: 12, charm: 13)
                                .HasSkills(insight: 8, survival: 2, perception: 14, climb: 7, engineer: 10, diplomacy: 2, intimidate: 1, perform: 1)
                                .WithMod("Energy", 178)
                                .WithMod("Defense", 12)
                                .WithMod("Speed", 80)
                                .WithArmor("Chain Shirt")
                                .WithNaturalWeapon("Rock", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", bludgeon: true)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 10")
                                .WithNaturalWeapon("Gargantuan Morningstar", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "4d6")
                                .WithWeaponCharacteristic("Gargantuan Morningstar", "Weapon Training, 10")
                                .WithWeaponCharacteristic("Gargantuan Morningstar", "Weapon Specialization, 6")
                                .WithSpell("Fly")
                                .WithSpellCharacteristic("Fly", atWillSpell)
                                .WithSpell("Fog Cloud")
                                .WithSpellCharacteristic("Fog Cloud", atWillSpell)
                                .BuildAndReset();

            yield return builder.HasName("Cloud Giant Skeleton")
                                .HasDescription("Skeletons are the animated bones of the dead, mindless automatons that obey the orders of their evil masters.")
                                .WithCharacteristic("Huge")
                                .WithTemplate("Undead")
                                .HasRacialAbilityScores(strength: 31, agility: 19, focus: 1, charm: 1)
                                .HasSkills(initiative: 4)
                                .WithMod("Energy", 110)
                                .WithMod("Defense", 3)
                                .WithMod("Speed", 80)
                                .WithCharacteristic("Resistance, Bludgeoning")
                                .WithCharacteristic("Resistance, Slashing")
                                .WithNaturalWeapon("Gargantuan Morningstar", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "4d6", pierce: true, bludgeon: true)
                                .WithWeaponCharacteristic("Gargantuan Morningstar", "Weapon Training, 6")
                                .WithWeaponCharacteristic("Gargantuan Morningstar", "Weapon Specialization, 6")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8", slash: true, pierce: true)
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 6")
                                .WithNaturalWeapon("Rock", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", bludgeon: true)
                                .WithWeaponCharacteristic("Rock", "Weapon Training, 6")
                                .BuildAndReset();

            yield return builder.HasName("Cockatrice")
                                .HasDescription("A two-legged dragon or serpent-like creature with a rooster's head. A male cockatrice has wattles and a comb, just like a rooster. Females, much rarer than males, differ only in that they have no wattles or comb.")
                                .HasAverageWeight("25lbs")
                                .WithCharacteristic("Small")
                                .HasRacialAbilityScores(strength: 8, agility: 15, focus: 2, charm: 9)
                                .HasSkills(insight: 5, survival: 5, perception: 11)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d4")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 6")
                                .WithSpecialWeaponCharacteristic("Bite", "Petrifying", "A bite from a cockatrice has has 10% chance of causing the target to turn to stone on a successful attack.\n\nCockatrices are immune to this effect from other cockatrices, but are still susceptible to other petrification attacks.", 10)
                                .WithMod("Energy", 27)
                                .WithMod("Speed", 40)
                                .WithCharacteristic("Fly")
                                .BuildAndReset();

            yield return builder.HasName("Centipede, Colossal")
                                .HasDescription("A colossal sized centipede")
                                .WithCharacteristic("Colossal")
                                .HasRacialAbilityScores(strength: 11, agility: 29, focus: 1, charm: 2)
                                .HasSkills(climb: 8, stealth: 8, perception: 9, insight: 5, survival: 5)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "4d6")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 10")
                                .WithWeaponCharacteristic("Bite", "Weapon Specialization, 4")
                                .WithWeaponCharacteristic("Bite", "Poison, 2d6 Agility")
                                .WithCharacteristic("Darkvision")
                                .WithMod("Energy", 132)
                                .WithMod("Defense", 16)
                                .WithMod("Speed", 0)
                                .BuildAndReset();


            yield return builder.HasName("Criosphinx")
                                .HasDescriptionFile(@"Content\Creatures\Criosphinx\description.md")
                                .WithCharacteristic("Large")
                                .HasRacialAbilityScores(strength: 21, agility: 12, focus: 10, charm: 11)
                                .HasSkills(intimidate: 2, perception: 8)
                                .WithMod("Energy", 85)
                                .WithMod("Defense", 11)
                                .WithMod("Speed", 50)
                                .WithCharacteristic("Fly")
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Cat Like Vision")
                                .WithNaturalWeapon("Gore", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6")
                                .WithWeaponCharacteristic("Gore", "Weapon Training, 9")
                                .WithNaturalWeapon("Claws", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Claws", "Weapon Training, 4")
                                .WithWeaponCharacteristic("Claws", "Weak Weapon, 3")
                                .WithWeaponCharacteristic("Claws", "Rake")
                                .BuildAndReset();

            yield return builder.HasName("Crocodile")
                                .HasDescription("Crocodiles are aggressive predators that lie mostly submerged in rivers or marshes, with only their eyes and nostrils showing, waiting for prey to come within reach.")
                                .WithTemplate("Animal")
                                .HasAverageHeight("11-12ft")
                                .HasRacialAbilityScores(strength: 19, agility: 12, focus: -1, charm: 2)
                                .HasSkills(stealth: 6, perception: 5, swim: 8, insight: 2, survival: 2)
                                .WithMod("Energy", 22)
                                .WithMod("Defense", 4)
                                .WithMod("Speed", 60)
                                .WithCharacteristic("Natural Swimmer")
                                .WithCharacteristic("Camoflage", "When in water")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 2")
                                .WithWeaponCharacteristic("Bite", "Weapon Specialization, 2")
                                .WithNaturalWeapon("Tail Slap", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d12")
                                .WithWeaponCharacteristic("Tail Slap", "Weapon Training, 2")
                                .WithWeaponCharacteristic("Tail Slap", "Weapon Specialization, 2")
                                .BuildAndReset();
        }

        private IEnumerable<Creature> AddCreaturesStartingWithD(CreatureBuilderContext ctx)
        {
            var builder = new CreatureBuilder(ctx);

            yield return builder.HasName("Darkmantle")
                                .HasDescriptionFile(@"Content\Creatures\Darkmantle\description.md")
                                .WithCharacteristic("Small")
                                .HasAverageHeight("4ft tall from the top of its head to its tentacles")
                                .HasAverageWeight("30lbs")
                                .HasRacialAbilityScores(strength: 18, agility: 8, focus: 2, charm: 10)
                                .HasSkills(insight: 4, perception: 9, survival: 4, stealth: 8, initiative: 4)
                                .WithMod("Energy", 6)
                                .WithMod("Defense", 6)
                                .WithMod("Speed", 40)
                                .WithCharacteristic("Fly")
                                .WithCharacteristic("Blindsight, 90ft", "Echolocation")
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d4", bludgeon: true)
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 2")
                                .WithWeaponCharacteristic("Slam", "Weapon Specialization, 1")
                                .WithWeaponCharacteristic("Slam", "Latch")
                                .WithWeaponCharacteristic("Slam", "Constrict")
                                .WithSpell("Darkness")
                                .WithSpellCharacteristic("Darkness", atWillSpell)
                                .BuildAndReset();


            yield return builder.HasName("Delver")
                                .HasDescriptionFile(@"Content\Creatures\Delver\description.md")
                                .WithCharacteristic("Huge")
                                .HasAverageHeight("15ft long and 10ft wide")
                                .HasAverageWeight("6,000lbs")
                                .HasRacialAbilityScores(strength: 23, agility: 17, focus: 14, charm: 12)
                                .HasSkills(recall: 12, perception: 18, stealth: 20, survival: 13, initiative: 4)
                                .WithMod("Energy", 145)
                                .WithMod("Defense", 15)
                                .WithMod("Speed", 40)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 9")
                                .WithSpecialWeaponCharacteristic("Slam", "See: Corrosive Slime", "This creature's Corrosive Slime Feature details additional effects on attacks from this creature", 0)
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Blind Fight")
                                .WithCharacteristic("Immunity, Acid")
                                .WithCharacteristic("Tremorsense, 60ft")
                                .WithSpecialCharacteristic("Stone Shape", @"Content\Creatures\Delver\stone-shape.md", 5)
                                .WithSpecialCharacteristic("Corrosive Slime", @"Content\Creatures\Delver\corrosive-slime.md", 30)
                                .WithSpecialCharacteristic("Burrow", "This creature can burrow through ground at a 3:1 cost to Movement Speed. Meaning, for every 30ft of Speed applied, the delver burrows 10 ft.", 2)
                                .BuildAndReset();


            yield return builder.HasName("Destrachan")
                                .HasDescriptionFile(@"Content\Creatures\Destrachan\description.md")
                                .WithCharacteristic("Large")
                                .HasAverageHeight("10ft long from mouth to tip of the tail")
                                .HasAverageWeight("4,000lbs")
                                .HasRacialAbilityScores(strength: 16, agility: 14, focus: 12, charm: 12)
                                .HasSkills(insight: 3, perception: 24, survival: 8, stealth: 11, initiative: 4)
                                .WithMod("Energy", 60)
                                .WithMod("Defense", 8)
                                .WithMod("Speed", 50)
                                .WithCharacteristic("Blindsight, 100ft", "Excellent hearing")
                                .WithCharacteristic("Resistance, Sonic")
                                .WithCharacteristic("Blind")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 5")
                                .WithNaturalWeapon("Destructive Harmonics: Flesh", WeaponUseAbility.Focus, WeaponUseAbility.None, "4d6")
                                .WithWeaponCharacteristic("Destructive Harmonics: Flesh", "Weapon Training, 4")
                                .WithWeaponCharacteristic("Destructive Harmonics: Flesh", "Targets Acrobatics Defense")
                                .WithWeaponCharacteristic("Destructive Harmonics: Flesh", "Conic, 80ft")
                                .WithNaturalWeapon("Destructive Harmonics: Nerves", WeaponUseAbility.Focus, WeaponUseAbility.None, "4d6")
                                .WithWeaponCharacteristic("Destructive Harmonics: Nerves", "Weapon Training, 4")
                                .WithWeaponCharacteristic("Destructive Harmonics: Nerves", "Targets Acrobatics Defense")
                                .WithWeaponCharacteristic("Destructive Harmonics: Nerves", "Non-Lethal")
                                .WithWeaponCharacteristic("Destructive Harmonics: Nerves", "Conic, 80ft")
                                .WithSpecialCharacteristic("Shatter Objects", "Objects within a 30ft radius take 3d6 points of damage", 10)
                                .BuildAndReset();

            yield return builder.HasName("Devourer")
                                .HasDescriptionFile(@"Content\Creatures\Devourer\description.md")
                                .HasAverageHeight("9ft tall")
                                .HasAverageWeight("500lbs")
                                .WithCharacteristic("Large")
                                .WithCharacteristic("Darkvision")
                                .HasRacialAbilityScores(strength: 26, agility: 12, focus: 16, charm: 17)
                                .HasSkills(initiative: 4, climb: 15, concentration: 15, diplomacy: 2, athletics: 15, perception: 15, stealth: 17, insight: 8, survival: 2)
                                .WithMod("Energy", 78)
                                .WithMod("Defense", 15)
                                .WithMod("Speed", 50)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 6")
                                .WithWeaponCharacteristic("Claw", "Causes Level Loss")
                                .WithNaturalWeapon("Essence Trap", WeaponUseAbility.Strength, WeaponUseAbility.None, "0d0")
                                .WithSpecialWeaponCharacteristic("Essence Trap", "Trap Creature", @"Content\Creatures\Devourer\trap-creature.md", 20)
                                .WithSpecialCharacteristic("Spell Deflection", @"Content\Creatures\Devourer\spell-deflection.md", 10)
                                .WithSpell("Compel")
                                .WithSpell("Reveal")
                                .WithSpell("Necromancy")
                                .WithCharacteristic("Combat Casting")
                                .WithCharacteristic("Resistance, Mind-Affecting")
                                .WithCharacteristic("Resistance, Energy")
                                .BuildAndReset();

            yield return builder.HasName("Digester")
                                .HasDescriptionFile(@"Content\Creatures\Digester\description.md")
                                .HasAverageHeight("5ft tall, 7ft long from snout to tail")
                                .HasAverageWeight("350lbs")
                                .HasRacialAbilityScores(strength: 17, agility: 15, focus: 2, charm: 10)
                                .HasSkills(survival: 4, perception: 10, insight: 4, stealth: 7, athletics: 18, initiative: 4)
                                .WithMod("Energy", 68)
                                .WithMod("Defense", 5)
                                .WithMod("Speed", 120)
                                .WithCharacteristic("Darkvision")
                                .WithCharacteristic("Immunity, Acid")
                                .WithCharacteristic("Cat Like Vision")
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 8")
                                .WithWeaponCharacteristic("Claw", "Weapon Specialization, 1")
                                .WithNaturalWeapon("Acid Spray (Cone)", WeaponUseAbility.Agility, WeaponUseAbility.None, "4d8")
                                .WithWeaponCharacteristic("Acid Spray (Cone)", "Conic, 20ft")
                                .WithWeaponCharacteristic("Acid Spray (Cone)", "Targets Acrobatics Defense")
                                .WithWeaponCharacteristic("Acid Spray (Cone)", "Cooldown, 1d4")
                                .WithNaturalWeapon("Acid Spray (Concentrated)", WeaponUseAbility.Agility, WeaponUseAbility.None, "8d8", range: 5)
                                .WithWeaponCharacteristic("Acid Spray (Concentrated)", "Targets Acrobatics Defense")
                                .WithWeaponCharacteristic("Acid Spray (Concentrated)", "Cooldown, 1d4")
                                .BuildAndReset();


            yield return builder.HasName("Djinni")
                                .HasDescriptionFile(@"Content\Creatures\Djinni\description.md")
                                .WithTemplate("Outsider")
                                .WithCharacteristic("Large")
                                .HasAverageHeight("10-1/2ft tall")
                                .HasAverageWeight("1,000lbs")
                                .HasRacialAbilityScores(strength: 16, agility: 21, focus: 14, charm: 15)
                                .HasSkills(insight: 10, concentration: 10, engineer: 10, diplomacy: 2, escapeArtist: 10, recall: 10, perception: 10, stealth: 12, survival: 3, initiative: 4)
                                .WithMod("Energy", 45)
                                .WithMod("Defense", 3)
                                .WithMod("Speed", 110)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 6")
                                .WithCharacteristic("Natural Flyer")
                                .WithCharacteristic("Combat Casting")
                                .WithCharacteristic("Immunity, Acid")
                                .WithCharacteristic("Speak Language", "Auran")
                                .WithCharacteristic("Speak Language", "Celestial")
                                .WithCharacteristic("Speak Language", "Ignan")
                                .WithSpecialCharacteristic("Air Mastery", "Airborne creatures take a -1 peanlty on attack and damage rolls against a djinni", 1)
                                .WithSpecialCharacteristic("Whirlwind", @"Content\Creatures\Shared\whirlwind.md", 35, CharacteristicType.Feature, "7", "50", "20", "1d8")
                                .WithSpell("Invisibility")
                                .WithSpell("Conjure Object")
                                .WithSpell("Illusion")
                                .WithSpell("Gaseous Form")
                                .WithSpell("Plane Shift")
                                .WithSpell("Telepathy")
                                .BuildAndReset();


            yield return builder.HasName("Dog")
                                .HasDescription("A fairly small dog.")
                                .WithTemplate("Animal")
                                .WithCharacteristic("Small")
                                .HasAverageWeight("20-50lbs")
                                .HasRacialAbilityScores(strength: 15, agility: 15, focus: 0, charm: 6)
                                .HasSkills(insight: 1, survival: 1, perception: 5, athletics: 6)
                                .WithMod("Energy", 6)
                                .WithMod("Defense", 1)
                                .WithMod("Speed", 80)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d4")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 1")
                                .BuildAndReset();


            yield return builder.HasName("Donkey")
                                .HasDescription("These long-eared, horselike creatures are surefooted and sturdy.")
                                .WithTemplate("Animal")
                                .HasRacialAbilityScores(strength: 10, agility: 13, focus: 0, charm: 4)
                                .HasSkills(acrobatics: 2, perception: 3)
                                .WithMod("Energy", 11)
                                .WithMod("Defense", 2)
                                .WithMod("Speed", 60)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.None, "1d2")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 1")
                                .WithSpecialCharacteristic("Carrying Capacity", "A donkey can carry up to 100 pounds with no Speed Penalty. Loads between 101-150lbs (their maximum) cause the donkey's speed to be halved. A donkey can drag 750lbs", 1)
                                .BuildAndReset();

            yield return builder.HasName("Doppelganger")
                        .HasDescriptionFile(@"Content\Creatures\Doppelganger\description.md")
                        .HasSkin("Pale and hairless")
                        .HasEyes("Large and bulging, with yellow slitted pupils")
                        .HasAverageHeight("5-1/2ft in natural form")
                        .HasAverageWeight("150lbs")
                        .HasRacialAbilityScores(strength: 12, agility: 13, focus: 13, charm: 13)
                        .HasSkills(deception: 9, diplomacy: 2, perform: 10, intimidate: 2, perception: 5, insight: 5, concentration: 2)
                        .WithMod("Energy", 22)
                        .WithMod("Defense", 4)
                        .WithMod("Speed", 60)
                        .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6", bludgeon: true)
                        .WithWeaponCharacteristic("Slam", "Weapon Training, 4")
                        .WithSpell("Detect Thoughts")
                        .WithSpellCharacteristic("Detect Thoughts", atWillSpell)
                        .WithSpecialCharacteristic("Change Shape", @"Content\Creatures\Doppelganger\change-shape.md", 4)
                        .WithCharacteristic("Immunity, Mind-Affecting")
                        .BuildAndReset();


            yield return builder.HasName("Dread Wraith")
                                .HasDescriptionFile(@"Content\Creatures\DreadWraith\description.md")
                                .WithTemplates("Undead", "Incorporeal")
                                .HasAverageWeight("0lbs")
                                .HasAverageHeight("9-10ft tall")
                                .HasRacialAbilityScores(strength: -2, agility: 30, focus: 17, charm: 24)
                                .HasSkills(diplomacy: 2, recall: 19, perception: 22, insight: 20, survival: 2, threaten: 19, stealth: 17, initiative: 4)
                                .WithMod("Energy", 104)
                                .WithMod("Defense", 7, "Deflection")
                                .WithMod("Speed", 110)
                                .WithCharacteristics("Large", "Lifesense, 60ft", "Blind Fight", "Natural Flyer", "Daylight Powerlessness")
                                .WithCharacteristic("Speak Language", "Infernal")
                                .WithNaturalWeapon("Incorporeal Touch", WeaponUseAbility.Agility, WeaponUseAbility.None, "2d6")
                                .WithWeaponCharacteristic("Incorporeal Touch", "Ignores Armor")
                                .WithWeaponCharacteristic("Incorporeal Touch", "Weapon Training, 7")
                                .WithWeaponCharacteristic("Incorporeal Touch", "Leech, 1d8")
                                .WithSpecialCharacteristic("Create Spawn", @"Content\Creatures\DreadWraith\create-spawn.md", 10)
                                .WithSpecialCharacteristic("Unnatural Aura", @"Content\Creatures\DreadWraith\unnatural-aura.md", 1)
                                .BuildAndReset();

            // Special Attacks:	Spell-like abilities
            yield return builder.HasName("Dretch")
                                .HasDescriptionFile(@"Content\Creatures\Dretch\description.md")
                                .WithTemplate("Demon")
                                .HasAverageHeight("4ft")
                                .HasAverageWeight("60lbs")
                                .WithCharacteristics("Small", "Resistance, Physical", "Darkvision")
                                .WithCharacteristic("Vulnerability, Material", "Iron")
                                .HasRacialAbilityScores(strength: 14, agility: 8, focus: 5, charm: 11)
                                .HasSkills(survival: 4, insight: 4, perception: 8, stealth: 7)
                                .HasPrimaryStats(energy: 13, defense: 5, speed: 50)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6", slash: true)
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 3")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.None, "1d4", pierce: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 1")
                                .BuildAndReset();

            yield return builder.HasName("Dryad")
                                .HasDescriptionFile(@"Content\Creatures\Dryad\description.md")
                                .HasSkin("Treelike bark")
                                .HasHair("A canopy of leaves that change colors with the seasons")
                                .HasPrimaryStats(energy: 14, defense: 3, speed: 60)
                                .HasRacialAbilityScores(strength: 10, agility: 19, focus: 14, charm: 18)
                                .HasSkills(escapeArtist: 7, animalHandling: 7, stealth: 7, recall: 9, perception: 7, acrobatics: 2, survival: 7, insight: 1)
                                .WithWeapons("Dagger", "Bow, long")
                                .WithWeaponCharacteristic("Dagger", "Weapon Training, 6")
                                .WithWeaponCharacteristic("Bow, long", "Weapon Training, 3")
                                .WithCharacteristics("Resistance, Physical", "Cat Like Vision")
                                .WithCharacteristic("Vulnerability, Material", "Iron")
                                .WithCharacteristic("Speak Language", "Elven")
                                .WithCharacteristic("Speak Language", "Sylvan")
                                .WithSpecialCharacteristic("Tree Dependent", @"Content\Creatures\Dryad\tree-dependent.md", -17, CharacteristicType.Flaw)
                                .WithSpells("Charm", "Compel", "Entangle", "Speak With Entity, Animals")
                                .WithSpellCharacteristic("Entangle", atWillSpell)
                                .BuildAndReset();

            yield return builder.HasName("Dwarf Warrior")
                                .HasDescriptionFile(@"Content\Templates\dwarf.md")
                                .HasRacialAbilityScores(11, 11, 10, 8)
                                .HasSkills(insight: 2, engineer: 2, perception: 2)
                                .HasPrimaryStats(energy: 6, speed: 60)
                                .WithTemplate("Dwarf")
                                .WithArmors("Scale Mail", "Shield")
                                .WithWeapons("Bow, short", "Axe, battle")
                                .WithWeaponCharacteristic("Bow, short", "Weapon Training, 1")
                                .WithWeaponCharacteristic("Axe, battle", "Weapon Training, 2")
                                .WithWeaponCharacteristic("Axe, battle", "Weapon Specialization, 1")
                                .BuildAndReset();

            yield return builder.HasName("Dire Ape")
                                .HasDescription("A large, more feral looking, Ape. Will attack any that enter its territory, even other apes.")
                                .WithTemplate("Animal")
                                .WithCharacteristics("Large")
                                .HasPrimaryStats(energy: 35, defense: 4, speed: 50)
                                .HasRacialAbilityScores(strength: 20, agility: 17, focus: 0, charm: 7)
                                .HasSkills(climb: 12, perception: 5, stealth: 3, survival: 1, insight: 1)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Claw", "Weapon Training, 2")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 1")
                                .WithWeaponCharacteristic("Bite", "Weak Weapon, 3")
                                .WithSpecialCharacteristic("Rend", "When a Dire Ape succeeds on two Claw attacks in the same turn, it automatically deals an additional 2d6+9 points of damage as the flesh is torn", 17)
                                .BuildAndReset();

            yield return builder.HasName("Dire Badger")
                                .HasDescription("A large, more feral looking, Badger. These vicious creatures tolerate no intrusions.")
                                .WithTemplate("Animal")
                                .HasAverageHeight("5-7ft")
                                .HasAverageWeight("500lbs")
                                .HasPrimaryStats(energy: 28, defense: 3, speed: 60)
                                .HasRacialAbilityScores(strength: 14, agility: 17, focus: 0, charm: 10)
                                .HasSkills(perception: 6, insight: 1, survival: 1)
                                .WithNaturalWeapon("Claw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d4")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.None, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Bite", "Clumsy Weapon, 1")
                                .WithSpecialCharacteristic("Burrow", "Can burrow 10ft for every 30ft of Movement Speed applied. Cannot go through solid rock. A dire badger usually leaves a usable tunnel 5ft in diameter when burrowing unless the material it's moving through is very loose.", 2)
                                .WithSpecialCharacteristic("Badger Rage", "A badger that takes damage in combat flies into a berserk rage on its next turn, clawing and biting madly until either it or its opponent is dead. It gains +4 to Strength, +2 to Energy Buffer, and –2 to Defense. The creature cannot end its rage voluntarily.", 3)
                                .BuildAndReset();

            yield return builder.HasName("Dire Rat")
                                .HasDescription("Dire rats are omnivorous scavengers, but will attack to defend their nests and territories.")
                                .WithTemplate("Animal")
                                .WithCharacteristics("Small")
                                .HasAverageHeight("4ft long")
                                .HasAverageWeight("50lbs")
                                .HasPrimaryStats(energy: 5, defense: 1, speed: 80)
                                .HasRacialAbilityScores(strength: 12, agility: 15, focus: -1, charm: 4)
                                .HasSkills(climb: 11, stealth: 5, perception: 4, swim: 11, insight: 1, survival: 1)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.None, "1d4")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 1")
                                .WithSpecialWeaponCharacteristic("Bite", "Disease", "10% chance of contracting a disease 'filth fever'. Agility Score is reduced by 1d3 after 1d3 days", 3)
                                .BuildAndReset();

            yield return builder.HasName("Dire Wolf")
                                .HasDescription("Dire wolves are efficient pack hunters that will kill anything they can catch.")
                                .HasHair("Mottled gray or black hair")
                                .HasAverageHeight("9ft long")
                                .HasAverageWeight("800lbs")
                                .WithTemplate("Animal")
                                .WithCharacteristics("Large")
                                .HasPrimaryStats(energy: 45, defense: 3, speed: 90)
                                .HasRacialAbilityScores(24, 17, 2, 10)
                                .HasSkills(perception: 7, insight: 1, survival: 2)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8", pierce: true)
                                .WithWeaponCharacteristic("Bite", "Tripping")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 3")
                                .WithWeaponCharacteristic("Bite", "Weapon Specialization, 2")
                                .BuildAndReset();


        }

        private IEnumerable<Creature> AddCreaturesStartingWithE(CreatureBuilderContext ctx)
        {
            var builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Eagle")
                                .HasDescription("These birds of prey inhabit nearly every terrain and climate, though they all prefer high, secluded nesting spots.")
                                .HasAverageHeight("3ft long with a wingspan of 7ft")
                                .HasPrimaryStats(energy: 5, defense: 1, speed: 160)
                                .WithCharacteristics("Small", "Natural Flyer")
                                .WithTemplate("Animal")
                                .HasRacialAbilityScores(strength: 12, agility: 13, focus: 0, charm: 6)
                                .HasSkills(perception: 13)
                                .WithNaturalWeapon("Talon", WeaponUseAbility.Agility, WeaponUseAbility.None, "1d4", pierce: true)
                                .WithWeaponCharacteristic("Talon", "Weapon Training, 1")
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.None, "1d4")
                                .WithWeaponCharacteristic("Bite", "Clumsy Weapon, 2")
                                .BuildAndReset();

            yield return builder.HasName("Earth Elemental, Medium")
                                .WithTemplate("Elemental")
                                .HasDescription("A being made of dirt, stones, precious metals, and gems. Earth Elementals reside on the Elemental Plane of Earth")
                                .HasAverageHeight("8ft")
                                .HasAverageWeight("75lbs")
                                .HasPrimaryStats(energy: 30, defense: 9, speed: 40)
                                .HasRacialAbilityScores(strength: 21, agility: 8, focus: 4, charm: 11)
                                .HasSkills(survival: 3, insight: 3, perception: 7)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 3")
                                .WithWeaponCharacteristic("Slam", "Weapon Specialization, 2")
                                .WithSpecialCharacteristic("Earth Superiority", "If both the Elemental and its opponent are touching the ground, the Elemental gets +1 bonus on attack and damage rolls.", 1)
                                .WithSpecialCharacteristic("Air/Water Inferiority", "If an opponent is airborne or waterborne, the elemental takes -4 penalty on attack and damage rolls.", -6, CharacteristicType.Flaw)
                                .WithSpecialCharacteristic("Push", "An opponent's Effective Athletics Defense is considered one less when the elemental attempts a shove maneuver. If this causes the opponent's Acrobatics Defense, they can choose to use that Defense to defend against the maneuver.", 1)
                                .WithSpecialCharacteristic("Earth Glide", "The elemental can glide through stone, dirt, or almost any other sort of earth except metal as easily as fish swims through water. Its burrowing leaves no tunnel or hole, nor does it create any rupple or signs of its presence. This movement has a Speed Cost of 1:1 (5ft for every 5ft travelled)", 7)
                                .WithCharacteristic("Speak Language", "Terran; rarely")
                                .BuildAndReset();


            var flaming = (new WeaponCharacteristicBuilder(ctx.Setting)).HasName("Heat")
                                                                        .HasExtraDamage("1d6")
                                                                        .Build();

            yield return builder.HasName("Efreeti")
                                .WithTemplate("Outsider")
                                .WithCharacteristic("Large")
                                .HasDescription("Genies from the Elemental Plane of Fire\n\nEfreet love to mislead, befuddle, and confuse their foes. They do so for enjoyment as well as a battle tactic.")
                                .HasAverageHeight("12ft")
                                .HasAverageWeight("2,000lbs")
                                .HasPrimaryStats(energy: 65, defense: 6, speed: 50)
                                .HasRacialAbilityScores(strength: 21, agility: 19, focus: 12, charm: 15)
                                .HasSkills(initiative: 4, survival: 1, insight: 14, deception: 13, engineer: 13, concentration: 14, diplomacy: 4, perform: 2, intimidate: 11, perception: 14, stealth: 15, recall: 13)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8")
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 9")
                                .WithSpecialWeaponCharacteristic("Slam", flaming)
                                .WithCharacteristic("Speak Language", "Ignan")
                                .WithCharacteristic("Speak Language", "Infernal")
                                .WithCharacteristic("Speak Language", "Auran")
                                .WithCharacteristics("Fly", "Immunity, Fire", "Vulnerability, Cold", "Combat Casting", "Dodge")
                                .WithSpells("Alter Size", "Energy Blast, Fire", "Detect Energy", "Invisibility", "Wall, Fire", "Gaseous Form", "Illusion", "Plane Shift", "Telepathy")
                                .WithSpell("Alter Reality", "To non-genies only")
                                .WithSpellCharacteristic("Alter Size", atWillSpell)
                                .WithSpellCharacteristic("Detect Energy", atWillSpell)
                                .WithSpellCharacteristic("Energy Blast, Fire", atWillSpell)
                                .WithSpecialCharacteristic("Heat", "When an efreeti begins its turn while in a grapple, the opponent it is grappling with automatically takes 1d6 of fire damage due to the efreeti's red-hot body. This is an attack with 0 Speed Cost.", 4)
                                .BuildAndReset();

            yield return builder.HasName("Elf Warrior")
                                .WithTemplate("Elf")
                                .HasDescriptionFile(@"Content\Templates\Elf.md")
                                .HasPrimaryStats(6, 0, 60)
                                .HasRacialAbilityScores(13, 11, 10, 8)
                                .HasSkills(perception: 2, insight: 3)
                                .WithArmors("Studded Leather", "Buckler")
                                .WithWeapons("Sword, Long", "Bow, Long")
                                .WithWeaponCharacteristic("Bow, Long", "Weapon Training, 1")
                                .BuildAndReset();

            /* Equestrian */
            // Pony
            // Size/Type:	Medium Animal
            // Hit Dice:	2d8+2 (11 hp)
            // Initiative:	+1
            // Speed:	40 ft. (8 squares)
            // Armor Class:	13 (+1 Dex, +2 natural), touch 11, flat-footed 12
            // Full Attack:	2 hooves –3 melee (1d3*)
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 13, Dex 13, Con 12, Int 2, Wis 11, Cha 4
            // Skills:	Listen +5, Spot +5
            // Feats:	Endurance
            // The statistics presented here describe a small horse, under 5 feet tall at the shoulder. Ponies are otherwise similar to light horses and cannot fight while carrying a rider.

            // COMBAT

            // *A pony not trained for war does not normally use its hooves to attack but rather to run. Its hoof attack is treated as a secondary attack and adds only half the pony’s Strength bonus to damage.

            // Carrying Capacity: A light load for a pony is up to 75 pounds; a medium load, 76–150 pounds; and a heavy load, 151–225 pounds. A pony can drag 1,125 pounds.

            // WAr Pony
            // Size/Type:	Medium Animal
            // Hit Dice:	2d8+4 (13 hp)
            // Initiative:	+1
            // Speed:	40 ft. (8 squares)
            // Armor Class:	13 (+1 Dex, +2 natural), touch 11, flat-footed 12
            // Full Attack:	2 hooves +3 melee (1d3+2)
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 15, Dex 13, Con 14, Int 2, Wis 11, Cha 4
            // Skills:	Listen +5, Spot +5
            // Feats:	Endurance

            // COMBAT

            // A warpony can fight while carrying a rider, but the rider cannot also attack unless he or she succeeds on a Ride check.

            // Carrying Capacity: A light load for a warpony is up to 100 pounds; a medium load, 101–200 pounds; and a heavy load, 201–300 pounds. A warpony can drag 1,500 pounds.

            //Heavy Horse
            // Size/Type:	Large Animal
            // Hit Dice:	3d8+6 (19 hp)
            // Initiative:	+1
            // Speed:	50 ft. (10 squares)
            // Armor Class:	13 (–1 size, +1 Dex, +3 natural), touch 10, flat-footed 12
            // Full Attack:	2 hooves –1 melee (1d6+1*)
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 16, Dex 13, Con 15, Int 2, Wis 12, Cha 6
            // Skills:	Listen +4, Spot +4
            // Feats:	Endurance, Run

            // Horses are widely domesticated for riding and as beasts of burden.

            // The statistics presented here describe large breeds of working horses such as Clydesdales. These animals are usually ready for heavy work by age three. A heavy horse cannot fight while carrying a rider.

            // Carrying Capacity: A light load for a heavy horse is up to 200 pounds; a medium load, 201–400 pounds; and a heavy load, 401–600 pounds. A heavy horse can drag 3,000 pounds.

            // COMBAT

            // A horse not trained for war does not normally use its hooves to attack. Its hoof attack is treated as a secondary attack and adds only half the horse’s Strength bonus to damage. (These secondary attacks are noted with an asterisk in the Attack and Full Attack entries for the heavy horse and the light horse.)

            // Light Horse
            // Size/Type:	Large Animal
            // Hit Dice:	3d8+6 (19 hp)
            // Initiative:	+1
            // Speed:	60 ft. (12 squares)
            // Armor Class:	13 (–1 size, +1 Dex, +3 natural), touch 10, flat-footed 12
            // Full Attack:	2 hooves –2 melee (1d4+1*)
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 14, Dex 13, Con 15, Int 2, Wis 12, Cha 6
            // Skills:	Listen +4, Spot +4
            // Feats:	Endurance, Run

            // Horses are widely domesticated for riding and as beasts of burden.

            // The statistics presented here describe smaller breeds of working horses such as quarter horses and Arabians as well as wild horses. These animals are usually ready for useful work by age two.

            // Carrying Capacity: A light load for a light horse is up to 150 pounds; a medium load, 151–300 pounds; and a heavy load, 301–450 pounds. A light horse can drag 2,250 pounds.

            // COMBAT

            // A horse not trained for war does not normally use its hooves to attack. Its hoof attack is treated as a secondary attack and adds only half the horse’s Strength bonus to damage. (These secondary attacks are noted with an asterisk in the Attack and Full Attack entries for the heavy horse and the light horse.)

            // A light horse cannot fight while carrying a rider.

            //HEAVY WARHORSE
            // Size/Type:	Large Animal
            // Hit Dice:	4d8+12 (30 hp)
            // Initiative:	+1
            // Speed:	50 ft. (10 squares)
            // Armor Class:	14 (–1 size, +1 Dex, +4 natural), touch 10, flat-footed 13
            // Full Attack:	2 hooves +6 melee (1d6+4) and bite +1 melee (1d4+2)
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 18, Dex 13, Con 17, Int 2, Wis 13, Cha 6
            // Skills:	Listen +5, Spot +4
            // Feats:	Endurance, Run

            // Horses are widely domesticated for riding and as beasts of burden.

            // These animals are similar to heavy horses but are trained and bred for strength and aggression.

            // Carrying Capacity: A light load for a heavy warhorse is up to 300 pounds; a medium load, 301–600 pounds; and a heavy load, 601–900 pounds. A heavy warhorse can drag 4,500 pounds.

            // COMBAT

            // A horse not trained for war does not normally use its hooves to attack. Its hoof attack is treated as a secondary attack and adds only half the horse’s Strength bonus to damage. (These secondary attacks are noted with an asterisk in the Attack and Full Attack entries for the heavy horse and the light horse.)

            // A heavy warhorse can fight while carrying a rider, but the rider cannot also attack unless he or she succeeds on a Ride check.

            // LIGHT WARHORSE

            // Size/Type:	Large Animal
            // Hit Dice:	3d8+9 (22 hp)
            // Initiative:	+1
            // Speed:	60 ft. (12 squares)
            // Armor Class:	14 (–1 size, +1 Dex, +4 natural), touch 10, flat-footed 13
            // Full Attack:	2 hooves +4 melee (1d4+3) and bite –1 melee (1d3+1)
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 16, Dex 13, Con 17, Int 2, Wis 13, Cha 6
            // Skills:	Listen +4, Spot +4
            // Feats:	Endurance, Run
        }

        private IEnumerable<Creature> SeedCreaturesStartingWithF(CreatureBuilderContext context)
        {
            yield return null;
            var builder = new CreatureBuilder(context);

            var burning = (new WeaponCharacteristicBuilder(context.Setting)).HasName("Burning")
                                                                            .HasExtraDamage("1d6")
                                                                            .HasSpecificCombatPower(5)
                                                                            .HasDescription("Those hit by a slam attack have a 20% chance of catching on fire. The flame burns for 1d4 rounds. At the start of the Elemental's turn, each creature currently aflame takes 1d6 fire damage.\n\nA Creature can extinguish the flames as an action with a Speed Cost of 20ft.")
                                                                            .Build();
            yield return builder.HasName("Fire Elemental, Medium")
                                .WithTemplate("Elemental")
                                .HasDescription("A humanoid being made entirely of vibrant flames. Fire Elementals reside on the Elemental Plane of Fire.")
                                .HasAverageHeight("8ft")
                                .HasAverageWeight("2lbs")
                                .HasPrimaryStats(energy: 26, defense: 3, speed: 80)
                                .HasRacialAbilityScores(strength: 12, agility: 17, focus: 4, charm: 11)
                                .HasSkills(initiative: 4, survival: 3, insight: 3, perception: 6)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8", bludgeon: true)
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 5")
                                .WithSpecialWeaponCharacteristic("Slam", burning)
                                .WithCharacteristic("Speak Language", "Ignan; rarely")
                                .WithSpecialCharacteristic("Fire Body", "Those that attempt an attack using natural weapons/unarmed strike must also make an Acrobatics check with a Difficulty of 14 or take 1d6 of fire damage", 3)
                                .WithCharacteristic("Aversion", "Water")
                                .WithCharacteristics("Vulnerability, Cold", "Immunity, Fire")
                                .BuildAndReset();

            var heated = (new WeaponCharacteristicBuilder(context.Setting)).HasName("Heated")
                                                                           .HasDescription("Fire giants heat their rocks in a nearby fire, geyser, or lava pools, so that they deal extra fire damage.")
                                                                           .HasExtraDamage("1d6")
                                                                           .Build();
            yield return builder.HasName("Fire Giant")
                                .HasDescription("Fire giants wear study cloth or leather garments colored red, orange, yellow, or black.")
                                .HasAverageHeight("12ft")
                                .HasAverageWeight("7,000lbs")
                                .WithCharacteristics("Large", "Immunity, Fire", "Cat Like Vision", "Vulnerability, Cold")
                                .HasHair("Bright orange")
                                .HasPrimaryStats(energy: 142, defense: 8, speed: 60)
                                .HasRacialAbilityScores(strength: 29, agility: 11, focus: 10, charm: 11)
                                .HasSkills(climb: -1, athletics: -1, insight: 2, survival: 2, perception: 14, engineer: 6)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d4", bludgeon: true)
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 10")
                                .WithNaturalWeapon("Rock Throw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6", range: 120, bludgeon: true)
                                .WithSpecialWeaponCharacteristic("Rock Throw", heated)
                                .WithArmors("Half Plate")
                                .WithWeapon("Sword, great", "Some might carry flaming swords instead.")
                                .WithWeaponCharacteristic("Sword, great", "Weapon Training, 10")
                                .WithWeaponCharacteristic("Sword, great", "Weapon Specialization, 5")
                                .BuildAndReset();

            var hiveMind = (new CharacteristicBuilder(context.Setting)).HasName("Hive Mind")
                                                                       .HasDescription("All formians within 50 miles of their queen are in constant communiation. If one is aware of a particular danger, they all are. If one in a group is not flatfooted, none of them are. No formian in a group is considered flanked unless all of them are.")
                                                                       .HasSpecificCombatPower(12)
                                                                       .OfType(CharacteristicType.Feature)
                                                                       .Build();

            yield return builder.HasName("Formian Worker")
                                .WithTemplates("Outsider")
                                .HasDescription(@"A formian resembles a cross between an ant and a centaur.
                                
While workers cannot speak, they can convey simple concepts (such as danger) by body movements. Through the hive mind, however, they can communicate just fine—although their intelligence still limits the concepts that they can grasp.
                                
Its hands are suitable only for manual labor.

Formians are generally aggressive, seeking to subdue all they encounter. If they perceive even the slightest threat to their hive-city or to their queen, they attack immediately and fight to the death. Any formian also attacks immediately if ordered to do so by a superior.")
                                .HasAverageHeight("3ft long, 2-1/2ft high at the front")
                                .HasAverageWeight("60lbs")
                                .HasSkin("Brownish-red carapce")
                                .WithCharacteristics("Small", "Immunity, All Poison", "Immunity, Cold", "Resistance, Electric", "Resistance, Fire", "Resistance, Sonic")
                                .HasPrimaryStats(energy: 5, defense: 4, speed: 90)
                                .HasRacialAbilityScores(15, 12, 6, 9)
                                .HasSkills(insight: 3, survival: 2, perception: 6, climb: 9, engineer: 7, stealth: 2)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Agility, WeaponUseAbility.Strength, "1d4")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 1")
                                .WithSpecialCharacteristic(hiveMind)
                                .WithSpells("Transfer Energy", "Mend")
                                .WithSpellCharacteristic("Transfer Energy", atWillSpell)
                                .WithSpellCharacteristic("Mend", atWillSpell)
                                .BuildAndReset();

            yield return builder.HasName("Formian Warrior")
                                .WithTemplates("Outsider")
                                .HasDescription("A formian resembles a cross between an ant and a centaur.\n\nWarriors communicate through the hive mind to convey battle plans and make reports to their commanders. They cannot speak otherwise.\n\nFormians are generally aggressive, seeking to subdue all they encounter. If they perceive even the slightest threat to their hive-city or to their queen, they attack immediately and fight to the death. Any formian also attacks immediately if ordered to do so by a superior.")
                                .HasAverageHeight("5ft long, 4-1/2ft high at the front")
                                .HasAverageWeight("180lbs")
                                .HasSkin("Brownish-red carapce")
                                .WithCharacteristics("Dodge", "Immunity, All Poison", "Immunity, Cold", "Resistance, Electric", "Resistance, Fire", "Resistance, Sonic")
                                .HasPrimaryStats(energy: 26, defense: 5, speed: 80)
                                .HasRacialAbilityScores(17, 16, 10, 11)
                                .HasSkills(insight: 1, perception: 8, survival: 1, climb: 7, stealth: 7, athletics: 11, acrobatics: 9)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d4")
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 2")
                                .WithWeaponCharacteristic("Bite", "Weak Weapon, 2")
                                .WithNaturalWeapon("Claws", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d6")
                                .WithWeaponCharacteristic("Claws", "Weapon Training, 2")
                                .WithWeaponCharacteristic("Claws", "Weak Weapon, 2")
                                .WithNaturalWeapon("Sting", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d4")
                                .WithWeaponCharacteristic("Sting", "Weapon Training, 4")
                                .WithWeaponCharacteristic("Sting", "Poison, 1d6 Str")
                                .WithSpecialCharacteristic(hiveMind)
                                .WithSpells("Transfer Energy", "Mend")
                                .WithSpellCharacteristic("Transfer Energy", atWillSpell)
                                .WithSpellCharacteristic("Mend", atWillSpell)
                                .BuildAndReset();


            

            yield return builder.HasName("Formian Queen")
                               .WithTemplates("Outsider")
                               .HasDescription("A formian resembles a cross between an ant and a centaur.\n\nThe formian queen cannot move. With her telepathic abilities, though, she can send instructions to and get reports from any formian within her range.")
                               .HasAverageHeight("10ft long, 4ft high at the front")
                               .HasAverageWeight("3,500lbs")
                               .HasSkin("Brownish-red carapce")
                               .WithCharacteristics("Large", "Gimped", "Fast Healing, 2", "Immunity, All Poison", "Immunity, Cold", "Resistance, Electric", "Resistance, Fire", "Resistance, Sonic")
                               .HasPrimaryStats(energy: 190, defense: 19, speed: 20)
                               .HasRacialAbilityScores(-1, 2, 20, 21)
                               .HasSkills(insight: 23, deception: 23, diplomacy: 27, perform: 2, threaten: 25, recall: 23, perception: 25, concentration: 4)
                               .WithSpells("Telepathy", "Energy Blast, Acid", "Daze", "Detect Energy", "Energy Blast, Light", "Mend",
                               "Telekinesis", "Tongues", "Buff", "Energy Blast, Shadow", "Invisibility", "Energy Blast, Fire",
                               "Energy Blast, Cold", "Charm", "Clairvoyance", "Detect Thoughts", "Compel", "Divinate", "Reveal", "Teleport",
                               "Mage Armor", "Hypnotism", "Hope", "Anti-Magic")
                               .WithSpellCharacteristic("Telepathy", atWillSpell)
                               .WithSpecialCharacteristic(hiveMind)
                               .BuildAndReset();


            var cold = (new WeaponCharacteristicBuilder(context.Setting)).HasName("Cold")
                                                                         .HasExtraDamage("1d8")
                                                                         .Build();
            yield return builder.HasName("Frost Worm")
                                .HasDescription("Frost worms lurk under the snow, waiting for prey to come near. \n\n They begin an attack with a trill and then set upon helpless prey with their bite.")
                                .HasAverageHeight("40ft long, 5ft diameter")
                                .HasAverageWeight("8,000lbs")
                                .WithCharacteristics("Huge", "Darkvision", "Immunity, Cold", "Cat Like Vision", "Vulnerability, Fire", "Camoflage")
                                .HasPrimaryStats(energy: 147, defense: 10, speed: 50)
                                .HasRacialAbilityScores(strength: 22, agility: 14, focus: 2, charm: 11)
                                .HasSkills(stealth: 4, initiative: 4, insight: 4, survival: 4, perception: 9)
                                .WithNaturalWeapon("Bite", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d8", pierce: true)
                                .WithWeaponCharacteristic("Bite", "Weapon Training, 13")
                                .WithWeaponCharacteristic("Bite", "Weapon Specialization, 4")
                                .WithSpecialWeaponCharacteristic("Bite", cold)
                                .WithSpecialCharacteristic("Cold Body", "Those that succeed on an attack using natural weapons/unarmed strike automatically take 1d8 of cold damage.", 14)
                                .WithSpecialCharacteristic("Burrow", "For every 15ft of Movement Speed spent, a Frost Worm can tunnel 5ft through ice and frozen earth, but not stone. It leaves behind a usable tunnel ~5ft in diameter.", 3)
                                .WithSpecialCharacteristic("Death Throes", "When killed, a frost worm turns to ice and shatters in an explosion that deals 12d6 points of cold damage and 8d6 points of piercing damage to everything within 100 feet", 80)
                                .WithSpecialCharacteristic("Trill", "A frost worm can emit a noise that forces its prey to stand motionless for 1d4 rounds. This affects all creatures within 100ft that are capable of hearing and have a Concentration Defense lower than 17. This is a mind-affecting ability. If attacked, or shaken by a comrade (an action with a Speed cost of 50ft), a victim is allowed a Concentration check at the start of their next turn. Once a creature is subjected to this ability, the cannot be affected again by that same frost worm's trill for 24 hours.", 40)
                                .WithNaturalWeapon("Breath Weapon", WeaponUseAbility.Agility, WeaponUseAbility.None, "15d6")
                                .WithWeaponCharacteristic("Breath Weapon", "Conic, 30ft")
                                .WithWeaponCharacteristic("Breath Weapon", "Targets Acrobatics Defense")
                                .BuildAndReset();

            yield return builder.HasName("Frost Giant")
                                .HasDescription("Frost giants dress in skins and pelts, along with any jewelry they own. Frost giant warriors add chain shirts and metal helmets decorated with horns or feathers.")
                                .HasAverageHeight("15ft")
                                .HasAverageWeight("2,800lbs")
                                .WithCharacteristics("Large", "Immunity, Cold", "Cat Like Vision", "Vulnerability, Fire")
                                .HasHair("Light blue or dirty yellow")
                                .HasEyes("Matches hair color")
                                .HasPrimaryStats(energy: 133, defense: 9, speed: 70)
                                .HasRacialAbilityScores(strength: 27, agility: 11, focus: 10, charm: 11)
                                .HasSkills(climb: 4, engineer: 6, athletics: 8, perception: 12, insight: 2, survival: 2)
                                .WithNaturalWeapon("Slam", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d4", bludgeon: true)
                                .WithWeaponCharacteristic("Slam", "Weapon Training, 9")
                                .WithNaturalWeapon("Rock Throw", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "2d6", range: 120, bludgeon: true)
                                .WithArmors("Chain Shirt")
                                .WithWeapon("Axe, great", "Some might carry flaming swords instead.")
                                .WithWeaponCharacteristic("Axe, great", "Weapon Training, 9")
                                .WithWeaponCharacteristic("Axe, great", "Weapon Specialization, 4")
                                .BuildAndReset();
        }

        private IEnumerable<Creature> SeedCreaturesStartingWithG(CreatureBuilderContext ctx)
        {
            yield return null;

            //             GARGOYLE

            // Size/Type:	Medium Monstrous Humanoid (Earth)
            // Hit Dice:	4d8+19 (37 hp)
            // Initiative:	+2
            // Speed:	40 ft. (8 squares), fly 60 ft. (average)
            // Armor Class:	16 (+2 Dex, +4 natural), touch 12, flat-footed 14
            // Full Attack:	2 claws +6 melee (1d4+2) and bite +4 melee (1d6+1) and gore +4 melee (1d6+1)
            // Special Qualities:	Damage reduction 10/magic, darkvision 60 ft., freeze
            // Abilities:	Str 15, Dex 14, Con 18, Int 6, Wis 11, Cha 7
            // Skills:	Hide +7*, Listen +4, Spot +4
            // Feats:	Multiattack, Toughness

            // Gargoyles often appear to be winged stone statues, for they can perch indefinitely without moving and use this disguise to surprise their foes. They require no food, water, or air, but often eat their fallen foes out of fondness for inflicting pain.

            // Gargoyles speak Common and Terran.

            // COMBAT

            // Gargoyles either remain still, then suddenly attack, or dive onto their prey.

            // A gargoyle’s natural weapons are treated as magic weapons for the purpose of overcoming damage reduction.

            // Freeze (Ex): A gargoyle can hold itself so still it appears to be a statue. An observer must succeed on a DC 20 Spot check to notice the gargoyle is really alive.

            // Skills: Gargoyles have a +2 racial bonus on Hide, Listen, and Spot checks. *The Hide bonus increases by +8 when a gargoyle is concealed against a background of stone.

            // GHOUL

            // Size/Type:	Medium Undead
            // Hit Dice:	2d12 (13 hp)
            // Initiative:	+2
            // Speed:	30 ft. (6 squares)
            // Armor Class:	14 (+2 Dex, +2 natural), touch 12, flat-footed 12
            // Full Attack:	Bite +2 melee (1d6+1 plus paralysis) and 2 claws +0 melee (1d3 plus paralysis)
            // Special Qualities:	Darkvision 60 ft., undead traits, +2 turn resistance
            // Abilities:	Str 13, Dex 15, Con —, Int 13, Wis 14, Cha 12
            // Skills:	Balance +6, Climb +5, Hide +6, Jump +5, Move Silently +6, Spot +7
            // Feats:	Multiattack

            // Ghouls speak the languages they spoke in life (usually Common).

            // COMBAT

            // Ghouls try to attack with surprise whenever possible. They strike from behind tombstones and burst from shallow graves.

            // Ghoul Fever (Su): Disease—bite, Fortitude DC 12, incubation period 1 day, damage 1d3 Con and 1d3 Dex. The save DC is Charisma-based.

            // An afflicted humanoid who dies of ghoul fever rises as a ghoul at the next midnight. A humanoid who becomes a ghoul in this way retains none of the abilities it possessed in life. It is not under the control of any other ghouls, but it hungers for the flesh of the living and behaves like a normal ghoul in all respects. A humanoid of 4 Hit Dice or more rises as a ghast, not a ghoul.

            // Paralysis (Ex): Those hit by a ghoul’s bite or claw attack must succeed on a DC 12 Fortitude save or be paralyzed for 1d4+1 rounds. Elves have immunity to this paralysis. The save DC is Charisma-based.

            //             GIANT CONSTRICTOR SNAKE

            // Constrictor Snake, Giant
            // Size/Type:	Huge Animal
            // Hit Dice:	11d8+14 (63 hp)
            // Initiative:	+3
            // Speed:	20 ft. (4 squares), climb 20 ft., swim 20 ft.
            // Armor Class:	15 (–2 size, +3 Dex, +4 natural), touch 11, flat-footed 12
            // Full Attack:	Bite +13 melee (1d8+10)
            // Special Attacks:	Constrict 1d8+10, improved grab
            // Special Qualities:	Scent
            // Abilities:	Str 25, Dex 17, Con 13, Int 1, Wis 12, Cha 2
            // Skills:	Balance +11, Climb +17, Hide +10, Listen +9, Spot +9, Swim +16
            // Feats:	Alertness, Endurance, Skill Focus (Hide), Toughness

            // Giant constrictor snakes are more aggressive than their smaller cousins, principally because they need a great amount of food to survive. They hunt for food but do not attempt to make a meal out of any creature that is too large to constrict.

            // Skills: Snakes have a +4 racial bonus on Hide, Listen, and Spot checks and a +8 racial bonus on Balance and Climb checks. A snake can always choose to take 10 on a Climb check, even if rushed or threatened. Snakes use either their Strength modifier or Dexterity modifier for Climb checks, whichever is higher. A snake has a +8 racial bonus on any Swim check to perform some special action or avoid a hazard. It can always choose to take 10 on a Swim check, even if distracted or endangered. It can use the run action while swimming, provided it swims in a straight line.

            // COMBAT

            // Constrictor snakes hunt by grabbing prey with their mouths and then squeezing it with their powerful bodies.

            // Constrict (Ex): On a successful grapple check, a constrictor snake deals 1d8+10 points of damage.

            // Improved Grab (Ex): To use this ability, a constrictor snake must hit with its bite attack. It can then attempt to start a grapple as a free action without provoking an attack of opportunity. If it wins the grapple check, it establishes a hold and can constrict.
            // EAGLE, GIANT

            // Size/Type:	Large Magical Beast
            // Hit Dice:	4d10+4 (26 hp)
            // Initiative:	+3
            // Speed:	10 ft. (2 squares), fly 80 ft. (average)
            // Armor Class:	15 (–1 size, +3 Dex, +3 natural), touch 12, flat-footed 12
            // Full Attack:	2 claws +7 melee (1d6+4) and bite +2 melee (1d8+2)
            // Special Qualities:	Low-light vision, evasion
            // Abilities:	Str 18, Dex 17, Con 12, Int 10, Wis 14, Cha 10
            // Skills:	Knowledge (nature) +2, Listen +6, Sense Motive +4, Spot +15, Survival +3
            // Feats:	Alertness, Flyby Attack

            // A typical giant eagle stands about 10 feet tall, has a wingspan of up to 20 feet, and resembles its smaller cousins in nearly every way except size. It weighs about 500 pounds.

            // Giant eagles speak Common and Auran.

            // COMBAT

            // A giant eagle typically attacks from a great height, diving earthward at tremendous speed. When it cannot dive, it uses its powerful talons and slashing beak to strike at its target’s head and eyes.

            // A solitary giant eagle is typically hunting or patrolling in the vicinity of its nest and generally ignores creatures that do not appear threatening. A mated pair attacks in concert, making repeated diving attacks to drive away intruders, and fights to the death to defend their nest or hatchlings.

            // Evasion (Ex): With a successful Reflex save against an attack that allows a Reflex save for half damage, a giant eagle takes no damage.

            // Skills: Giant eagles have a +4 racial bonus on Spot checks.

            // TRAINING A GIANT EAGLE

            // Although intelligent, a giant eagle requires training before it can bear a rider in combat. To be trained, a giant eagle must have a friendly attitude toward the trainer (this can be achieved through a successful Diplomacy check). Training a friendly giant eagle requires six weeks of work and a DC 25 Handle Animal check.

            // Riding a giant eagle requires an exotic saddle. A giant eagle can fight while carrying a rider, but the rider cannot also attack unless he or she succeeds on a Ride check.

            // Giant eagle eggs are worth 2,500 gp apiece on the open market, while chicks are worth 4,000 gp each. Professional trainers charge 1,000 gp to rear or train a giant eagle.

            // Carrying Capacity: A light load for a giant eagle is up to 300 pounds; a medium load, 301–600 pounds; and a heavy load, 601–900 pounds.

            // OWL, GIANT

            // Size/Type:	Large Magical Beast
            // Hit Dice:	4d10+4 (26 hp)
            // Initiative:	+3
            // Speed:	10 ft. (2 squares), fly 70 ft. (average)
            // Armor Class:	15 (–1 size, +3 Dex, +3 natural), touch 12, flat-footed 12
            // Full Attack:	2 claws +7 melee (1d6+4) and bite +2 melee (1d8+2)
            // Special Qualities:	Superior low-light vision
            // Abilities:	Str 18, Dex 17, Con 12, Int 10, Wis 14, Cha 10
            // Skills:	Knowledge (nature) +2, Listen +17, Move Silently +8*, Spot +10
            // Feats:	Alertness, Wingover

            // Giant owls are nocturnal birds of prey, feared for their ability to hunt and attack in near silence. They are intelligent, and though naturally suspicious, sometimes associate with good creatures. A typical giant owl stands about 9 feet tall, has a wingspan of up to 20 feet, and resembles its smaller cousins in nearly every way except size.

            // Giant owls speak Common and Sylvan.

            // COMBAT

            // A giant owl attacks by gliding silently just a few feet above its prey and plunging to strike when directly overhead.

            // Superior Low-Light Vision (Ex): A giant owl can see five times as far as a human can in dim light.

            // Skills: giant owls have a +8 racial bonus on Listen checks and a +4 racial bonus on Spot checks.

            // When in flight, giant owls gain a +8 bonus on Move Silently checks.
            // TRAINING A GIANT OWL

            // Although intelligent, a giant owl requires training before it can bear a rider in combat. To be trained, a giant owl must have a friendly attitude toward the trainer (this can be achieved through a successful Diplomacy check). Training a friendly giant owl requires six weeks of work and a DC 25 Handle Animal check. Riding a giant owl requires an exotic saddle. A giant owl can fight while carrying a rider, but the rider cannot also attack unless he or she succeeds on a Ride check.

            // Giant owl eggs are worth 2,500 gp apiece on the open market, while chicks are worth 4,000 gp each. Professional trainers charge 1,000 gp to rear or train a giant owl.

            // Carrying Capacity: A light load for a giant owl is up to 300 pounds; a medium load, 301–600 pounds; and a heavy load, 601–900 pounds.

            // GNOME + GOBLIN

            //             GNOME

            // Gnome, 1st-Level Warrior
            // Size/Type:	Small Humanoid (Gnome)
            // Hit Dice:	1d8+2 (6 hp)
            // Initiative:	+0
            // Speed:	20 ft. (4 squares)
            // Armor Class:	16 (+1 size, +4 chain shirt, +1 light shield), touch 11, flat-footed 16
            // Full Attack:	Longsword +2 melee (1d6/19–20) or light crossbow +3 ranged (1d6/19–20)
            // Special Qualities:	Gnome traits
            // Abilities:	Str 11, Dex 11, Con 14, Int 10, Wis 9, Cha 8
            // Skills:	Hide +3, Listen +1, Spot +1
            // Feats:	Weapon Focus (light crossbow)


            // GOBLIN

            // Goblin, 1st-Level Warrior
            // Size/Type:	Small Humanoid (Goblinoid)
            // Hit Dice:	1d8+1 (5 hp)
            // Initiative:	+1
            // Speed:	30 ft. (6 squares)
            // Armor Class:	15 (+1 size, +1 Dex, +2 leather armor, +1 light shield), touch 12, flat-footed 14
            // Full Attack:	Morningstar +2 melee (1d6) or javelin +3 ranged (1d4)
            // Special Qualities:	Darkvision 60 ft.
            // Abilities:	Str 11, Dex 13, Con 12, Int 10, Wis 9, Cha 6
            // Skills:	Hide +5, Listen +2, Move Silently +5, Ride +4, Spot +2
            // Feats:	Alertness

            //             GRAY OOZE

            // Size/Type:	Medium Ooze
            // Hit Dice:	3d10+15 (31 hp)
            // Initiative:	–5
            // Speed:	10 ft. (2 squares)
            // Armor Class:	5 (–5 Dex), touch 5, flat-footed 5
            // Full Attack:	Slam +3 melee (1d6+1 plus 1d6 acid)
            // Special Attacks:	Acid, constrict 1d6+1 plus 1d6 acid, improved grab
            // Special Qualities:	Blindsight 60 ft., immunity to cold and fire, ooze traits, transparent
            // Abilities:	Str 12, Dex 1, Con 21, Int —, Wis 1, Cha 1
            // A gray ooze can grow to a diameter of up to 10 feet and a thickness of about 6 inches. A typical specimen weighs about 700 pounds.

            // COMBAT

            // A gray ooze strikes like a snake, slamming opponents with its body.

            // Acid (Ex): A gray ooze secretes a digestive acid that quickly dissolves organic material and metal, but not stone. Any melee hit or constrict attack deals acid damage. Armor or clothing dissolves and becomes useless immediately unless it succeeds on a DC 16 Reflex save. A metal or wooden weapon that strikes a gray ooze also dissolves immediately unless it succeeds on a DC 16 Reflex save. The save DCs are Constitution-based.

            // The ooze’s acidic touch deals 16 points of damage per round to wooden or metal objects, but the ooze must remain in contact with the object for 1 full round to deal this damage.

            // Constrict (Ex): A gray ooze deals automatic slam and acid damage with a successful grapple check. The opponent’s clothing and armor take a –4 penalty on Reflex saves against the acid.

            // Improved Grab (Ex): To use this ability, a gray ooze must hit with its slam attack. It can then attempt to start a grapple as a free action without provoking an attack of opportunity. If it wins the grapple check, it establishes a hold and can constrict.

            // Transparent (Ex): A gray ooze is hard to identify, even under ideal conditions, and it takes a DC 15 Spot check to notice one. Creatures who fail to notice a gray ooze and walk into it are automatically hit with a melee attack for slam and acid damage.
            // GREEN HAG

            // Size/Type:	Medium Monstrous Humanoid
            // Hit Dice:	9d8+9 (49 hp)
            // Initiative:	+1
            // Speed:	30 ft. (6 squares), swim 30 ft.
            // Armor Class:	22 (+1 Dex, +11 natural), touch 11, flat-footed 21
            // Full Attack:	2 claws +13 melee (1d4+4)
            // Special Attacks:	Spell-like abilities, weakness, mimicry
            // Special Qualities:	Darkvision 90 ft., spell resistance 18
            // Abilities:	Str 19, Dex 12, Con 12, Int 13, Wis 13, Cha 14
            // Skills:	Concentration +7, Craft or Knowledge (any one) +7, Hide +9, Listen +11, Spot +11 Swim +12
            // Feats:	Alertness, Blind Fight, Combat Casting, Great Fortitude

            // Green hags are found in desolate swamps and dark forests.

            // A green hag is about the same height and weight as a female human.

            // COMBAT

            // Green hags prefer to attack from hiding, usually after distracting foes. They often use darkvision to their advantage by attacking during moonless nights.

            // Spell-Like Abilities: At will—dancing lights, disguise self, ghost sound (DC 12), invisibility, pass without trace, tongues, water breathing. Caster level 9th. The save DC is Charisma-based.

            // Weakness (Su): A green hag can weaken a foe by making a special touch attack. The opponent must succeed on a DC 16 Fortitude save or take 2d4 points of Strength damage. The save DC is Charisma-based.

            // Mimicry (Ex): A green hag can imitate the sounds of almost any animal found near its lair.

            // Skills: A green hag has a +8 racial bonus on any Swim check to perform some special action or avoid a hazard. It can always choose to take 10 on a Swim check, even if distracted or endangered. It can use the run action while swimming, provided it swims in a straight line

            //             GRIFFON

            // Size/Type:	Large Magical Beast
            // Hit Dice:	7d10+21 (59 hp)
            // Initiative:	+2
            // Speed:	30 ft. (6 squares), fly 80 ft. (average)
            // Armor Class:	17 (–1 size, +2 Dex, +6 natural), touch 11, flat-footed 15
            // Full Attack:	Bite +11 melee (2d6+4) and 2 claws +8 melee (1d4+2)
            // Special Attacks:	Pounce, rake 1d6+2
            // Special Qualities:	Darkvision 60 ft., low-light vision, scent
            // Abilities:	Str 18, Dex 15, Con 16, Int 5, Wis 13, Cha 8
            // Skills:	Jump +8, Listen +6, Spot +10
            // Feats:	Iron Will, Multiattack, Weapon Focus (bite)

            // Griffons are powerful, majestic creatures with the characteristics of both lions and eagles. From nose to tail, an adult griffon can measure as much as 8 feet. Neither males nor females are endowed with a mane. A pair of broad, golden wings emerge from the creature’s back and span 25 feet or more. A griffon weighs about 500 pounds.

            // A griffon cannot speak, but understands Common.

            // COMBAT

            // Griffons prefer to pounce on their prey, either diving to the attack or leaping from above.

            // Pounce (Ex): If a griffon dives upon or charges a foe, it can make a full attack, including two rake attacks.

            // Rake (Ex): Attack bonus +8 melee, damage 1d6+2.

            // Skills: Griffons have a +4 racial bonus on Jump and Spot checks.

            // TRAINING A GRIFFON

            // Although intelligent, a griffon requires training before it can bear a rider in combat. To be trained, a griffon must have a friendly attitude toward the trainer (this can be achieved through a successful Diplomacy check). Training a friendly griffon requires six weeks of work and a DC 25 Handle Animal check. Riding a griffon requires an exotic saddle. A griffon can fight while carrying a rider, but the rider cannot also attack unless he or she succeeds on a Ride check.

            // Griffon eggs are worth 3,500 gp apiece on the open market, while young are worth 7,000 gp each. Professional trainers charge 1,500 gp to rear or train a griffon.

            // Carrying Capacity: A light load for a griffon is up to 300 pounds; a medium load, 301–600 pounds; and a heavy load, 601–900 pounds.

            //             GYNOSPHINX

            // Size/Type:	Large Magical Beast
            // Hit Dice:	8d10+8 (52 hp)
            // Initiative:	+5
            // Speed:	40 ft. (8 squares), fly 60 ft. (poor)
            // Armor Class:	21 (–1 size, +1 Dex, +11 natural), touch 10, flat-footed 20
            // Full Attack:	2 claws +11 melee (1d6+4)
            // Special Attacks:	Pounce, rake 1d6+2, spell-like abilities
            // Special Qualities:	Darkvision 60 ft., low-light vision
            // Abilities:	Str 19, Dex 12, Con 13, Int 18, Wis 19, Cha 19
            // Skills:	Bluff +15, Concentration +12, Diplomacy +8, Disguise +4 (+6 acting), Intimidate +13, Listen +17, Sense Motive +15, Spot +17
            // Feats:	Combat Casting, Improved Initiative, Iron Will

            // These sphinxes are the female counterparts of androsphinxes.

            // COMBAT

            // In close combat, gynosphinxes use their powerful claws to flay the flesh from their enemies. Despite their deadly nature, they prefer to avoid combat whenever possible.

            // Rake (Ex): Attack bonus +11 melee, damage 1d6+2.

            // Spell-Like Abilities: 3/day—clairaudience/clairvoyance, detect magic, read magic, see invisibility; 1/day—comprehend languages, locate object, dispel magic, remove curse (DC 18), legend lore. Caster level 14th. The save DC is Charisma-based.

            // Once per week a gynosphinx can create a symbol of death, a symbol of fear, a symbol of insanity, a symbol of pain, a symbol of persuasion, a symbol of sleep, and a symbol of stunning as the spells (caster level 18th), except that all save DCs are 22 and each symbol remains a maximum of one week once scribed. The save DCs are Charisma-based.
        }

        private IEnumerable<Creature> SeedCreaturesStartingWithH(CreatureBuilderContext ctx)
        {
            yield return null;

            //             HALFLING

            // Halfling, 1st-Level Warrior
            // Size/Type:	Small Humanoid (Halfling)
            // Hit Dice:	1d8+1 (5 hp)
            // Initiative:	+1
            // Speed:	20 ft. (4 squares)
            // Armor Class:	16 (+1 size, +1 Dex, +3 studded leather, +1 light shield), touch 12, flat-footed 15
            // Full Attack:	Longsword +3 melee (1d6/19–20) or light crossbow +3 ranged (1d6/19–20)
            // Special Attacks:	Halfling traits
            // Special Qualities:	Halfling traits
            // Abilities:	Str 11, Dex 13, Con 12, Int 10, Wis 9, Cha 8
            // Skills:	Climb +2, Hide +4, Jump –4, Listen +3, Move Silently +1
            // Feats:	Weapon Focus (longsword)


            //   HARPY

            // Harpy
            // Size/Type:	Medium Monstrous Humanoid
            // Hit Dice:	7d8 (31 hp)
            // Initiative:	+2
            // Speed:	20 ft. (4 squares), fly 80 ft. (average)
            // Armor Class:	13 (+2 Dex, +1 natural),, touch 12, flat-footed 11
            // Full Attack:	Club +7/+2 melee (1d6) and 2 claws +2 melee (1d3)
            // Special Attacks:	Captivating song
            // Special Qualities:	Darkvision 60 ft.
            // Abilities:	Str 10, Dex 15, Con 10, Int 7, Wis 12, Cha 17
            // Skills:	Bluff +11, Intimidate +7, Listen +7, Perform (oratory) +5, Spot +3
            // Feats:	Dodge, Flyby Attack, Persuasive

            // Harpies like to entrance hapless travelers with their magical songs and lead them to unspeakable torments. Only when a harpy has finished playing with its new “toys” will it release them from suffering by killing and consuming them.

            // COMBAT

            // When a harpy engages in battle, it prefers to use Flyby Attack and strike with a melee weapon.

            // Captivating Song (Su): The most insidious ability of the harpy is its song. When a harpy sings, all creatures (other than harpies) within a 300-foot spread must succeed on a DC 16 Will save or become captivated. This is a sonic mind-affecting charm effect. A creature that successfully saves cannot be affected again by the same harpy’s song for 24 hours. The save DC is Charisma-based.

            // A captivated victim walks toward the harpy, taking the most direct route available. If the path leads into a dangerous area (through flame, off a cliff, or the like), that creature gets a second saving throw. Captivated creatures can take no actions other than to defend themselves. (Thus, a fighter cannot run away or attack but takes no defensive penalties.) A victim within 5 feet of the harpy stands there and offers no resistance to the monster’s attacks. The effect continues for as long as the harpy sings and for 1 round thereafter. A bard’s countersong ability allows the captivated creature to attempt a new Will save.

            // HAWK

            // Size/Type:	Tiny Animal
            // Hit Dice:	1d8 (4 hp)
            // Initiative:	+3
            // Speed:	10 ft. (2 squares), fly 60 ft. (average)
            // Armor Class:	17 (+2 size, +3 Dex, +2 natural), touch 15, flat-footed 14
            // Full Attack:	Talons +5 melee (1d4–2)
            // Special Qualities:	Low-light vision
            // Abilities:	Str 6, Dex 17, Con 10, Int 2, Wis 14, Cha 6
            // Skills:	Listen +2 +4, Spot +14 +16
            // Feats:	Alertness, Weapon FinesseB

            // These creatures are similar to eagles but slightly smaller: 1 to 2 feet long, with wingspans of 6 feet or less.

            // COMBAT

            // Hawks combine both talons into a single attack.

            // HELL HOUND

            // Hellhound
            // Size/Type:	Medium Outsider (Evil, Extraplanar, Fire, Lawful)
            // Hit Dice:	4d8+4 (22 hp)
            // Initiative:	+5
            // Speed:	40 ft. (8 squares)
            // Armor Class:	16 (+1 Dex, +5 natural),, touch 11, flat-footed 15
            // Full Attack:	Bite +5 melee (1d8+1 plus 1d6 fire)
            // Special Attacks:	Breath weapon, fiery bite
            // Special Qualities:	Darkvision 60 ft., immunity to fire, scent, vulnerability to cold
            // Abilities:	Str 13, Dex 13, Con 13, Int 6, Wis 10, Cha 6
            // Skills:	Hide +13, Jump +12, Listen +7, Move Silently +13, Spot +7, Survival +7*
            // Feats:	Improved Initiative, Run, TrackB

            // A typical hell hound stands 4-1/2 feet high at the shoulder and weighs 120 pounds.

            // Hell hounds do not speak but understand Infernal.

            // COMBAT

            // Hell hounds are efficient hunters. A favorite pack tactic is to surround prey quietly, then attack with one or two hounds, driving it toward the rest with their fiery breath. If the prey doesn’t run, the pack closes in. Hell hounds track fleeing prey relentlessly.

            // A hell hound’s natural weapons, as well as any weapons it wields, are treated as evil-aligned and lawful-aligned for the purpose of overcoming damage reduction.

            // Breath Weapon (Su): 10-foot cone, once every 2d4 rounds, damage 2d6 fire, Reflex DC 13 half. The save DC is Constitution-based.

            // Fiery Bite (Su): A hell hound deals an extra 1d6 points of fire damage every time it bites an opponent, as if its bite were a flaming weapon.

            // HILL GIANT

            // Size/Type:	Large Giant
            // Hit Dice:	12d8+48 (102 hp)
            // Initiative:	–1
            // Speed:	30 ft. in hide armor (6 squares); base speed 40 ft.
            // Armor Class:	20 (–1 size, –1 Dex, +9 natural, +3 hide armor), touch 8, flat-footed 20
            // Full Attack:	Greatclub +16/+11 melee (2d8+10) or 2 slams +15 melee (1d4+7) or rock +8 ranged (2d6+7)
            // Special Attacks:	Rock throwing
            // Special Qualities:	Low-light vision, rock catching
            // Abilities:	Str 25, Dex 8, Con 19, Int 6, Wis 10, Cha 7
            // Feats:	Cleave, Improved Bull Rush, Power Attack, Improved Sunder, Weapon Focus (greatclub)

            // Skin color among hill giants ranges from light tan to deep ruddy brown. Their hair is brown or black, with eyes the same color. Hill giants wear layers of crudely prepared hides with the fur left on. They seldom wash or repair their garments, preferring to simply add more hides as their old ones wear out.

            // Adults are about 10-1/2 feet tall and weigh about 1,100 pounds. Hill giants can live to be 200 years old.

            // COMBAT

            // Hill giants prefer to fight from high, rocky outcroppings, where they can pelt opponents with rocks and boulders while limiting the risk to themselves.

            // Hill giants love to make overrun attacks against smaller creatures when they first join battle. Thereafter, they stand fast and swing away with their massive clubs.

            // Rock Throwing (Ex): The range increment is 120 feet for a hill giant’s thrown rocks.

            //             HIPPOGRIFF

            // Size/Type:	Large Magical Beast
            // Hit Dice:	3d10+9 (25 hp)
            // Initiative:	+2
            // Speed:	50 ft. (10 squares), fly 100 ft. (average)
            // Armor Class:	15 (–1 size, +2 Dex, +4 natural), touch 11, flat-footed 13
            // Full Attack:	2 claws +6 melee (1d4+4) and bite +1 melee (1d8+2)
            // Special Qualities:	Darkvision 60 ft., low-light vision, scent
            // Abilities:	Str 18, Dex 15, Con 16, Int 2, Wis 13, Cha 8
            // Skills:	Listen +4, Spot +8
            // Feats:	Dodge, Wingover

            // Hippogriffs are aggressive flying creatures that combine features of horses and giant eagles. Voracious omnivores, hippogriffs will hunt humanoids as readily as any other meal. A typical hippogriff is 9 feet long, has a wingspan of 20 feet, and weighs 1,000 pounds.

            // COMBAT

            // Hippogriffs dive at their prey and strike with their clawed forelegs. When they cannot dive, they slash with claws and beak. Mated pairs and flights of these creatures attack in concert, diving repeatedly to drive away or kill intruders. Hippogriffs fight to the death to defend their nests and their hatchlings, which are prized as aerial mounts and fetch a handsome price in many civilized areas.

            // Skills: Hippogriffs have a +4 racial bonus on Spot checks.

            // TRAINING A HIPPOGRIFF

            // A hippogriff requires training before it can bear a rider in combat.

            // Training a hippogriff requires six weeks of work and a DC 25 Handle Animal check. Riding a hippogriff requires an exotic saddle. A hippogriff can fight while carrying a rider, but the rider cannot also attack unless he or she succeeds on a Ride check.

            // Hippogriff eggs are worth 2,000 gp apiece on the open market, while young are worth 3,000 gp each. Professional trainers charge 1,000 gp to rear or train a hippogriff.

            // Carrying Capacity: A light load for a hippogriff is up to 300 pounds; a medium load, 301–600 pounds; and a heavy load, 601–900 pounds.

            // HORNED DEVIL (CORNUGON)

            // Size/Type:	Large Outsider (Devil, Extraplanar, Evil, Lawful)
            // Hit Dice:	15d8+105 (172 hp)
            // Initiative:	+7
            // Speed:	20 ft. (4 squares), fly 50 ft. (average)
            // Armor Class:	35 (–1 size, +7 Dex, +19 natural), touch 16, flat-footed 28
            // Full Attack:	Spiked chain +25/+20/+15 melee (2d6+15 plus stun) and bite +22 melee (2d8+5) and tail +22 melee (2d6+5 plus infernal wound); or 2 claws +24 melee (2d6+10) and bite + 22 melee (2d8+5) and tail +22 melee (2d6+5 plus infernal wound)
            // Special Attacks:	Fear aura, infernal wound, spell-like abilities, stun, summon devil
            // Special Qualities:	Damage reduction 10/good and silver, darkvision 60 ft., immunity to fire and poison, resistance to acid 10 and cold 10, regeneration 5, see in darkness, spell resistance 28, telepathy 100 ft.
            // Abilities:	Str 31, Dex 25, Con 25, Int 14, Wis 18, Cha 22
            // Skills:	Bluff +24, Climb +28, Concentration +24, Diplomacy +10, Disguise +6 (+8 acting), Hide +21, Intimidate +26, Listen +22, Move Silently +23, Search +20, Sense Motive +22, Spot +22, Survival +4 (+6 following tracks)
            // Feats:	Cleave, Improved Sunder, Iron Will, Multiattack, Power Attack, Weapon Focus (spiked chain)

            // A horned devil is 9 feet tall and weighs about 600 pounds.

            // COMBAT

            // Horned devils are bold fighters. They rarely retreat, even against overwhelming odds. They love to fight with their spiked chains, usually singling out the most powerful foes to stun and eliminate quickly.

            // A horned devil’s natural weapons, as well as any weapons it wields, are treated as evil-aligned and lawful-aligned for the purpose of overcoming damage reduction.

            // Spell-Like Abilities: At will—dispel chaos (DC 21), dispel good (DC 21), magic circle against good, greater teleport (self plus 50 pounds of objects only); persistent image (DC 21) 3/day—fireball (DC 19), lightning bolt (DC 19). Caster level 15th. The save DCs are Charisma-based.

            // Fear Aura (Su): A horned devil can radiate a 5-foot-radius fear aura as a free action. A creature in the area must succeed on a DC 23 Will save or be affected as though by a fear spell (caster level 15th). A creature that successfully saves cannot be affected again by the same horned devil’s aura for 24 hours. Other devils are immune to the aura. The save DC is Charisma-based.

            // Stun (Su): Whenever a horned devil hits with a spiked chain attack, the opponent must succeed on a DC 27 Fortitude save or be stunned for 1d4 rounds. The save DC is Strength-based. This ability is a function of the horned devil, not of the spiked chain.

            // Infernal Wound (Su): The damage a horned devil deals with its tail attack causes a persistent wound. An injured creature loses 2 additional hit points each round. The wound does not heal naturally and resists healing spells. The continuing hit point loss can be stopped by a DC 24 Heal check, a cure spell, or a heal spell. However, a character attempting to cast a cure spell or a heal spell on a creature damaged by a horned devil’s tail must succeed on a DC 24 caster level check, or the spell has no effect on the injured character. A successful Heal check automatically stops the continuing hit point loss as well as restoring hit points. The check DC is Constitution-based.

            // Summon Devil (Sp): Once per day a horned devil can attempt to summon 2d10 lemures or 1d6 bearded devils with a 50% chance of success, 1d6 barbed devils with a 35% chance of success, or another horned devil with a 20% chance of success. This ability is the equivalent of a 6th-level spell.

            // Regeneration (Ex): A horned devil takes normal damage from good-aligned silvered weapons, and from spells or effects with the good descriptor.

            //             Human

            // Human, 1st-Level Warrior
            // Size/Type:	Medium Humanoid (Human)
            // Hit Dice:	1d8+2 (6 hp)
            // Initiative:	+0
            // Speed:	20 ft. in scale mail (4 squares); base speed 30 ft.
            // Armor Class:	16 (+4 scale mail, +2 heavy shield), touch 10, flat-footed 16
            // Full Attack:	Longsword +3 melee (1d8+1/19-20) or Longbow +1 ranged (1d8/x3) or lance +2 melee (1d8+3/x3)
            // Special Attacks:	Human traits
            // Abilities:	Str 13, Dex 11, Con 12, Int 10, Wis 9, Cha 8
            // Skills:	Handle Animal +4, Ride +4
            // Feats:	Weapon Focus (longsword) plus Human Extra Feat


            //             HUMAN WARRIOR SKELETON

            // Human Warrior Skeleton
            // Size/Type:	Medium Undead
            // Hit Dice:	1d12 (6 hp)
            // Initiative:	+5
            // Speed:	30 ft. (6 squares)
            // Armor Class:	15 (+1 Dex, +2 natural, +2 heavy steel shield), touch 11, flat-footed 14
            // Full Attack:	Scimitar +1 melee (1d6+1/18–20) or 2 claws +1 melee (1d4+1)
            // Space/Reach:	5 ft./5 ft.
            // Special Qualities:	Damage reduction 5/bludgeoning, darkvision 60 ft., immunity to cold, undead traits
            // Abilities:	Str 13, Dex 13, Con —, Int —, Wis 10, Cha 1
            // Feats:	Improved Initiative


            //             HUMAN ZOMBIE

            // Human Commoner Zombie
            // Size/Type:	Medium Undead
            // Hit Dice:	2d12+3 (16 hp)
            // Initiative:	–1
            // Speed:	30 ft. (6 squares; can’t run)
            // Armor Class:	11 (–1 Dex, +2 natural), touch 9, flat-footed 11
            // Full Attack:	Slam+2 melee, (1d6+1) or club +2 melee (1d6+1)
            // Special Qualities:	Single actions only, damage reduction 5/slashing, darkvision 60 ft., undead traits
            // Abilities:	Str 12, Dex 8, Con —, Int —, Wis 10, Cha 1
            // Feats:	Toughness


            //             Hyena

            // Size/Type:	Medium Animal
            // Hit Dice:	2d8+4 (13 hp)
            // Initiative:	+2
            // Speed:	50 ft. (10 squares)
            // Armor Class:	14 (+2 Dex, +2 natural), touch 12, flat-footed 12
            // Full Attack:	Bite +3 melee (1d6+3)
            // Special Attacks:	Trip
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 14, Dex 15, Con 15, Int 2, Wis 13, Cha 6
            // Skills:	Hide +3*, Listen +6, Spot +4
            // Feats:	Alertness

            // Hyenas are pack hunters infamous for their cunning and their unnerving vocalizations. The statistics presented here are for a striped hyena, which is about 3 feet long and weighs about 120 pounds.

            // Combat

            // A favorite tactic is to send a few individuals against the foe’s front while the rest of the pack circles and attacks from the flanks or rear.

            // Trip (Ex): A hyena that hits with its bite attack can attempt to trip the opponent (+2 check modifier) as a free action without making a touch attack or provoking an attack of opportunity. If the attempt fails, the opponent cannot react to trip the hyena.
        }

        private IEnumerable<Creature> SeedCreaturesStartingWithI(CreatureBuilderContext ctx)
        {
            yield return null;

            //             ICE DEVIL (GELUGON)

            // Size/Type:	Large Outsider (Devil, Extraplanar, Evil, Lawful)
            // Hit Dice:	14d8+84 (147 hp)
            // Initiative:	+5
            // Speed:	40 ft. (8 squares)
            // Armor Class:	32 (–1 size, +5 Dex, +18 natural), touch 14, flat-footed 27
            // Full Attack:	Spear +20/+15/+10 melee (2d6+9/x3 plus slow) and bite +14 melee (2d6+3) and tail +14 melee (3d6+3 plus slow); or 2 claws +19 melee (1d10+6) and bite +14 melee (2d6+3) and tail +14 melee (3d6+3 plus slow)
            // Special Attacks:	Fear aura, slow, spell-like abilities, summon devil
            // Special Qualities:	Damage reduction 10/good, darkvision 60 ft., immunity to fire and poison, resistance to acid 10 and cold 10, regeneration 5, see in darkness, spell resistance 25, telepathy 100 ft.
            // Abilities:	Str 23, Dex 21, Con 23, Int 22, Wis 22, Cha 20
            // Skills:	Bluff +22, Climb +23, Concentration +23, Diplomacy +9, Disguise +5 (+7 acting), Intimidate +24, Jump +27, Knowledge (any three) +23, Listen +25, Move Silently +22, Search +23, Sense Motive +23, Spellcraft +23, Spot +25, Survival +6 (+8 following tracks)
            // Feats:	Alertness, Cleave, Combat Reflexes, Power Attack, Weapon Focus (spear)

            // An ice devil is about 12 feet tall and weighs about 700 pounds.

            // COMBAT

            // An ice devil prefers to fight only when doing so serves its mission, but it never hesitates to attack when it deems a battle necessary—or likely to end in its victory.

            // An ice devil’s natural weapons, as well as any weapons it wields, are treated as evil-aligned and lawful-aligned for the purpose of overcoming damage reduction.

            // Fear Aura (Su): An ice devil can radiate a 10-foot-radius fear aura as a free action. A creature in the area must succeed on a DC 22 Will save or be affected as though by a fear spell (caster level 13th). A creature that successfully saves cannot be affected again by the same ice devil’s aura for 24 hours. Other devils are immune to the aura. The save DC is Charisma-based.

            // Slow (Su): A hit from an ice devil’s tail or spear induces numbing cold. The opponent must succeed on a DC 23 Fortitude save or be affected as though by a slow spell for 1d6 rounds. The save DC is Constitution-based.

            // Spell-Like Abilities: At will—cone of cold (DC 20), fly, ice storm (DC 19), greater teleport (self plus 50 pounds of objects only), persistent image (DC 20), unholy aura (DC 23), wall of ice (DC 19). Caster level 13th. The save DCs are Charisma-based.

            // Summon Devil (Sp): Once per day an ice devil can attempt to summon 2d10 lemures or 1d6 bearded devils, 2d4 bone devils with a 50% chance of success, or another ice devil with a 20% chance of success. This ability is the equivalent of a 4th-level spell.

            // Regeneration (Ex): An ice devil takes normal damage from good-aligned weapons and from spells or effects with the good descriptor.

            //             IMP

            // Size / Type:	Tiny Outsider(Evil, Extraplanar, Lawful)
            // Hit Dice:	3d8(13 hp)
            // Initiative: +3
            // Speed: 20 ft. (4 squares), fly 50 ft. (perfect)
            // Armor Class:	20(+2 size, +3 Dex, +5 natural), touch 15, flat - footed 17
            // Full Attack:	Sting + 8 melee(1d4 plus poison)
            // Special Attacks:	Poison, spell - like abilities
            //   Special Qualities: Alternate form, damage reduction 5 / good or silver, darkvision 60 ft., fast healing 2, immunity to poison, resistance to fire 5
            // Abilities: Str 10, Dex 17, Con 10, Int 10, Wis 12, Cha 14
            // Skills: Diplomacy + 8, Hide + 17, Knowledge(any one) + 6, Listen + 7, Move Silently +9, Search + 6, Spellcraft + 6, Spot + 7, Survival + 1(+3 following tracks)
            // Feats: Dodge, Weapon Finesse

            // In its natural form, an imp stands almost 2 feet tall and weighs about 8 pounds.

            // COMBAT

            // Imps are craven, but not so timid as to pass up an opportunity for a surprise attack using their invisibility and alternate form ability. In its natural form, an imp attacks with the wicked stinger on its tail.It quickly flies out of reach if a foe manages to strike back effectively.

            // An imp’s natural weapons, as well as any weapons it wields, are treated as evil - aligned and lawful-aligned for the purpose of overcoming damage reduction.

            //   Poison(Ex): Injury, Fortitude DC 13, initial damage 1d4 Dex, secondary damage 2d4 Dex.The save DC is Constitution - based and includes a + 2 racial bonus.

            //   Spell - Like Abilities: At will—detect good, detect magic, invisibility(self only); 1 / day—suggestion(DC 15).Caster level 6th.The save DC is Charisma - based.

            // Once per week an imp can use commune to ask six questions. The ability otherwise works as the spell(caster level 12th).

            // Alternate Form(Su): An imp can assume another form at will as a standard action. Each imp can assume one or two forms from the following list: Small or Medium monstrous spider, raven, rat, and boar.


        }

        private IEnumerable<Creature> SeedCreaturesStartingWithJ(CreatureBuilderContext ctx)
        {
            yield return null;

            // JANNI

            // Size/Type:	Medium Outsider (Native)
            // Hit Dice:	6d8+6 (33 hp)
            // Initiative:	+6
            // Speed:	20 ft. (4 squares), fly 15 ft. (perfect) in chainmail; base land speed 30 ft., base fly speed 20 ft. (perfect)
            // Armor Class:	18 (+2 Dex, +1 natural, +5 chainmail), touch 12, flat-footed 16
            // Full Attack:	Scimitar +9/+4 melee (1d6+4/18–20) or longbow +8/+3 ranged (1d8/x3)
            // Special Attacks:	Change size, spell-like abilities
            // Special Qualities:	Darkvision 60 ft., elemental endurance, plane shift, resistance to fire 10, telepathy 100 ft.
            // Abilities:	Str 16, Dex 15, Con 12, Int 14, Wis 15, Cha 13
            // Skills:	Appraise +11, Concentration +10, Craft (any two) +11, Diplomacy +3, Escape Artist +6, Listen +11, Move Silently +6, Ride +11, Sense Motive +11, Spot +11, Use Rope +2 (+4 with bindings)
            // Feats:	Combat Reflexes, Dodge, Improved InitiativeB, Mobility

            // The jann (singular janni) are the weakest of the genies. Jann are formed out of all four elements and must therefore spend most of their time on the Material Plane.

            // Jann speak Common, one elemental language (Aquan, Auran, Ignan, or Terran) and one alignment language (Abyssal, Celestial, or Infernal).

            // COMBAT

            // Jann are physically strong and courageous, and do not take kindly to insult or injury. If they meet a foe they cannot defeat in a standup fight, they use flight and invisibility to regroup and maneuver to a more advantageous position.

            // Change Size (Sp): Twice per day, a janni can magically change a creature’s size. This works just like an enlarge person or reduce person spell (the janni chooses when using the ability), except that the ability can work on the janni. A DC 13 Fortitude save negates the effect. The save DC is Charisma-based. This is the equivalent of a 2nd-level spell.

            // Spell-Like Abilities: 3/day—invisibility (self only), speak with animals. Caster level 12th. Once per day a janni can create food and water (caster level 7th) and can use ethereal jaunt (caster level 12th) for 1 hour. The save DCs are Charisma-based.

            // Elemental Endurance (Ex): Jann can survive on the Elemental Planes of Air, Earth, Fire, or Water for up to 48 hours. Failure to return to the Material Plane before that time expires causes a janni to take 1 point of damage per additional hour spent on the elemental plane, until it dies or returns to the Material Plane.
        }
        private IEnumerable<Creature> SeedCreaturesStartingWithK(CreatureBuilderContext ctx)
        {
            yield return null;

            // KOBOLD

            // Kobold, 1st-Level Warrior
            // Size/Type:	Small Humanoid (Reptilian)
            // Hit Dice:	1d8 (4 hp)
            // Initiative:	+1
            // Speed:	30 ft. (6 squares)
            // Armor Class:	15 (+1 size, +1 Dex, +1 natural, +2 leather), touch 12, flat-footed 14
            // Full Attack:	Spear +1 melee (1d6–1/x3) or sling +3 ranged (1d3)
            // Special Qualities:	Darkvision 60 ft., light sensitivity
            // Abilities:	Str 9, Dex 13, Con 10, Int 10, Wis 9, Cha 8
            // Skills:	Craft (trapmaking) +2, Hide +6, Listen +2, Move Silently +2, Profession (miner) +2, Search +2, Spot +2
            // Feats:	Alertness
            // Kobolds are short, reptilian humanoids with cowardly and sadistic tendencies.

            // A kobold’s scaly skin ranges from dark rusty brown to a rusty black color. It has glowing red eyes. Its tail is nonprehensile. Kobolds wear ragged clothing, favoring red and orange. A kobold is 2 to 2-1/2 feet tall and weighs 35 to 45 pounds. Kobolds speak Draconic with a voice that sounds like that of a yapping dog.

            // COMBAT

            // Kobolds like to attack with overwhelming odds—at least two to one—or trickery; should the odds fall below this threshold, they usually flee. However, they attack gnomes on sight if their numbers are equal.

            // They begin a fight by slinging bullets, closing only when they can see that their foes have been weakened. Whenever they can, kobolds set up ambushes near trapped areas.

            // Light Sensitivity (Ex): Kobolds are dazzled in bright sunlight or within the radius of a daylight spell.

            // Skills: Kobolds have a +2 racial bonus on Craft (trapmaking), Profession (miner), and Search checks.

            // The kobold warrior presented here had the following ability scores before racial adjustments: Str 13, Dex 11, Con 12, Int 10, Wis 9, Cha 8.

            // Challenge Rating: Kobolds with levels in NPC classes have a CR equal to their character level –3.

            // KOBOLD CHARACTERS

            // Kobold characters possess the following racial traits.

            // –4 Strength, +2 Dexterity, –2 Constitution.
            // Small size: +1 bonus to Armor Class, +1 bonus on attack rolls, +4 bonus on Hide checks, –4 penalty on grapple checks, lifting and carrying limits 3/4 those of Medium characters.
            // A kobold’s base land speed is 30 feet.
            // Darkvision out to 60 feet.
            // Racial Skills: A kobold character has a +2 racial bonus on Craft (trapmaking), Profession (miner), and Search checks.
            // Racial Feats: A kobold character gains feats according to its character class.
            // +1 natural armor bonus.
            // Special Qualities (see above): Light sensitivity.
            // Automatic Languages: Draconic. Bonus Languages: Common, Undercommon.
            // Favored Class: Sorcerer.
            // Level adjustment +0.

            //             KRAKEN

            // Size/Type:	Gargantuan Magical Beast (Aquatic)
            // Hit Dice:	20d10+180 (290 hp)
            // Initiative:	+4
            // Speed:	Swim 20 ft. (4 squares)
            // Armor Class:	20 (–4 size, +14 natural), touch 6, flat-footed 20
            // Full Attack:	2 tentacles +28 melee (2d8+12/19–20) and 6 arms +23 melee (1d6+6) and bite +23 melee (4d6+6)
            // Special Attacks:	Improved grab, constrict 2d8+12 or 1d6+6
            // Special Qualities:	Darkvision 60 ft., ink cloud, jet, low-light vision, spell-like abilities
            // Abilities:	Str 34, Dex 10, Con 29, Int 21, Wis 20, Cha 20
            // Skills:	Concentration +21, Diplomacy +7, Hide +0, Intimidate +16, Knowledge (geography) +17, Knowledge (nature) +16, Listen +30, Search +28, Sense Motive +17, Spot +30, Survival +5 (+7 following tracks), Swim +20, Use Magic Device +16
            // Feats:	Alertness, Blind Fight, Combat Expertise, Improved Critical (tentacle), Improved Initiative, Improved Trip, Iron Will

            // Six of the beast’s tentacles are shorter arms about 30 feet long; the remaining two are nearly 60 feet long and covered with barbs. Its beaklike mouth is located where the tentacles meet the lower portion of its body.

            // Krakens speak Common and Aquan.

            // COMBAT

            // Krakens strike their opponents with their barbed tentacles, then grab and crush with their arms or drag victims into their huge jaws. An opponent can make sunder attempts against a kraken’s tentacles or arms as if they were weapons. A kraken’s tentacles have 20 hit points, and its arms have 10 hit points. If a kraken is currently grappling a target with one tentacle or arm, it usually uses another limb to make its attack of opportunity against the sunder attempt. Severing a kraken’s tentacle or arm deals damage to the kraken equal to half the limb’s full normal hit points. A kraken usually withdraws from combat if it loses both tentacles or three of its arms. A kraken regrows severed limbs in 1d10+10 days.

            // Improved Grab (Ex): To use this ability, the kraken must hit with an arm or tentacle attack. It can then attempt to start a grapple as a free action without provoking an attack of opportunity. If it wins the grapple check, it establishes a hold and can constrict.

            // Constrict (Ex): A kraken deals automatic arm or tentacle damage with a successful grapple check.

            // Jet (Ex): A kraken can jet backward once per round as a full-round action, at a speed of 280 feet. It must move in a straight line, but does not provoke attacks of opportunity while jetting.

            // Ink Cloud (Ex): A kraken can emit a cloud of jet-black ink in an 80-foot spread once per minute as a free action. The cloud provides total concealment, which the kraken normally uses to escape a fight that is going badly. Creatures within the cloud are considered to be in darkness.

            // Spell-Like Abilities: 1/day—control weather, control winds, dominate animal (DC 18), resist energy. Caster level 9th. The save DC is Charisma-based.
        }
        private IEnumerable<Creature> SeedCreaturesStartingWithL(CreatureBuilderContext ctx)
        {
            yield return null;

            // LION

            // Size/Type:	Large Animal
            // Hit Dice:	5d8+10 (32 hp)
            // Initiative:	+3
            // Speed:	40 ft. (8 squares)
            // Armor Class:	15 (–1 size, +3 Dex, +3 natural), touch 12, flat-footed 12
            // Full Attack:	2 claws +7 melee (1d4+5) and bite +2 melee (1d8+2)
            // Special Attacks:	Pounce, improved grab, rake 1d4+2
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 21, Dex 17, Con 15, Int 2, Wis 12, Cha 6
            // Skills:	Balance +7, Hide +3*, Listen +5, Move Silently +11, Spot +5
            // Feats:	Alertness, Run

            // The statistics presented here describe a male African lion, which is 5 to 8 feet long and weighs 330 to 550 pounds. Females are slightly smaller but use the same statistics.

            // COMBAT

            // Pounce (Ex): If a lion charges a foe, it can make a full attack, including two rake attacks.

            // Improved Grab (Ex): To use this ability, a lion must hit with its bite attack. It can then attempt to start a grapple as a free action without provoking an attack of opportunity. If it wins the grapple check, it establishes a hold and can rake.

            // Rake (Ex): Attack bonus +7 melee, damage 1d4+2.

            // LIZARD

            // Size/Type:	Tiny Animal
            // Hit Dice:	1/2 d8 (2 hp)
            // Initiative:	+2
            // Speed:	20 ft. (4 squares), climb 20 ft.
            // Armor Class:	14 (+2 size, +2 Dex), touch 14, flat-footed 12
            // Full Attack:	Bite +4 melee (1d4–4)
            // Special Qualities:	Low-light vision
            // Abilities:	Str 3, Dex 15, Con 10, Int 1, Wis 12, Cha 2
            // Skills:	Balance +10, Climb +12, Hide +10 +12, Listen +3, Move Silently +4, Spot +3
            // Feats:	Stealthy, Weapon FinesseB

            // The statistics presented here describe small, nonvenomous lizards of perhaps a foot or two in length, such as an iguana.

            // COMBAT

            // Lizards prefer flight to combat, but they can bite painfully if there is no other option.

            // LOCUST SWARM

            // Size/Type:	Diminutive Vermin (Swarm)
            // Hit Dice:	6d8–6 (21 hp)
            // Initiative:	+4
            // Speed:	10 ft. (2 squares), fly 30 ft. (poor)
            // Armor Class:	18 (+4 size, +4 Dex), touch 18, flat-footed 14
            // Full Attack:	Swarm (2d6)
            // Special Attacks:	Distraction
            // Special Qualities:	Darkvision 60 ft., immune to weapon damage, swarm traits, vermin traits
            // Abilities:	Str 1, Dex 19, Con 8, Int —, Wis 10, Cha 2
            // Skills:	Listen +4, Spot +4

            // A locust swarm is a cloud of thousands of winged vermin that devours any organic material in its path.

            // COMBAT

            // A locust swarm surrounds and attacks any living prey it encounters. A swarm deals 2d6 points of damage to any creature whose space it occupies at the end of its move.

            // Distraction (Ex): Any living creature that begins its turn with a locust swarm in its space must succeed on a DC 12 Fortitude save or be nauseated for 1 round. The save DC is Constitution-based.


        }
        private IEnumerable<Creature> SeedCreaturesStartingWithM(CreatureBuilderContext ctx)
        {
            yield return null;

            // MANTICORE

            // Size/Type:	Large Magical Beast
            // Hit Dice:	6d10+24 (57 hp)
            // Initiative:	+2
            // Speed:	30 ft. (6 squares), fly 50 ft. (clumsy)
            // Armor Class:	17 (–1 size, +2 Dex, +6 natural), touch 11, flat-footed 15
            // Full Attack:	2 claws +10 melee (2d4+5) and bite +8 melee (1d8+2); or 6 spikes +8 ranged (1d8+2/19–20)
            // Special Attacks:	Spikes
            // Special Qualities:	Darkvision 60 ft., low-light vision, scent
            // Abilities:	Str 20, Dex 15, Con 19, Int 7, Wis 12, Cha 9
            // Skills:	Listen +5, Spot +9, Survival +1
            // Feats:	Flyby Attack, Multiattack, TrackB, Weapon Focus (spikes)

            // A typical manticore is about 10 feet long and weighs about 1,000 pounds. Manticores speak Common.

            // COMBAT

            // A manticore begins most attacks with a volley of spikes, then closes. In the outdoors, it often uses its powerful wings to stay aloft during battle.

            // Spikes (Ex): With a snap of its tail, a manticore can loose a volley of six spikes as a standard action (make an attack roll for each spike). This attack has a range of 180 feet with no range increment. All targets must be within 30 feet of each other. The creature can launch only twenty-four spikes in any 24-hour period.

            // MEDUSA

            // Size/Type:	Medium Monstrous Humanoid
            // Hit Dice:	6d8+6 (33 hp)
            // Initiative:	+2
            // Speed:	30 ft. (6 squares)
            // Armor Class:	15 (+2 Dex, +3 natural), touch 12, flat-footed 13
            // Full Attack:	Shortbow +8/+3 ranged (1d6/x3); or dagger +8/+3 melee (1d4/19–20) and snakes +3 melee (1d4 plus poison)
            // Special Attacks:	Petrifying gaze, poison
            // Special Qualities:	Darkvision 60 ft.
            // Abilities:	Str 10, Dex 15, Con 12, Int 12, Wis 13, Cha 15
            // Skills:	Bluff +9, Diplomacy +4, Disguise +9 (+11 acting), Intimidate +4, Move Silently +8, Spot +8
            // Feats:	Point Blank Shot, Precise Shot, Weapon Finesse

            // A medusa is indistinguishable from a normal human at distances greater than 30 feet (or closer, if its face is concealed). The creature often wears garments that enhance its body while hiding its face behind a hood or veil.

            // A typical medusa is 5 to 6 feet tall and about the same weight as a human.

            // Medusas speak Common.

            // COMBAT

            // A medusa tries to disguise its true nature until the intended victim is within range of its petrifying gaze, using subterfuge and bluffing games to convince the target that there is no danger. It uses normal weapons to attack those who avert their eyes or survive its gaze, while its poisonous snakes strike at adjacent opponents.

            // Petrifying Gaze (Su): Turn to stone permanently, 30 feet, Fortitude DC 15 negates. The save DC is Charisma-based.

            // Poison (Ex): Injury, Fortitude DC 14, initial damage 1d6 Str, secondary damage 2d6 Str. The save DC is Constitution-based.

            // MIMIC

            // Size/Type:	Large Aberration (Shapechanger)
            // Hit Dice:	7d8+21 (52 hp)
            // Initiative:	+1
            // Speed:	10 ft. (2 squares)
            // Armor Class:	15 (–1 size, +1 Dex, +5 natural), touch 10, flat-footed 15
            // Full Attack:	2 slams +9 melee (1d8+4)
            // Special Attacks:	Adhesive, crush
            // Special Qualities:	Darkvision 60 ft., immunity to acid, mimic shape
            // Abilities:	Str 19, Dex 12, Con 17, Int 10, Wis 13, Cha 10
            // Skills:	Climb +9, Disguise +13, Listen +8, Spot +8
            // Feats:	Alertness, Lightning Reflexes, Weapon Focus (slam)

            // A mimic can have almost any dimensions, but usually is not more than 10 feet long. A typical mimic has a volume of 150 cubic feet (5 feet by 5 feet by 6 feet) and weighs about 4,500 pounds.

            // Mimics speak Common.

            // COMBAT

            // A mimic often surprises an unsuspecting adventurer, lashing out with a heavy pseudopod. The creature does not necessarily fight to the death if it can succeed in extorting treasure or food from a party.

            // Adhesive (Ex): A mimic exudes a thick slime that acts as a powerful adhesive, holding fast any creatures or items that touch it. An adhesive-covered mimic automatically grapples any creature it hits with its slam attack. Opponents so grappled cannot get free while the mimic is alive without removing the adhesive first.

            // A weapon that strikes an adhesive-coated mimic is stuck fast unless the wielder succeeds on a DC 16 Reflex save. A successful DC 16 Strength check is needed to pry it off.

            // Strong alcohol dissolves the adhesive, but the mimic still can grapple normally. A mimic can dissolve its adhesive at will, and the substance breaks down 5 rounds after the creature dies.

            // Crush (Ex): A mimic deals 1d8+4 points of damage with a successful grapple check.

            // Mimic Shape (Ex): A mimic can assume the general shape of any object that fills roughly 150 cubic feet (5 feet by 5 feet by 6 feet), such as a massive chest, a stout bed, or a wide door frame. The creature cannot substantially alter its size, though. A mimic’s body is hard and has a rough texture, no matter what appearance it might present. Anyone who examines the mimic can detect the ruse with a successful Spot check opposed by the mimic’s Disguise check. Of course, by this time it is generally far too late.

            // MINOTAUR

            // Size/Type:	Large Monstrous Humanoid
            // Hit Dice:	6d8+12 (39 hp)
            // Initiative:	+0
            // Speed:	30 ft. (6 squares)
            // Armor Class:	14 (–1 size, +5 natural), touch 9, flat-footed — (see text)
            // Full Attack:	Greataxe +9/+4 melee (3d6+6/x3) and gore +4 melee (1d8+2)
            // Special Attacks:	powerful charge 4d6+6
            // Special Qualities:	Darkvision 60 ft., natural cunning, scent
            // Abilities:	Str 19, Dex 10, Con 15, Int 7, Wis 10, Cha 8
            // Skills:	Intimidate +2, Listen +7, Search +2, Spot +7
            // Feats:	Great Fortitude, Power Attack, Track

            // A minotaur stands more than 7 feet tall and weighs about 700 pounds.

            // Minotaurs speak Giant.

            // COMBAT

            // Minotaurs prefer melee combat, where their great strength serves them well.

            // Powerful Charge (Ex): A minotaur typically begins a battle by charging at an opponent, lowering its head to bring its mighty horns into play. In addition to the normal benefits and hazards of a charge, this allows the beast to make a single gore attack with a +9 attack bonus that deals 4d6+6 points of damage.

            // Natural Cunning (Ex): Although minotaurs are not especially intelligent, they possess innate cunning and logical ability. This gives them immunity to maze spells, prevents them from ever becoming lost, and enables them to track enemies. Further, they are never caught flat-footed.

            // MONKEY

            // Size/Type:	Tiny Animal
            // Hit Dice:	1d8 (4 hp)
            // Initiative:	+2
            // Speed:	30 ft. (6 squares), climb 30 ft.
            // Armor Class:	14 (+2 size, +2 Dex), touch 14, flat-footed 12
            // Full Attack:	Bite +4 melee (1d3–4)
            // Special Qualities:	Low-light vision
            // Abilities:	Str 3, Dex 15, Con 10, Int 2, Wis 12, Cha 5
            // Skills:	Balance +10 +12, Climb +10, Escape Artist +4, Hide +10, Listen +3, Spot +3
            // Feats:	Agile, Weapon FinesseB

            // The statistics presented here can describe any arboreal monkey that is no bigger than a housecat, such as a colobus or capuchin.

            // COMBAT

            // Monkeys generally flee into the safety of the trees, but if cornered can fight ferociously.

            // Merfolk

            // 1st-Level Warrior
            // Size/Type:	Medium Humanoid (Aquatic)
            // Hit Dice:	1d8+2 (6 hp)
            // Initiative:	+1
            // Speed:	5 ft. (1 square), swim 50 ft.
            // Armor Class:	13 (+1 Dex, +2 leather), touch 11, flat-footed 12
            // Full Attack:	Trident +2 melee (1d8+1) or heavy crossbow +2 ranged (1d10/19–20)
            // Special Qualities:	Amphibious, low-light vision
            // Abilities:	Str 13, Dex 13, Con 14, Int 10, Wis 9, Cha 10
            // Skills:	Listen +3, Spot +3, Swim +9
            // Feats:	Alertness
            // A merfolk is about 8 feet long from the top of the head to the end of the tail, and weighs about 400 pounds.

            // Merfolk speak Common and Aquan.

            // Most merfolk encountered outside their home are warriors; the information in the statistics block is for one of 1st level.

            // Combat

            // Merfolk favor heavy crossbows of shell and coral that fire bolts fashioned from blowfish spines, with an underwater range increment of 30 feet. Merfolk often barrage their enemies before closing, when they resort to Tridents.

            // Amphibious (Ex): Merfolk can breathe both air and water, although they rarely travel more than a few feet from the water’s edge.

            // MERROW

            // Merrow
            // Size/Type:	Large Giant (Aquatic)
            // Hit Dice:	4d8+11 (29 hp)
            // Initiative:	–1
            // Speed:	20 ft. in hide armor (6 squares); base speed 30 ft.; swim speed 40 ft.
            // Armor Class:	16 (–1 size, –1 Dex, +5 natural, +3 hide armor),, touch 8, flat-footed 16
            // Full Attack:	longspear +8 melee (1d8+7) or javelin +1 ranged (1d8+5)
            // Special Qualities:	Darkvision 60 ft., low-light vision
            // Abilities:	Str 21, Dex 8, Con 15, Int 6, Wis 10, Cha 7
            // Skills:	Climb +5, Listen +2, Spot +2
            // Feats:	Toughness, Weapon Focus (greatclub)
            // These cousins of the ogre have the aquatic subtype. Adult merrow stand 9 to 10 feet tall and weigh 600 to 650 pounds. Their skin color ranges from dull yellow to dull brown. Their clothing consists of poorly cured furs and hides, which add to their naturally repellent odor.

            // Merrow speak Giant, and those specimens who boast Intelligence scores of at least 10 also speak Common.

            // COMBAT

            // Merrow favor overwhelming odds, sneak attacks, and ambushes over a fair fight. They are intelligent enough to fire ranged weapons first to soften up their foes before closing, but merrow gangs and bands fight as unorganized individuals.

            // MUMMY

            // Mummy
            // Size/Type:	Medium Undead
            // Hit Dice:	8d12+3 (55 hp)
            // Initiative:	+0
            // Speed:	20 ft. (4 squares)
            // Armor Class:	20 (+10 natural),, touch 10, flat-footed 20
            // Full Attack:	Slam +11 melee (1d6+10 plus mummy rot)
            // Special Attacks:	Despair, mummy rot
            // Special Qualities:	Damage reduction 5/–, darkvision 60 ft., undead traits, vulnerability to fire
            // Abilities:	Str 24, Dex 10, Con —, Int 6, Wis 14, Cha 15
            // Skills:	Hide +7, Listen +8, Move Silently +7, Spot +8
            // Feats:	Alertness, Great Fortitude, Toughness
            // Mummies are preserved corpses animated through the auspices of dark desert gods best forgotten.

            // Most mummies are 5 to 6 feet tall and weigh about 120 pounds.

            // Mummies can speak Common, but seldom bother to do so.

            // COMBAT

            // Despair (Su): At the mere sight of a mummy, the viewer must succeed on a DC 16 Will save or be paralyzed with fear for 1d4 rounds. Whether or not the save is successful, that creature cannot be affected again by the same mummy’s despair ability for 24 hours. The save DC is Charisma-based.

            // Mummy Rot (Su): Supernatural disease—slam, Fortitude DC 16, incubation period 1 minute; damage 1d6 Con and 1d6 Cha. The save DC is Charisma-based.

            // Unlike normal diseases, mummy rot continues until the victim reaches Constitution 0 (and dies) or is cured as described below.

            // Mummy rot is a powerful curse, not a natural disease. A character attempting to cast any conjuration (healing) spell on a creature afflicted with mummy rot must succeed on a DC 20 caster level check, or the spell has no effect on the afflicted character.

            // To eliminate mummy rot, the curse must first be broken with break enchantment or remove curse (requiring a DC 20 caster level check for either spell), after which a caster level check is no longer necessary to cast healing spells on the victim, and the mummy rot can be magically cured as any normal disease.

            // An afflicted creature who dies of mummy rot shrivels away into sand and dust that blow away into nothing at the first wind.
        }

        private IEnumerable<Creature> SeedCreaturesStartingWithN(CreatureBuilderContext ctx)
        {
            yield return null;

            //             NIGHTMARE

            // Nightmare
            // Size/Type:	Large Outsider (Evil, Extraplanar)
            // Hit Dice:	6d8+18 (45 hp)
            // Initiative:	+6
            // Speed:	40 ft. (8 squares), fly 90 ft. (good)
            // Armor Class:	24 (–1 size, +2 Dex, +13 natural),, touch 11, flat-footed 22
            // Full Attack:	2 hooves +9 melee (1d8+4 plus 1d4 fire) and bite +4 melee (1d8+2)
            // Special Attacks:	Flaming hooves, smoke
            // Special Qualities:	Astral projection, darkvision 60 ft., etherealness
            // Abilities:	Str 18, Dex 15, Con 16, Int 13, Wis 13, Cha 12
            // Skills:	Concentration +12, Diplomacy +3, Intimidate +10, Knowledge (the planes) +10, Listen +12, Move Silently +11, Search +10, Sense Motive +10, Spot +12, Survival +10 (+12 on other planes and following tracks)
            // Feats:	Alertness, Improved Initiative, Run
            // A nightmare is about the size of a light war horse.

            // COMBAT

            // A nightmare can fight while carrying a rider, but the rider cannot also fight unless he or she succeeds on a Ride check.

            // A nightmare’s natural weapons, as well as any weapons it wields, are treated as evil-aligned for the purpose of overcoming damage reduction.

            // Flaming Hooves (Su): A blow from a nightmare’s hooves sets combustible materials alight.

            // Smoke (Su): During the excitement of battle, a nightmare snorts and neighs with rage. This snorting fills a 15-foot cone with a hot, sulfurous smoke that chokes and blinds opponents. Anyone in the cone must succeed on a DC 16 Fortitude save or take a –2 penalty on all attack and damage rolls until 1d6 minutes after leaving the cone. The cone lasts 1 round, and the nightmare uses it once as a free action during its turn each round. The save DC is Constitution-based.

            // Because of the smoke it gives off, a nightmare has concealment against creatures 5 feet away and total concealment against creatures 10 feet or farther away. The smoke does not obscure the nightmare’s vision at all.

            // Astral Projection and Etherealness (Su): These abilities function just like the spells of the same names (caster level 20th); a nightmare can use either at will.

            // Carrying Capacity: A light load for a nightmare is up to 300 pounds; a medium load, 301–600 pounds; and a heavy load, 601–900 pounds.

            // NIXIE

            // Size/Type:	Small Fey (Aquatic)
            // Hit Dice:	1d6 (3 hp)
            // Initiative:	+3
            // Speed:	20 ft. (4 squares), swim 30 ft.
            // Armor Class:	14 (+1 size, +3 Dex), touch 14, flat-footed 11
            // Full Attack:	Short Sword +4 melee (1d4–2/19–20) or light crossbow +4 ranged (1d6/19–20)
            // Special Attacks:	Charm person
            // Special Qualities:	Amphibious, damage reduction 5/cold iron, low-light vision, spell resistance 16, water breathing, wild empathy
            // Abilities:	Str 7, Dex 16, Con 11, Int 12, Wis 13, Cha 18
            // Skills:	Bluff +8, Craft (any one) +5, Escape Artist +6, Handle Animal +8, Hide +7*, Listen +6 +8, Perform (sing) +7, Search +3, Sense Motive +5, Spot +6 +8, Swim +6
            // Feats:	DodgeB, Alertness, Weapon FinesseB
            // Most nixies are slim and comely, with lightly scaled, pale green skin and dark green hair. Females often twine shells and pearl strings in their hair and dress in wraps woven from colorful seaweed. Males wear loincloths of the same materials. Nixies prefer not to leave their lakes.

            // A nixie stands about 4 feet tall and weighs about 45 pounds.

            // Nixies speak Aquan and Sylvan. Some also speak Common.

            // COMBAT

            // Nixies rely on their charm person ability to deter enemies, entering combat only to protect themselves and their territory.

            // Charm Person (Sp): A nixie can use charm person three times per day as the spell (caster level 4th). Those affected must succeed on a DC 15 Will save or be charmed for 24 hours. Most charmed creatures are used to perform heavy labor, guard duty, and other onerous tasks for the nixie community. Shortly before the effect wears off, the nixie escorts the charmed creature away and orders it to keep walking. The save DC is Charisma-based.

            // Amphibious (Ex): Although nixies are aquatic, they can survive indefinitely on land.

            // Water Breathing (Sp): Once per day a nixie can use water breathing as the spell (caster level 12th). Nixies usually bestow this effect on those they have charmed.

            // Wild Empathy (Ex): This ability works like the druid’s wild empathy class feature, except that a nixie has a +6 racial bonus on the check.

            // Skills: A nixie has a +8 racial bonus on any Swim check to perform some special action or avoid a hazard. It can always choose to take 10 on a Swim check, even if distracted or endangered. It can use the run action while swimming, provided it swims in a straight line. *Nixies have a +5 racial bonus on Hide checks when in the water.

            // NYMPH

            // Size/Type:	Medium Fey
            // Hit Dice:	6d6+6 (27 hp)
            // Initiative:	+3
            // Speed:	30 ft. (6 squares), swim 20 ft.
            // Armor Class:	17 (+3 Dex, +4 deflection), touch 17, flat-footed 14
            // Full Attack:	Dagger +6 melee (1d4/19–20)
            // Special Attacks:	Blinding beauty, spells, spell-like abilities, stunning glance
            // Special Qualities:	Damage reduction 10/cold iron, low-light vision, unearthly grace, wild empathy
            // Abilities:	Str 10, Dex 17, Con 12, Int 16, Wis 17, Cha 19
            // Skills:	Concentration +10, Diplomacy +6, Escape Artist +12, Handle Animal +13, Heal +12, Hide +12, Listen +12, Move Silently +12, Ride +5, Sense Motive +12, Spot +12, Swim +8, Use Rope +3 (+5 with bindings)
            // Feats:	Combat Casting, Dodge, Weapon Finesse
            // A nymph is about the height and weight of a female elf.

            // Nymphs speak Sylvan and Common.

            // COMBAT

            // Blinding Beauty (Su): This ability affects all humanoids within 30 feet of a nymph. Those who look directly at a nymph must succeed on a DC 17 Fortitude save or be blinded permanently as though by the blindness spell. A nymph can suppress or resume this ability as a free action.

            // The save DC is Charisma-based.

            // Spell-Like Abilities: 1/day—dimension door. Caster level 7th.

            // Spells: A nymph casts divine spells as a 7th-level druid.

            // Typical Druid Spells Prepared (6/5/4/3/1, save DC 13 + spell level): 0—cure minor wounds, detect magic, flare, guidance, light, resistance; 1st—calm animals, cure light wounds, entangle, longstrider, speak with animals; 2nd—barkskin, heat metal, lesser restoration, tree shape; 3rd— call lightning, cure moderate wounds, protection from energy; 4th—rusting grasp.

            // Stunning Glance (Su): As a standard action, a wrathful nymph can stun a creature within 30 feet with a look. The target creature must succeed on a DC 17 Fortitude save or be stunned for 2d4 rounds. The save DC is Charisma-based.

            // Unearthly Grace (Su): A nymph adds her Charisma modifier as a bonus on all her saving throws, and as a deflection bonus to her Armor Class. (The statistics block already reflects these bonuses).

            // Wild Empathy (Ex): This power works like the druid’s wild empathy class feature, except that a nymph has a +6 racial bonus on the check.
        }

        private IEnumerable<Creature> SeedCreaturesStartingWithO(CreatureBuilderContext ctx)
        {
            yield return null;

            //             OCTOPUS

            // Size/Type:	Small Animal (Aquatic)
            // Hit Dice:	2d8 (9 hp)
            // Initiative:	+3
            // Speed:	20 ft. (4 squares), swim 30 ft.
            // Armor Class:	16 (+1 size, +3 Dex, +2 natural), touch 14, flat-footed 13
            // Full Attack:	Arms +5 melee (0) and bite +0 melee (1d3)
            // Special Attacks:	Improved grab
            // Special Qualities:	Ink cloud, jet, low-light vision
            // Abilities:	Str 12, Dex 17, Con 11, Int 2, Wis 12, Cha 3
            // Skills:	Escape Artist +13, Hide +11, Listen +2, Spot +5, Swim +9
            // Feats:	Weapon Finesse
            // These bottom-dwelling sea creatures are dangerous only to their prey. If disturbed, they usually try to escape.

            // COMBAT

            // Improved Grab (Ex): To use this ability, an octopus must hit an opponent of any size with its arms attack. It can then attempt to start a grapple as a free action without provoking an attack of opportunity. If it wins the grapple check, it establishes a hold and automatically deals bite damage.

            // Ink Cloud (Ex): An octopus can emit a cloud of jet-black ink 10 feet high by 10 feet wide by 10 feet long once per minute as a free action. The cloud provides total concealment, which the octopus normally uses to escape a losing fight. All vision within the cloud is obscured.

            // Jet (Ex): An octopus can jet backward once per round as a full-round action, at a speed of 200 feet. It must move in a straight line, but does not provoke attacks of opportunity while jetting.

            // OGRE

            // Ogre
            // Size/Type:	Large Giant
            // Hit Dice:	4d8+11 (29 hp)
            // Initiative:	–1
            // Speed:	30 ft. in hide armor (6 squares); base speed 40 ft.
            // Armor Class:	16 (–1 size, –1 Dex, +5 natural, +3 hide armor), touch 8, flat-footed 16
            // Full Attack:	greatclub +8 melee (2d8+7) or javelin +1 ranged (1d8+5)
            // Special Qualities:	Darkvision 60 ft., low-light vision
            // Abilities:	Str 21, Dex 8, Con 15, Int 6, Wis 10, Cha 7
            // Skills:	Climb +5, Listen +2, Spot +2
            // Feats:	Toughness, Weapon Focus (greatclub)
            // Adult ogres stand 9 to 10 feet tall and weigh 600 to 650 pounds. Their skin color ranges from dull yellow to dull brown. Their clothing consists of poorly cured furs and hides, which add to their naturally repellent odor.

            // Ogres speak Giant, and those specimens who boast Intelligence scores of at least 10 also speak Common.

            // COMBAT

            // Ogres favor overwhelming odds, sneak attacks, and ambushes over a fair fight. They are intelligent enough to fire ranged weapons first to soften up their foes before closing, but ogre gangs and bands fight as unorganized individuals.

            // OGRE ZOMBIE

            // Ogre Zombie
            // Size/Type:	Large Undead
            // Hit Dice:	8d12+3 (55 hp)
            // Initiative:	–2
            // Speed:	40 ft. (8 squares; can’t run)
            // Armor Class:	15 (–1 size, –2 Dex, +8 natural), touch 7, flat-footed 15
            // Full Attack:	greatclub +9 melee (2d8+9) or slam +9 melee (1d8+9) or javelin +1 ranged (1d8+6)
            // Special Qualities:	Single actions only, damage reduction 5/slashing, darkvision 60 ft., undead traits
            // Abilities:	Str 23, Dex 6, Con —, Int —, Wis 10, Cha 1
            // Feats:	Toughness
            // Zombies are corpses reanimated through dark and sinister magic.

            // Because of their utter lack of intelligence, the instructions given to a newly created zombie must be very simple.

            // WHALE, ORCA

            // Whale, Orca
            // Size/Type:	Huge Animal
            // Hit Dice:	9d8+48 (88 hp)
            // Initiative:	+2
            // Speed:	Swim 50 ft. (10 squares)
            // Armor Class:	16 (–2 size, +2 Dex, +6 natural), touch 10, flat-footed 14
            // Full Attack:	Bite +12 melee (2d6+12)
            // Space/Reach:	15 ft./10 ft.
            // Special Qualities:	Blindsight 120 ft., hold breath, low-light vision
            // Abilities:	Str 27, Dex 15, Con 21, Int 2, Wis 14, Cha 6
            // Skills:	Listen +14*, Spot +14*, Swim +16
            // Feats:	Alertness, Endurance, Run, Toughness
            // These ferocious creatures are about 30 feet long. They eat fish, squid, seals, and other whales.

            // Blindsight (Ex): Whales can “see” by emitting high-frequency sounds, inaudible to most other creatures, that allow them to locate objects and creatures within 120 feet. A silence spell negates this and forces the whale to rely on its vision, which is approximately as good as a human’s.

            // Hold Breath (Ex): A whale can hold its breath for a number of rounds equal to 8 x its Constitution score before it risks drowning.

            // OWL

            // Size/Type:	Tiny Animal
            // Hit Dice:	1d8 (4 hp)
            // Initiative:	+3
            // Speed:	10 ft. (2 squares), fly 40 ft. (average)
            // Armor Class:	17 (+2 size, +3 Dex, +2 natural), touch 15, flat-footed 14
            // Full Attack:	Talons +5 melee (1d4–3)
            // Space/Reach:	2-1/2 ft./0 ft.
            // Special Qualities:	Low-light vision
            // Abilities:	Str 4, Dex 17, Con 10, Int 2, Wis 14, Cha 4
            // Skills:	Listen +14 +16, Move Silently +17, Spot +6 +8*
            // Feats:	Alertness, Weapon FinesseB
            // The statistics presented here describe nocturnal birds of prey from 1 to 2 feet long, with wingspans up to 6 feet. They combine both talons into a single attack.

            // COMBAT

            // Owls swoop quietly down onto prey, attacking with their powerful talons.

            // 	Orc 1st-Level Warrior
            // Size/Type:	Medium Humanoid (Orc)
            // Hit Dice:	1d8+1 (5 hp)
            // Initiative:	+0
            // Speed:	30 ft. (6 squares)
            // Armor Class:	13 (+3 studded leather armor), touch 10, flat-footed 13
            // Full Attack:	Falchion +4 melee (2d4+4/18–20) or javelin +1 ranged (1d6+3)
            // Special Qualities:	Darkvision 60 ft., light sensitivity
            // Abilities:	Str 17, Dex 11, Con 12, Int 8, Wis 7, Cha 6
            // Skills:	Listen +1, Spot +1
            // Feats:	Alertness
            // An orc’s hair usually is black. It has lupine ears and reddish eyes. Orcs prefer wearing vivid colors that many humans would consider unpleasant, such as blood red, mustard yellow, yellow-green, and deep purple. Their equipment is dirty and unkempt. An adult male orc is a little over 6 feet tall and weighs about 210 pounds.

            // Females are slightly smaller.

            // The language an orc speaks varies slightly from tribe to tribe, but any orc is understandable by someone else who speaks Orc. Some orcs know Goblin or Giant as well.

            // Most orcs encountered away from their homes are warriors; the information in the statistics block is for one of 1st level.

            // COMBAT

            // Orcs are proficient with all simple weapons, preferring those that cause the most damage in the least time. Many orcs who take up the warrior or fighter class also gain proficiency with the falchion or the greataxe as a martial weapon. They enjoy attacking from concealment and setting ambushes, and they obey the rules of war (such as honoring a truce) only as long as it is convenient for them.

            // Light Sensitivity (Ex): Orcs are dazzled in bright sunlight or within the radius of a daylight spell.

            // ORCS AS CHARACTERS

            // Orc Traits (Ex): Orcs possess the following racial traits.

            // +4 Strength, –2 Intelligence, –2 Wisdom, –2 Charisma.
            // An orc’s base land speed is 30 feet.
            // Darkvision out to 60 feet.
            // Light Sensitivity: Orcs are dazzled in bright sunlight or within the radius of a daylight spell.
            // Automatic Languages: Common, Orc. Bonus Languages: Dwarven, Giant, Gnoll, Goblin, Undercommon.
            // Favored Class: Barbarian.
            // The orc warrior presented here had the following ability scores before racial adjustments: Str 13, Dex 11, Con 12, Int 10, Wis 9, Cha 8.
        }

        private IEnumerable<Creature> SeedCreaturesStartingWithP(CreatureBuilderContext ctx)
        {
            yield return null;

            //             PEGASUS

            // Size/Type:	Large Magical Beast
            // Hit Dice:	4d10+12 (34 hp)
            // Initiative:	+2
            // Speed:	60 ft. (12 squares), fly 120 ft. (average)
            // Armor Class:	14 (–1 size, +2 Dex, +3 natural), touch 11, flat-footed 12
            // Full Attack:	2 hooves +7 melee (1d6+4) and bite +2 melee (1d3+2)
            // Special Qualities:	Darkvision 60 ft., low-light vision, scent, spell-like abilities
            // Abilities:	Str 18, Dex 15, Con 16, Int 10, Wis 13, Cha 13
            // Skills:	Diplomacy +3, Listen +8, Sense Motive +9, Spot +8
            // Feats:	Flyby Attack, Iron Will
            // The pegasus is a magnificent winged horse that sometimes serves the cause of good. Though highly prized as aerial steeds, pegasi are wild and shy creatures not easily tamed.

            // A typical pegasus stands 6 feet high at the shoulder, weighs 1,500 pounds, and has a wingspan of 20 feet. Pegasi cannot speak, but they understand Common.

            // COMBAT

            // Spell-Like Abilities: At will—detect good and detect evil within a 60-foot radius. Caster level 5th.

            // Skills: Pegasi have a +4 racial bonus on Listen and Spot checks.

            // TRAINING A PEGASUS

            // Although intelligent, a pegasus requires training before it can bear a rider in combat. To be trained, a pegasus must have a friendly attitude toward the trainer (this can be achieved through a successful Diplomacy check). Training a friendly pegasus requires six weeks of work and a DC 25 Handle Animal check. Riding a pegasus requires an exotic saddle. A pegasus can fight while carrying a rider, but the rider cannot also attack unless he or she succeeds on a Ride check.

            // Pegasus eggs are worth 2,000 gp each on the open market, while young are worth 3,000 gp per head. Pegasi mature at the same rate as horses. Professional trainers charge 1,000 gp to rear or train a pegasus, which serves a good or neutral master with absolute faithfulness for life.

            // Carrying Capacity: A light load for a pegasus is up to 300 pounds; a medium load, 301–600 pounds; and a heavy load, 601–900 pounds.

            // Pixie

            // Size/Type:	Small Fey
            // Hit Dice:	1d6 (3 hp)
            // Initiative:	+4
            // Speed:	20 ft. (4 squares), fly 60 ft. (good)
            // Armor Class:	16 (+1 size, +4 Dex, +1 natural), touch 15, flat-footed 12
            // Full Attack:	Short Sword +5 melee (1d4–2/19–20) or longbow +5 ranged (1d6–2)/x3
            // Special Attacks:	Spell-like abilities, special arrows
            // Special Qualities:	Damage reduction 10/cold iron, greater invisibility, low-light vision, spell resistance 15
            // Abilities:	Str 7, Dex 18, Con 11, Int 16, Wis 15, Cha 16
            // Skills:	Bluff +7, Concentration +4, Escape Artist +8, Hide +8, Listen +8 +10, Move Silently +8, Ride +8, Search +9, Sense Motive +6, Spot +8 +10
            // Feats:	Alertness, DodgeB, Weapon FinesseB
            // Pixies wear bright clothing, often including a cap and shoes with curled and pointed toes.

            // A pixie stands about 2-1/2 feet tall and weighs about 30 pounds.

            // Pixies speak Sylvan and Common, and may know other languages as well.

            // COMBAT

            // The normally carefree pixies ferociously attack evil creatures and unwanted intruders. They take full advantage of their invisibility and other abilities to harass and drive away opponents.

            // Greater Invisibility (Su): A pixie remains invisible even when it attacks. This ability is constant, but the pixie can suppress or resume it as a free action.

            // Spell-Like Abilities: 1/day—lesser confusion (DC 14), dancing lights, detect chaos, detect good, detect evil, detect law, detect thoughts (DC 15), dispel magic, entangle (DC 14), permanent image (DC 19; visual and auditory elements only), polymorph (self only). Caster level 8th. The save DCs are Charisma-based.

            // One pixie in ten can use irresistible dance (caster level 8th) once per day.

            // Special Arrows (Ex): Pixies sometimes employ arrows that deal no damage but can erase memory or put a creature to sleep.

            // Memory Loss: An opponent struck by this arrow must succeed on a DC 15 Will save or lose all memory. The save DC is Charisma-based and includes a +2 racial bonus. The subject retains skills, languages, and class abilities but forgets everything else until he or she receives a heal spell or memory restoration with limited wish, wish, or miracle.

            // Sleep: Any opponent struck by this arrow, regardless of Hit Dice, must succeed on a DC 15 Fortitude save or be affected as though by a sleep spell. The save DC is Charisma-based and includes a +2 racial bonus.

            // BEAR, POLAR

            // Size/Type:	Large Animal
            // Hit Dice:	8d8+32 (68 hp)
            // Initiative:	+1
            // Speed:	40 ft. (8 squares), swim 30 ft.
            // Armor Class:	15 (–1 size, +1 Dex, +5 natural), touch 10, flat-footed 14
            // Full Attack:	2 claws +13 melee (1d8+8) and bite +8 melee (2d6+4)
            // Special Attacks:	Improved grab
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 27, Dex 13, Con 19, Int 2, Wis 12, Cha 6
            // Skills:	Hide –2*, Listen +5, Spot +7, Swim +16
            // Feats:	Endurance, Run, Track
            // These long, lean carnivores are slightly taller than brown bears.

            // COMBAT

            // Polar bears fight just as brown bears do.

            // Improved Grab (Ex): To use this ability, a polar bear must hit with a claw attack. It can then attempt to start a grapple as a free action without provoking an attack of opportunity.

            // PORPOISE

            // Size/Type:	Medium Animal
            // Hit Dice:	2d8+2 (11 hp)
            // Initiative:	+3
            // Speed:	Swim 80 ft. (16 squares)
            // Armor Class:	15 (+3 Dex, +2 natural), touch 13, flat-footed 12
            // Full Attack:	Slam +4 melee (2d4)
            // Special Qualities:	Blindsight 120 ft., hold breath, low-light vision
            // Abilities:	Str 11, Dex 17, Con 13, Int 2, Wis 12, Cha 6
            // Skills:	Listen +8*, Spot +7*, Swim +8
            // Feats:	Weapon Finesse
            // Porpoises are mammals that tend to be playful, friendly, and helpful. A typical porpoise is 4 to 6 feet long and weighs 110 to 160 pounds. The statistics presented here can describe any small whale of similar size.

            // COMBAT

            // Blindsight (Ex): Porpoises can “see” by emitting high-frequency sounds, inaudible to most other creatures, that allow them to locate objects and creatures within 120 feet. A silence spell negates this and forces the porpoise to rely on its vision, which is approximately as good as a human’s.

        }

        private IEnumerable<Creature> SeedCreaturesStartingWithR(CreatureBuilderContext ctx)
        {
            yield return null;

            //             RAT

            // Size/Type:	Tiny Animal
            // Hit Dice:	1/4 d8 (1 hp)
            // Initiative:	+2
            // Speed:	15 ft. (3 squares), climb 15 ft., swim 15 ft.
            // Armor Class:	14 (+2 size, +2 Dex), touch 14, flat-footed 12
            // Full Attack:	Bite +4 melee (1d3–4)
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 2, Dex 15, Con 10, Int 2, Wis 12, Cha 2
            // Skills:	Balance +10, Climb +12, Hide +14 +16, Move Silently +10, Swim +10
            // Feats:	Stealthy, Weapon FinesseB
            // These omnivorous rodents thrive almost anywhere.

            // COMBAT

            // Rats usually run away. They bite only as a last resort.

            // RAT SWARM

            // Size/Type:	Tiny Animal (Swarm)
            // Hit Dice:	4d8 (13 hp)
            // Initiative:	+2
            // Speed:	15 ft. (3 squares), climb 15 ft.
            // Armor Class:	14 (+2 size, +2 Dex), touch 14, flat-footed 12
            // Full Attack:	Swarm (1d6 plus disease)
            // Special Attacks:	Disease, distraction
            // Special Qualities:	Half damage from slashing and piercing, low-light vision, scent, swarm traits
            // Abilities:	Str 2, Dex 15, Con 10, Int 2, Wis 12, Cha 2
            // Skills:	Balance +10, Climb +10, Hide +14 +16, Listen +6, Move Silently +8, Spot +7, Swim +10
            // Feats:	Alertness, Stealthy, Weapon FinesseB
            // COMBAT

            // A rat swarm seeks to surround and attack any warm-blooded prey it encounters. A swarm deals 1d6 points of damage to any creature whose space it occupies at the end of its move.

            // Disease (Ex): Filth fever—swarm attack, Fortitude DC 12, incubation period 1d3 days, damage 1d3 Dex and 1d3 Con. The save DC is Constitution-based.

            // Distraction (Ex): Any living creature that begins its turn with a swarm in its square must succeed on a DC 12 Fortitude save or be nauseated for 1 round. The save DC is Constitution-based.

            // RAVEN

            // Size/Type:	Tiny Animal
            // Hit Dice:	1/4 d8 (1 hp)
            // Initiative:	+2
            // Speed:	10 ft. (2 squares), fly 40 ft. (average)
            // Armor Class:	14 (+2 size, +2 Dex), touch 14, flat-footed 12
            // Full Attack:	Claws +4 melee (1d2–5)
            // Special Qualities:	Low-light vision
            // Abilities:	Str 1, Dex 15, Con 10, Int 2, Wis 14, Cha 6
            // Skills:	Listen +3 +5, Spot +5 +7
            // Feats:	Alertness, Weapon FinesseB
            // These glossy black birds are about 2 feet long and have wingspans of about 4 feet. They combine both claws into a single attack. The statistics presented here can describe most nonpredatory birds of similar size.

            // DOG, RIDING

            // Size/Type:	Medium Animal
            // Hit Dice:	2d8+4 (13 hp)
            // Initiative:	+2
            // Speed:	40 ft. (8 squares)
            // Armor Class:	16 (+2 Dex, +4 natural), touch 12, flat-footed 14
            // Full Attack:	Bite +3 melee (1d6+3)
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 15, Dex 15, Con 15, Int 2, Wis 12, Cha 6
            // Skills:	Jump +8, Listen +5, Spot +5, Swim +3, Survival +1*
            // Feats:	Alertness, TrackB
            // This category includes working breeds such as collies, huskies, and St. Bernards.

            // Carrying Capacity: A light load for a riding dog is up to 100 pounds; a medium load, 101–200 pounds; and a heavy load, 201–300 pounds. A riding dog can drag 1,500 pounds.

            // COMBAT

            // If trained for war, these animals can make trip attacks just as wolves do (see the Wolf entry). A riding dog can fight while carrying a rider, but the rider cannot also attack unless he or she succeeds on a Ride check.

        }

        private IEnumerable<Creature> SeedCreaturesStartingWithS(CreatureBuilderContext ctx)
        {
            yield return null;

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

            // SATYR

            // Size/Type:	Medium Fey
            // Hit Dice:	5d6+5 (22 hp)
            // Initiative:	+1
            // Speed:	40 ft. (8 squares)
            // Armor Class:	15 (+1 Dex, +4 natural), touch 11, flat-footed 14
            // Full Attack:	Head butt +2 melee (1d6) and dagger –3 melee (1d4/19–20); or Shortbow +3 ranged (1d6/x3)
            // Special Attacks:	Pipes
            // Special Qualities:	Damage reduction 5/cold iron, low-light vision
            // Abilities:	Str 10, Dex 13, Con 12, Int 12, Wis 13, Cha 13
            // Skills:	Bluff +9, Diplomacy +3, Disguise +1 (+3 acting), Hide +13, Intimidate +3, Knowledge (nature) +9, Listen +15, Move Silently +13, Perform (wind instruments) +9, Spot +15, Survival +1 (+3 aboveground)
            // Feats:	AlertnessB, Dodge, Mobility
            // A satyr’s hair is red or chestnut brown, while its hooves and horns are jet black. A satyr is about as tall and heavy as a half-elf.

            // Satyrs speak Sylvan, and most also speak Common.

            // COMBAT

            // The keen senses of a satyr make it almost impossible to surprise one in the wild. Conversely, with their own natural grace and agility, satyrs can sneak up on travelers who are not carefully watching the surrounding wilderness. Once engaged in battle, an unarmed satyr attacks with a powerful head butt. A satyr expecting trouble is likely to be armed with a bow and a [[SRD:Dagger (SRD Weapon)|Dagger]] and typically looses arrows from hiding, weakening an enemy before closing.

            // Pipes (Su): Satyrs can play a variety of magical tunes on their pan pipes. Usually, only one satyr in a group carries pipes. When it plays, all creatures within a 60-foot spread (except satyrs) must succeed on a DC 13 Will save or be affected by charm person, sleep, or fear (caster level 10th; the satyr chooses the tune and its effect).

            // In the hands of other beings, these pipes have no special powers. A creature that successfully saves against any of the pipe’s effects cannot be affected by the same set of pipes for 24 hours. The save DC is Charisma-based.

            // SHADOW

            // Shadow
            // Size/Type:	Medium Undead (Incorporeal)
            // Hit Dice:	3d12 (19 hp)
            // Initiative:	+2
            // Speed:	Fly 40 ft. (good) (8 squares)
            // Armor Class:	13 (+2 Dex, +1 deflection), touch 13, flat-footed 11
            // Full Attack:	Incorporeal touch +3 melee (1d6 Str)
            // Special Attacks:	Create spawn, strength damage
            // Special Qualities:	Darkvision 60 ft., incorporeal traits, +2 turn resistance, undead traits
            // Abilities:	Str —, Dex 14, Con —, Int 6, Wis 12, Cha 13
            // Skills:	Hide +8*, Listen +7, Search +4, Spot +7
            // Feats:	Alertness, Dodge
            // A shadow can be difficult to see in dark or gloomy areas but stands out starkly in brightly illuminated places.

            // A shadow is 5 to 6 feet tall and is weightless. Shadows cannot speak intelligibly.

            // COMBAT

            // Shadows lurk in dark places, waiting for living prey to happen by.

            // Strength Damage (Su): The touch of a shadow deals 1d6 points of Strength damage to a living foe. A creature reduced to Strength 0 by a shadow dies. This is a negative energy effect.

            // Create Spawn (Su): Any humanoid reduced to Strength 0 by a shadow becomes a shadow under the control of its killer within 1d4 rounds.

            // SHAMBLING MOUND

            // Size/Type:	Large Plant
            // Hit Dice:	8d8+24 (60 hp)
            // Initiative:	+0
            // Speed:	20 ft. (4 squares), swim 20 ft.
            // Armor Class:	20 (–1 size, +11 natural), touch 9, flat-footed 20
            // Full Attack:	2 slams +11 melee (2d6+5)
            // Special Attacks:	Improved grab, constrict 2d6+7
            // Special Qualities:	Darkvision 60 ft., immunity to electricity, low-light vision, plant traits, resistance to fire 10
            // Abilities:	Str 21, Dex 10, Con 17, Int 7, Wis 10, Cha 9
            // Skills:	Hide +3*, Listen +8, Move Silently +8
            // Feats:	Iron Will, Power Attack, Weapon Focus (slam)
            // Shambling mounds, also called shamblers, appear to be heaps of rotting vegetation. They are actually intelligent, carnivorous plants.

            // A shambler’s brain and sensory organs are located in its upper body.

            // A shambler’s body has an 8-foot girth and is about 6 feet tall when the creature stands erect. It weighs about 3,800 pounds.

            // COMBAT

            // A shambling mound batters or constricts its opponents with two huge, armlike appendages.

            // Improved Grab (Ex): To use this ability, a shambler must hit with both slam attacks. It can then attempt to start a grapple as a free action without provoking an attack of opportunity. If it wins the grapple check, it establishes a hold and can constrict.

            // Constrict (Ex): A shambler deals 2d6+7 points of damage with a successful grapple check.

            // Immunity to Electricity (Ex): Shamblers take no damage from electricity. Instead, any electricity attack used against a shambler temporarily grants it 1d4 points of Constitution. The shambler loses these points at the rate of 1 per hour.

            // SPIDER SWARM

            // Size/Type:	Diminutive Vermin (Swarm)
            // Hit Dice:	2d8 (9 hp)
            // Initiative:	+3
            // Speed:	20 ft. (4 squares), climb 20 ft.
            // Armor Class:	17 (+4 size, +3 Dex), touch 17, flat-footed 14
            // Full Attack:	Swarm (1d6 plus poison)
            // Special Attacks:	Distraction, poison
            // Special Qualities:	Darkvision 60 ft., immune to weapon damage, swarm traits, tremorsense 30 ft., vermin traits
            // Abilities:	Str 1, Dex 17, Con 10, Int —, Wis 10, Cha 2
            // Skills:	Climb +11, Listen +4, Spot +4
            // COMBAT

            // A spider swarm seeks to surround and attack any living prey it encounters. A swarm deals 1d6 points of damage to any creature whose space it occupies at the end of its move.

            // Distraction (Ex): Any living creature that begins its turn with a spider swarm in its space must succeed on a DC 11 Fortitude save or be nauseated for 1 round. The save DC is Constitution-based.

            // Poison (Ex): Injury, Fortitude DC 11, initial and secondary damage 1d3 Str. The save DC is Constitution-based.

            // SPECTRE

            // Size/Type:	Medium Undead (Incorporeal)
            // Hit Dice:	7d12 (45 hp)
            // Initiative:	+7
            // Speed:	40 ft. (8 squares), fly 80 ft. (perfect)
            // Armor Class:	15 (+3 Dex, +2 deflection), touch 15, flat-footed 13
            // Full Attack:	Incorporeal touch +6 melee (1d8 plus Energy drain)
            // Special Attacks:	Energy drain, create spawn
            // Special Qualities:	Darkvision 60 ft., incorporeal traits, +2 turn resistance, sunlight powerlessness, undead traits, unnatural aura
            // Abilities:	Str —, Dex 16, Con —, Int 14, Wis 14, Cha 15
            // Skills:	Hide +13, Intimidate +12, Knowledge (religion) +12, Listen +14, Search +12, Spot +14, Survival +2 (+4 following tracks)
            // Feats:	Alertness, Blind Fight, Improved Initiative
            // A spectre looks much as it did in life and can be easily recognized by those who knew the individual or have seen the individual’s face in a painting or a drawing. In many cases, the evidence of a violent death is visible on its body. A spectre is roughly human-sized and is weightless.

            // COMBAT

            // In close combat a spectre attacks with its numbing, life-draining touch. It makes full use of its incorporeal nature, moving through walls, ceilings, and floors as it attacks.

            // Energy Drain (Su): Living creatures hit by a spectre’s incorporeal touch attack gain two negative levels. The DC is 15 for the Fortitude save to remove a negative level. The save DC is Charisma-based. For each such negative level bestowed, the spectre gains 5 temporary hit points.

            // Create Spawn (Su): Any humanoid slain by a spectre becomes a spectre in 1d4 rounds. Spawn are under the command of the spectre that created them and remain enslaved until its death. They do not possess any of the abilities they had in life.

            // Unnatural Aura (Su): Animals, whether wild or domesticated, can sense the unnatural presence of a spectre at a distance of 30 feet. They do not willingly approach nearer than that and panic if forced to do so; they remain panicked as long as they are within that range.

            // Sunlight Powerlessness (Ex): Spectres are powerless in natural sunlight (not merely a daylight spell) and flee from it. A spectre caught in sunlight cannot attack and can take only a single standard action in a round.

            // STONE GIANT

            // Size/Type:	Large Giant (Earth)
            // Hit Dice:	14d8+56 (119 hp)
            // Initiative:	+2
            // Speed:	30 ft. in hide armor (6 squares); base speed 40 ft.
            // Armor Class:	25 (–1 size, +2 Dex, +11 natural, +3 hide), touch 11, flat-footed 23
            // Full Attack:	Greatclub +17/+12 melee (2d8+12) or 2 slams +17 melee (1d4+8) or rock +11 ranged (2d8+12)
            // Special Attacks:	Rock throwing
            // Special Qualities:	Darkvision 60 ft., low-light vision, rock catching
            // Abilities:	Str 27, Dex 15, Con 19, Int 10, Wis 12, Cha 11
            // Skills:	Climb +11, Hide +6*, Jump +11, Spot +12
            // Feats:	Combat Reflexes, Iron Will, Point Blank Shot, Power Attack, Precise Shot
            // Stone giants prefer thick leather garments, dyed in shades of brown and gray to match the stone around them. Adults are about 12 feet tall and weigh about 1,500 pounds. Stone giants can live to be 800 years old.

            // COMBAT

            // Stone giants fight from a distance whenever possible, but if they can’t avoid melee, they use gigantic clubs chiseled out of stone. A favorite tactic of stone giants is to stand nearly motionless, blending in with the background, then move forward to throw rocks and surprise their foes.

            // Rock Throwing (Ex): The range increment is 180 feet for a stone giant’s thrown rocks. It uses both hands when throwing a rock.

            // Rock Catching (Ex): A stone giant gains a +4 racial bonus on its Reflex save when attempting to catch a thrown rock.
        }

        private IEnumerable<Creature> SeedCreaturesStartingWithT(CreatureBuilderContext ctx)
        {
            yield return null;

            //             TIGER

            // Size/Type:	Large Animal
            // Hit Dice:	6d8+18 (45 hp)
            // Initiative:	+2
            // Speed:	40 ft. (8 squares)
            // Armor Class:	14 (–1 size, +2 Dex, +3 natural), touch 11, flat-footed 12
            // Full Attack:	2 claws +9 melee (1d8+6) and bite +4 melee (2d6+3)
            // Special Attacks:	Improved grab, pounce, rake 1d8+3
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 23, Dex 15, Con 17, Int 2, Wis 12, Cha 6
            // Skills:	Balance +6, Hide +3*, Listen +3, Move Silently +9, Spot +3, Swim +11
            // Feats:	Alertness, Improved Natural Attack (bite), and Improved Natural Attack (claw).
            // These great cats stand more than 3 feet tall at the shoulder and are about 9 feet long. They weigh from 400 to 600 pounds.

            // COMBAT

            // Improved Grab (Ex): To use this ability, a tiger must hit with a claw or bite attack. It can then attempt to start a grapple as a free action without provoking an attack of opportunity. If it wins the grapple check, it establishes a hold and can rake.

            // Pounce (Ex): If a tiger charges a foe, it can make a full attack, including two rake attacks.

            // Rake (Ex): Attack bonus +9 melee, damage 1d8+3.

            // TOAD

            // Size/Type:	Diminutive Animal
            // Hit Dice:	1/4 d8 (1 hp)
            // Initiative:	+1
            // Speed:	5 ft. (1 square)
            // Armor Class:	15 (+4 size, +1 Dex), touch 15, flat-footed 14
            // Special Qualities:	Amphibious, low-light vision
            // Abilities:	Str 1, Dex 12, Con 11, Int 1, Wis 14, Cha 4
            // Skills:	Hide +21, Listen +4, Spot +4
            // Feats:	Alertness
            // These diminutive amphibians are innocuous and beneficial, since they eat insects.

            // TREANT

            // Size/Type:	Huge Plant
            // Hit Dice:	7d8+35 (66 hp)
            // Initiative:	–1
            // Speed:	30 ft. (6 squares)
            // Armor Class:	20 (–2 size, –1 Dex, +13 natural), touch 7, flat-footed 20
            // Full Attack:	2 slams +12 melee (2d6+9)
            // Special Attacks:	Animate trees, double damage against objects, trample 2d6+13
            // Special Qualities:	Damage reduction 10/slashing, low-light vision, plant traits, vulnerability to fire
            // Abilities:	Str 29, Dex 8, Con 21, Int 12, Wis 16, Cha 12
            // Skills:	Diplomacy +3, Hide –9*, Intimidate +6, Knowledge (nature) +6, Listen +8, Sense Motive +8, Spot +8, Survival +8 (+10 aboveground)
            // Feats:	Improved Sunder, Iron Will, Power Attack
            // A treant’s leaves are deep green in the spring and summer. In the fall and winter the leaves change to yellow, orange, or red, but they rarely fall out. A treant’s legs fit together when closed to look like the trunk of a tree, and a motionless treant is nearly indistinguishable from a tree.

            // A treant is about 30 feet tall, with a “trunk” about 2 feet in diameter. It weighs about 4,500 pounds.

            // Treants speak their own language, plus Common and Sylvan. Most also can manage a smattering of just about all other humanoid tongues—at least enough to say “Get away from my trees!”

            // COMBAT

            // Treants prefer to watch potential foes carefully before attacking. They often charge suddenly from cover to trample the despoilers of forests. If sorely pressed, they animate trees as reinforcements.

            // Animate Trees (Sp): A treant can animate trees within 180 feet at will, controlling up to two trees at a time. It takes 1 full round for a normal tree to uproot itself. Thereafter it moves at a speed of 10 feet and fights as a treant in all respects. Animated trees lose their ability to move if the treant that animated them is incapacitated or moves out of range. The ability is otherwise similar to liveoak (caster level 12th). Animated trees have the same vulnerability to fire that a treant has.

            // Double Damage against Objects (Ex): A treant or animated tree that makes a full attack against an object or structure deals double damage.

            // Trample (Ex): Reflex DC 22 half. The save DC is Strength-based.

            // TROLL

            // Troll
            // Size/Type:	Large Giant
            // Hit Dice:	6d8+36 (63 hp)
            // Initiative:	+2
            // Speed:	30 ft. (6 squares)
            // Armor Class:	16 (–1 size, +2 Dex, +5 natural), touch 11, flat-footed 14
            // Full Attack:	2 claws +9 melee (1d6+6) and bite +4 melee (1d6+3)
            // Special Attacks:	Rend 2d6+9
            // Special Qualities:	Darkvision 90 ft., low-light vision, regeneration 5, scent
            // Abilities:	Str 23, Dex 14, Con 23, Int 6, Wis 9, Cha 6
            // Skills:	Listen +5, Spot +6
            // Feats:	Alertness, Iron Will, Track
            // Trolls walk upright but hunched forward with sagging shoulders. Their gait is uneven, and when they run, their arms dangle and drag along the ground. For all this seeming awkwardness, trolls are very agile.

            // A typical adult troll stands 9 feet tall and weighs 500 pounds. Females are slightly larger than males. A troll’s rubbery hide is moss green, mottled green and gray, or putrid gray. The hair is usually greenish black or iron gray.

            // Trolls speak Giant.

            // COMBAT

            // Trolls have no fear of death: They launch themselves into combat without hesitation, flailing wildly at the closest opponent. Even when confronted with fire, they try to get around the flames and attack.

            // Rend (Ex): If a troll hits with both claw attacks, it latches onto the opponent’s body and tears the flesh. This attack automatically deals an additional 2d6+9 points of damage.

            // Regeneration (Ex): Fire and acid deal normal damage to a troll. If a troll loses a limb or body part, the lost portion regrows in 3d6 minutes. The creature can reattach the severed member instantly by holding it to the stump.
        }

        private IEnumerable<Creature> SeedCreaturesStartingWithW(CreatureBuilderContext ctx)
        {
            yield return null;

            // MEDIUM WATER ELEMENTAL

            // Water Elemental, Medium
            // Size/Type:	Medium Elemental (Water, Extraplanar)
            // Hit Dice:	4d8+12 (30 hp)
            // Initiative:	+1
            // Speed:	20 ft. (4 squares), swim 90 ft.
            // Armor Class:	19 (+1 Dex, +8 natural),, touch 11, flat-footed 18
            // Full Attack:	Slam +6 melee (1d8+4)
            // Special Attacks:	Water mastery, drench, vortex
            // Special Qualities:	Darkvision 60 ft., elemental traits
            // Abilities:	Str 16, Dex 12, Con 17, Int 4, Wis 11, Cha 11
            // Skills:	Listen +3, Spot +4
            // Feats:	Cleave, Power Attack
            // A water elemental can’t venture more than 180 feet from the body of water from which it was conjured.

            // Water elementals speak Aquan but rarely choose to do so.

            // COMBAT

            // A water elemental prefers to fight in a large body of water where it can disappear beneath the waves and suddenly swell up behind its opponents.

            // Water Mastery (Ex): A water elemental gains a +1 bonus on attack and damage rolls if both it and its opponent are touching water. If the opponent or the elemental is touching the ground, the elemental takes a –4 penalty on attack and damage rolls. (These modifiers are not included in the statistics block.)

            // A water elemental can be a serious threat to a ship that crosses its path. An elemental can easily overturn small craft (5 feet of length per Hit Die of the elemental) and stop larger vessels (10 feet long per HD). Even large ships (20 feet long per HD) can be slowed to half speed.

            // Drench (Ex): The elemental’s touch puts out torches, campfires, exposed lanterns, and other open flames of nonmagical origin if these are of Large size or smaller. The creature can dispel magical fire it touches as dispel magic (caster level equals elemental’s HD).

            // Vortex (Su): The elemental can transform itself into a whirlpool once every 10 minutes, provided it is underwater, and remain in that form for up to 1 round for every 2 HD it has. In vortex form, the elemental can move through the water or along the bottom at its swim speed. The vortex is 5 feet wide at the base, up to 30 feet wide at the top, and 10 feet or more tall, depending on the elemental’s size. The elemental controls the exact height, but it must be at least 10 feet.

            // The elemental’s movement while in vortex form does not provoke attacks of opportunity, even if the elemental enters the space another creature occupies. Another creature might be caught in the vortex if it touches or enters the vortex, or if the elemental moves into or through the creature’s space.

            // Creatures one or more size categories smaller than the elemental might take damage when caught in the vortex (see the table below for details) and may be swept up by it. An affected creature must succeed on a Reflex save when it comes into contact with the vortex or take the indicated damage. It must also succeed on a second Reflex save or be picked up bodily and held suspended in the powerful currents, automatically taking damage each round. An affected creature is allowed a Reflex save each round to escape the vortex. The creature still takes damage, but can leave if the save is successful. The DC for saves against the vortex’s effects varies with the elemental’s size. The save DC is Strength-based.

            // Creatures trapped in the vortex cannot move except to go where the elemental carries them or to escape the whirlwind. Creatures caught in the whirlwind can otherwise act normally, but must make a Concentration check (DC 10 + spell level) to cast a spell. Creatures caught in the whirlwind take a –4 penalty to Dexterity and a –2 penalty on attack rolls. The elemental can have only as many creatures trapped inside the vortex at one time as will fit inside the vortex’s volume.

            // The elemental can eject any carried creatures whenever it wishes, depositing them wherever the vortex happens to be. A summoned elemental always ejects trapped creatures before returning to its home plane.

            // If the vortex’s base touches the bottom, it creates a swirling cloud of debris. This cloud is centered on the elemental and has a diameter equal to half the vortex’s height. The cloud obscures all vision, including darkvision, beyond 5 feet. Creatures 5 feet away have concealment, while those farther away have total concealment.

            // Those caught in the cloud must make a Concentration check (DC 15 + spell level) to cast a spell.

            // An elemental in vortex form cannot make slam attacks and does not threaten the area around it.

            // 	––—––—— Vortex ——––––—
            // Elemental	Height	Weight	Save DC	Damage	Height
            // Medium	8 ft.	280 lb.	15	1d6	10–30 ft.

            // WIGHT

            // Size/Type:	Medium Undead
            // Hit Dice:	4d12 (26 hp)
            // Initiative:	+1
            // Speed:	30 ft. (6 squares)
            // Armor Class:	15 (+1 Dex, +4 natural), touch 11, flat-footed 14
            // Full Attack:	Slam +3 melee (1d4+1 plus energy drain)
            // Special Attacks:	Create spawn, energy drain
            // Special Qualities:	Darkvision 60 ft., undead traits
            // Abilities:	Str 12, Dex 12, Con —, Int 11, Wis 13, Cha 15
            // Skills:	Hide +8, Listen +7, Move Silently +16, Spot +7
            // Feats:	Alertness, Blind Fight
            // A wight’s appearance is a weird and twisted reflection of the form it had in life. A wight is about the height and weight of a human.

            // Wights speak Common.

            // COMBAT

            // Wights attack by hammering with their fists.

            // Create Spawn (Su): Any humanoid slain by a wight becomes a wight in 1d4 rounds. Spawn are under the command of the wight that created them and remain enslaved until its death. They do not possess any of the abilities they had in life.

            // Energy Drain (Su): Living creatures hit by a wight’s slam attack gain one negative level. The DC is 14 for the Fortitude save to remove a negative level. The save DC is Charisma-based. For each such negative level bestowed, the wight gains 5 temporary hit points.

            // WOLF

            // Size/Type:	Medium Animal
            // Hit Dice:	2d8+4 (13 hp)
            // Initiative:	+2
            // Speed:	50 ft. (10 squares)
            // Armor Class:	14 (+2 Dex, +2 natural), touch 12, flat-footed 12
            // Full Attack:	Bite +3 melee (1d6+1)
            // Special Attacks:	Trip
            // Special Qualities:	Low-light vision, scent
            // Abilities:	Str 13, Dex 15, Con 15, Int 2, Wis 12, Cha 6
            // Skills:	Hide +2, Listen +3, Move Silently +3, Spot +3, Survival +1*
            // Feats:	TrackB, Weapon Focus (bite)
            // Wolves are pack hunters known for their persistence and cunning.

            // COMBAT

            // A favorite tactic is to send a few individuals against the foe’s front while the rest of the pack circles and attacks from the flanks or rear.

            // Trip (Ex): A wolf that hits with a bite attack can attempt to trip the opponent (+1 check modifier) as a free action without making a touch attack or provoking an attack of opportunity. If the attempt fails, the opponent cannot react to trip the wolf.


            // WORG

            // Size/Type:	Medium Magical Beast
            // Hit Dice:	4d10+8 (30 hp)
            // Initiative:	+2
            // Speed:	50 ft. (10 squares)
            // Armor Class:	14 (+2 Dex, +2 natural), touch 12, flat-footed 12
            // Full Attack:	Bite +7 melee (1d6+4)
            // Special Attacks:	Trip
            // Special Qualities:	Darkvision 60 ft., low-light vision, scent
            // Abilities:	Str 17, Dex 15, Con 15, Int 6, Wis 14, Cha 10
            // Skills:	Hide +4, Listen +6, Move Silently +6, Spot +6, Survival +2*
            // Feats:	Alertness, Track
            // A typical worg has gray or black fur, grows to 5 feet long and stands 3 feet tall at the shoulder. It weighs 300 pounds.

            // More intelligent than their smaller cousins, worgs speak their own language. Some can also speak Common and Goblin.

            // COMBAT

            // Mated pairs or packs work together to bring down large game, while lone worgs usually chase down creatures smaller than themselves. Both often use hit-and-run tactics to exhaust their quarry. A pack usually circles a larger opponent: Each wolf attacks in turn, biting and retreating, until the creature is exhausted, at which point the pack moves in for the kill. If they get impatient or heavily outnumber the opponent, worgs attempt to pin it.

            // Trip (Ex): A worg that hits with a bite attack can attempt to trip the opponent (+3 check modifier) as a free action without making a touch attack or provoking an attack of opportunity. If the attempt fails, the opponent cannot react to trip the worg.

            // WRAITH

            // Wraith
            // Size/Type:	Medium Undead (Incorporeal)
            // Hit Dice:	5d12 (32 hp)
            // Initiative:	+7
            // Speed:	Fly 60 ft. (good) (12 squares)
            // Armor Class:	15 (+3 Dex, +2 deflection), touch 15, flat-footed 12
            // Full Attack:	Incorporeal touch +5 melee (1d4 plus 1d6 Constitution drain)
            // Special Attacks:	Constitution drain, create spawn
            // Special Qualities:	Darkvision 60 ft., daylight powerlessness, incorporeal traits, +2 turn resistance, undead traits, unnatural aura
            // Abilities:	Str —, Dex 16, Con —, Int 14, Wis 14, Cha 15
            // Skills:	Diplomacy +6, Hide +11, Intimidate +10, Listen +12, Search +10, Sense Motive +8, Spot +12, Survival +2 (+4 following tracks)
            // Feats:	AlertnessB, Blind Fight, Combat Reflexes, Improved InitiativeB
            // Wraiths are incorporeal creatures born of evil and darkness. In some cases, the grim silhouette of a wraith might appear armored or outfitted with weapons. This appearance does not affect the creature’s AC or combat abilities but only reflects the shape it had in life.

            // A wraith is about as tall as a human, while a dread wraith is roughly the size of an ogre. Since both are incorporeal, they are weightless.

            // Wraiths speak Common and Infernal.

            // COMBAT

            // Unnatural Aura (Su): Animals, whether wild or domesticated, can sense the unnatural presence of a wraith at a distance of 30 feet. They will not willingly approach nearer than that and panic if forced to do so; they remain panicked as long as they are within that range.

            // Daylight Powerlessness (Ex): Wraiths are utterly powerless in natural sunlight (not merely a daylight spell) and flee from it.

            // Constitution Drain (Su): Living creatures hit by a wraith’s incorporeal touch attack must succeed on a DC 14 Fortitude save or take 1d6 points of Constitution drain. The save DC is Charisma-based. On each such successful attack, the wraith gains 5 temporary hit points.

            // Create Spawn (Su): Any humanoid slain by a wraith becomes a wraith in 1d4 rounds. Its body remains intact and inanimate, but its spirit is torn free from its corpse and transformed. Spawn are under the command of the wraith that created them and remain enslaved until its death. They do not possess any of the abilities they had in life.

            // WYVERN

            // Size/Type:	Large Dragon
            // Hit Dice:	7d12+14 (59 hp)
            // Initiative:	+1
            // Speed:	20 ft. (4 squares), fly 60 ft. (poor)
            // Armor Class:	18 (–1 size, +1 Dex, +8 natural), touch 10, flat-footed 17
            // Full Attack:	Sting +10 melee (1d6+4 plus poison) and bite +8 melee (2d8+4) and 2 wings +8 melee (1d8+2) and 2 talons +8 melee (2d6+4)
            // Special Attacks:	Poison, improved grab
            // Special Qualities:	Darkvision 60 ft., immunity to sleep and paralysis, low-light vision, scent
            // Abilities:	Str 19, Dex 12, Con 15, Int 6, Wis 12, Cha 9
            // Skills:	Hide +7, Listen +13, Move Silently +11, Spot +16
            // Feats:	Ability Focus (poison), Alertness, Flyby Attack, MultiattackB
            // A distant cousin to the true dragons, the wyvern is a huge flying lizard with a poisonous stinger in its tail.

            // A wyvern’s body is 15 feet long, and dark brown to gray; half that length is tail. Its wingspan is about 20 feet. A wyvern weighs about one ton.

            // Wyverns speak Draconic, but usually don’t bother with anything more elaborate than a loud hiss or a deep-throated growl much like that of a bull alligator.

            // COMBAT

            // Wyverns are rather stupid but always aggressive: They attack nearly anything that isn’t obviously more powerful than themselves. A wyvern dives from the air, snatching the opponent with its talons and stinging it to death. A wyvern can slash with its talons only when making a flyby attack.

            // Improved Grab (Ex): To use this ability, a wyvern must hit with its talons. It can then attempt to start a grapple as a free action without provoking an attack of opportunity. If it wins the grapple check, it establishes a hold and stings.

            // Poison (Ex): Injury, Fortitude DC 17, initial and secondary damage 2d6 Con. The save DC is Constitution-based.

            //http://www.dandwiki.com/wiki/SRD:Werewolf (Perhaps just a Feature/Flaw: lycanthropy)
        }
        private IEnumerable<Creature> SeedCreaturesStartingWithV(CreatureBuilderContext ctx)
        {
            yield return null;

            // Vermin
            //   http://www.dandwiki.com/wiki/SRD:Vampire

        }
        /* 
        
        V Creatures: (Checked) 6
        Vermin: spiders, snakes, scorpions, centipedes, vipers, sharks, all sizes
         */


        private IEnumerable<Creature> AddCreaturesStartingWithU(CreatureBuilderContext ctx)
        {
            var builder = new CreatureBuilder(ctx);
            yield return builder.HasName("Unicorn, Elder")
                                .HasDescriptionFile(@"Content\Creatures\Unicorn\description.md")
                                .WithCharacteristic("Large")
                                .HasEyes("Deep sea-blue, violet, brown, or fiery gold")
                                .HasHair("Males sport a white beard")
                                .HasAverageHeight("8ft long, 5ft tall at the shoulders")
                                .HasAverageWeight("1200lbs")
                                .HasRacialAbilityScores(strength: 22, agility: 20, focus: 20, charm: 22)
                                .HasSkills(concentration: 6, recall: 4, perception: 10, stealth: 10, survival: 10, animalHandling: 6)
                                .WithMod("Energy", 155)
                                .WithMod("Defense", 6)
                                .WithMod("Speed", 110)
                                .WithCharacteristic("Smite Foe")
                                .WithNaturalWeapon("Horn", WeaponUseAbility.Strength, WeaponUseAbility.Strength, "1d8", pierce: true)
                                .WithWeaponCharacteristic("Horn", "Weapon Training, 15")
                                .WithWeaponCharacteristic("Horn", "Weapon Specialization, 3")
                                .WithNaturalWeapon("Hooves", WeaponUseAbility.Strength, WeaponUseAbility.Agility, "1d4")
                                .WithWeaponCharacteristic("Hooves", "Weapon Training, 7")
                                .WithWeaponCharacteristic("Hooves", "Weak Weapon, 1")
                                //.WithArmor("Bracers, 5") TODO
                                .WithCharacteristic("Resistance, Slashing")
                                .WithCharacteristic("Resistance, Bludgeoning")
                                .WithCharacteristic("Resistance, Piercing")
                                .WithCharacteristic("Resistance, Acid")
                                .WithCharacteristic("Resistance, Cold")
                                .WithCharacteristic("Resistance, Electric")
                                .WithCharacteristic("Resistance, Mind-Affecting")
                                .WithCharacteristic("Immunity, All Poison")
                                .WithCharacteristic("Cat Like Vision")
                                .WithCharacteristic("Speak Language", "Sylvan")
                                .BuildAndReset();

            //                                 UNICORN

            // Unicorn
            // Size/Type:	Large Magical Beast
            // Hit Dice:	4d10+20 (42 hp)
            // Initiative:	+3
            // Speed:	60 ft. (12 squares)
            // Armor Class:	18 (–1 size, +3 Dex, +6 natural),, touch 12, flat-footed 15
            // Full Attack:	Horn +11 melee (1d8+8) and 2 hooves +3 melee (1d4+2)
            // Special Qualities:	Darkvision 60 ft., magic circle against evil, spell-like abilities, immunity to poison, charm, and compulsion, low-light vision, scent, wild empathy
            // Abilities:	Str 20, Dex 17, Con 21, Int 10, Wis 21, Cha 24
            // Skills:	Jump +21, Listen +11, Move Silently +9, Spot +11, Survival +8*
            // Feats:	Alertness, Skill Focus (Survival)
            // A unicorn has deep sea-blue, violet, brown, or fiery gold eyes. Males sport a white beard.

            // A typical adult unicorn grows to 8 feet in length, stands 5 feet high at the shoulder, and weighs 1,200 pounds. Females are slightly smaller and slimmer than males.

            // Unicorns speak Sylvan and Common.

            // COMBAT

            // Unicorns normally attack only when defending themselves or their forests. They either charge, impaling foes with their horns like lances, or strike with their hooves. The horn is a +3 magic weapon, though its power fades if removed from the unicorn.

            // Magic Circle against Evil (Su): This ability continuously duplicates the effect of the spell. A unicorn cannot suppress this ability.

            // Spell-Like Abilities: Unicorns can use detect evil at will as a free action.

            // Once per day a unicorn can use greater teleport to move anywhere within its home. It cannot teleport beyond the forest boundaries nor back from outside.

            // A unicorn can use cure light wounds three times per day and cure moderate wounds once per day (caster level 5th) by touching a wounded creature with its horn. Once per day it can use neutralize poison (DC 21, caster level 8th) with a touch of its horn. The save DC is Charisma-based.

            // Wild Empathy (Ex): This power works like the druid’s wild empathy class feature, except that a unicorn has a +6 racial bonus on the check.
        }

        private IEnumerable<Creature> AddDragons(CreatureBuilderContext ctx)
        {
            yield return null;

            // black, white, gold, silver, bronze, copper, red, green, blue
            // juvenille, adult, elder, great elder
        }
    }
}