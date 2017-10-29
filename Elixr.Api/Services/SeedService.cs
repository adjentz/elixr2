using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elixr2.Api.Models;
using System.Linq;

namespace Elixr2.Api.Services.Seeding
{
    public partial class SeedService
    {
        private readonly CampaignSetting standardCampaignSetting;
        private readonly ElixrDbContext dbContext;
        private readonly GamerService gamerService;
        private readonly string theGameMasterPassword;

        private Gamer theGameMaster;
        public SeedService(SettingsService settingsService, GamerService gamerService, ElixrDbContext dbContext)
        {
            this.dbContext = dbContext;
            standardCampaignSetting = new CampaignSetting()
            {
                Code = CampaignSetting.StandardCampaignSettingCode,
                Name = "Standard",
                CharacteristicPointsEachLevel = 8,
                BaseDefense = 10,
                MaxAbilityScore = 18,
                SkillPointsEachLevel = 8,
                StartingAbilityPoints = 48,
                StartingWealth = 200,
                MaxSkillRanksAboveLevel = 3,
            };

            this.gamerService = gamerService;
            this.theGameMasterPassword = settingsService.GameMasterPassword;
            settingsService.FlushGameMasterPassword();

            AddCharacterStats();
            AddAbilityStats();
        }

        private void AddInitialMods()
        {
            var energy = standardCampaignSetting.Stats.FirstOrDefault(s => s.Name.ToLower() == "energy");
            StatMod initialEnergy = new StatMod
            {
                Modifier = 8,
                StatId = energy.Id,
                Reason = "Initial"
            };
            standardCampaignSetting.InitialMods.Add(initialEnergy);

            var speed = standardCampaignSetting.Stats.FirstOrDefault(s => s.Name.ToLower() == "speed");
            StatMod initialSpeed = new StatMod
            {
                Modifier = 60,
                StatId = speed.Id,
                Reason = "Initial"
            };
            standardCampaignSetting.InitialMods.Add(initialSpeed);
        }
        private void AddModsEachLevel()
        {
            var energy = standardCampaignSetting.Stats.FirstOrDefault(s => s.Name.ToLower() == "energy");
            StatMod levelEnergy = new StatMod
            {
                Modifier = 8,
                StatId = energy.Id,
                Reason = "Level+"
            };
            standardCampaignSetting.ModsEachLevel.Add(levelEnergy);
        }
        private void AddStrengthSkillsAndMisc()
        {
            Stat strengthScore = standardCampaignSetting.Stats.First(s => s.Name == "Strength Score");

            Stat strengthMisc = new Stat("Strength Misc", StatGroup.AbilityMisc, 8);
            strengthMisc.ParentStat = strengthScore;
            standardCampaignSetting.Stats.Add(strengthMisc);

            Skill athletics = new Skill("Athletics", 2);
            athletics.Description = "Athletics is the Skill to perform general feats of athleticism, such as jumping over a chasm or throwing a grappling hook.";
            athletics.SpeedCost = "Varies";
            athletics.OnFailure = "Varies";
            athletics.ParentStat = strengthScore;
            athletics.HasDefense = true;
            standardCampaignSetting.Stats.Add(athletics);

            var climb = new Skill("Climb", 1);
            climb.Description = "Climb is the Skill to scale difficult surfaces.";
            climb.SpeedCost = "10ft for every 5ft to scale.";
            climb.OnFailure = "The creature remains in the same spot";
            climb.ParentStat = strengthScore;
            climb.Order = 0;
            standardCampaignSetting.Stats.Add(climb);

            var intimidate = new Skill("Intimidate", 1);
            intimidate.Description = "Coerce a creature into performing an action they normally would not do for fear of being physically harmed otherwise.";
            intimidate.ParentStat = strengthScore;
            intimidate.Order = 1;
            intimidate.OnFailure = "The subject does feel intimidated";
            intimidate.SpeedCost = "30ft";
            standardCampaignSetting.Stats.Add(intimidate);

            var swim = new Skill("Swim", 1);
            swim.Description = "Swim is the Skill to move through water quickly and effecively. Calm water does not require a check.";
            swim.SpeedCost = "10ft for every 5ft to swim";
            swim.OnFailure = "The creature begins to sink";
            swim.ParentStat = strengthScore;
            intimidate.Order = 2;
            standardCampaignSetting.Stats.Add(swim);
        }
        private void AddAgilitySkillsAndMisc()
        {
            Stat agilityScore = standardCampaignSetting.Stats.First(s => s.Name == "Agility Score");

            Stat agilityMisc = new Stat("Agility Misc", StatGroup.AbilityMisc, 8);
            agilityMisc.ParentStat = agilityScore;
            standardCampaignSetting.Stats.Add(agilityMisc);

            Skill acrobatics = new Skill("Acrobatics", 2);
            acrobatics.Description = "Acrobatics is the Skill to balance on a ledge, tumble between a giant's legs, dodge out of harm's way, and reduce fall damage.";
            acrobatics.SpeedCost = "Varies";
            acrobatics.OnFailure = "Varies";
            acrobatics.ParentStat = agilityScore;
            acrobatics.HasDefense = true;
            standardCampaignSetting.Stats.Add(acrobatics);

            var escapeArtist = new Skill("Escape Artist", 1);
            escapeArtist.Description = "Escape Artist is the Skill to escape restraints such as handcuffs and knots.";
            escapeArtist.SpeedCost = "30ft";
            escapeArtist.OnFailure = "The creature remains restrained.";
            escapeArtist.ParentStat = agilityScore;
            escapeArtist.Order = 0;
            standardCampaignSetting.Stats.Add(escapeArtist);

            var initiative = new Skill("Initiative", 1);
            initiative.Description = "In-game, Initiaitve is how quickly a creature respond to a situation. Around the table, Initiative indicates whose turn is first. See the combat section in Playing Elixr for more information.";
            initiative.SpeedCost = "0ft";
            initiative.OnFailure = "N/A";
            initiative.ParentStat = agilityScore;
            initiative.Order = 1;
            standardCampaignSetting.Stats.Add(initiative);

            var sleightOfHand = new Skill("Sleight of Hand", 1);
            sleightOfHand.Description = "Stealth is the Skill to move and hide without being noticed. It is combined with some manner of misdirection, and therefore has a Speed Cost of 30ft";
            sleightOfHand.SpeedCost = "30ft";
            sleightOfHand.OpposedBy = "Perception";
            sleightOfHand.OnFailure = "Opponents have a chance to notice the sleight on their turn through a Perception check.";
            sleightOfHand.ParentStat = agilityScore;
            sleightOfHand.Order = 2;
            standardCampaignSetting.Stats.Add(sleightOfHand);

            var stealth = new Skill("Stealth", 1);
            stealth.ParentStat = agilityScore;
            stealth.Description = "Stealth is this Skill to move and hide without being noticed.";
            stealth.SpeedCost = "10ft for every 5ft traveled";
            stealth.OpposedBy = "Perception";
            stealth.OnFailure = "Opponents have a chance to notice the sneaking individual on their turn through a Perception check.";
            sleightOfHand.Order = 3;
            standardCampaignSetting.Stats.Add(stealth);
        }
        private void AddFocusSkillsAndMisc()
        {
            Stat focusScore = standardCampaignSetting.Stats.First(s => s.Name == "Focus Score");

            Stat focusMisc = new Stat("Focus Misc", StatGroup.AbilityMisc, 8);
            focusMisc.ParentStat = focusScore;
            standardCampaignSetting.Stats.Add(focusMisc);

            var concentration = new Skill("Concentration", 2);
            concentration.Description = "Concentration is the Skill to not be distracted, as well as protect your mind from certain spells.";
            concentration.SpeedCost = "0ft";
            concentration.OnFailure = "Varies";
            concentration.ParentStat = focusScore;
            concentration.HasDefense = true;
            standardCampaignSetting.Stats.Add(concentration);

            var engineer = new Skill("Engineer", 1);
            engineer.Description = "Engineer is the Skill to create items and discern structural details.";
            engineer.SpeedCost = "Varies";
            engineer.OnFailure = "The result is ineffective.";
            engineer.ParentStat = focusScore;
            engineer.Order = 0;
            standardCampaignSetting.Stats.Add(engineer);

            var insight = new Skill("Insight", 1);
            insight.Description = "Insight is the Skill to discern information from subtle details.";
            insight.SpeedCost = "0ft";
            insight.OnFailure = "No extra information is discerned";
            insight.ParentStat = focusScore;
            insight.Order = 1;
            standardCampaignSetting.Stats.Add(insight);

            var medicine = new Skill("Medicine", 1);
            medicine.Description = "Medicine is the Skill to determine a creatures ailments and apply cures to some wounds.";
            medicine.SpeedCost = "Varies, at least 50ft";
            medicine.OnFailure = "The treatment is ineffective";
            medicine.ParentStat = focusScore;
            insight.Order = 2;
            standardCampaignSetting.Stats.Add(medicine);

            var perception = new Skill("Perception", 1);
            perception.Description = "Perception is the Skill to notice the presence or absence of other entites through sound, sight, smell, or other sense.";
            perception.SpeedCost = "0ft";
            perception.OnFailure = "Something goes unnoticed";
            perception.ParentStat = focusScore;
            insight.Order = 3;
            standardCampaignSetting.Stats.Add(perception);

            var recall = new Skill("Recall", 1);
            recall.Description = "Recall is the Skill to remember information that a creature would have collected in the past. The information must be something a creature would already know. The GM can challenge if a creature would actually have the information depending on their background.";
            recall.SpeedCost = "0ft";
            recall.OnFailure = "The information isn't available to the creature. A retry can only be attempted 24 hours later for the same information.";
            recall.ParentStat = focusScore;
            insight.Order = 4;
            standardCampaignSetting.Stats.Add(recall);

            var survival = new Skill("Survival", 1);
            survival.Description = "Survival is the Skill to survive in the wild. Can include things such as tying knots in a rope, lighting a fire, or discerning what direction is North.";
            survival.SpeedCost = "Varies";
            survival.OnFailure = "The action is unsuccessful.";
            survival.ParentStat = focusScore;
            survival.Order = 5;
            standardCampaignSetting.Stats.Add(survival);
        }

        private void AddAbilityStats()
        {

            Stat strengthScore = new Stat("Strength Score", StatGroup.Ability, 4, 18);
            strengthScore.DisplayName = "Strength";
            standardCampaignSetting.Stats.Add(strengthScore);

            Stat racialStrengthScore = new Stat("Racial Strength Score", StatGroup.RacialAbility, 4);
            racialStrengthScore.ParentStat = strengthScore;
            standardCampaignSetting.Stats.Add(racialStrengthScore);

            Stat agilityScore = new Stat("Agility Score", StatGroup.Ability, 4, 18);
            agilityScore.DisplayName = "Agility";
            standardCampaignSetting.Stats.Add(agilityScore);

            Stat racialAgilityScore = new Stat("Racial Agility Score", StatGroup.RacialAbility, 4);
            racialAgilityScore.ParentStat = agilityScore;
            standardCampaignSetting.Stats.Add(racialAgilityScore);

            Stat focusScore = new Stat("Focus Score", StatGroup.Ability, 4, 18);
            focusScore.DisplayName = "Focus";
            standardCampaignSetting.Stats.Add(focusScore);

            Stat racialFocusScore = new Stat("Racial Focus Score", StatGroup.RacialAbility, 4);
            racialFocusScore.ParentStat = focusScore;
            standardCampaignSetting.Stats.Add(racialFocusScore);

            Stat charmScore = new Stat("Charm Score", StatGroup.Ability, 4, 18);
            charmScore.DisplayName = "Charm";
            standardCampaignSetting.Stats.Add(charmScore);

            //Racial Charm score is intentionally lower...
            Stat racialCharmScore = new Stat("Racial Charm Score", StatGroup.RacialAbility, 0);
            racialCharmScore.ParentStat = charmScore;
            standardCampaignSetting.Stats.Add(racialCharmScore);
        }

        private void AddCharmSkillsAndMisc()
        {
            Stat charmScore = standardCampaignSetting.Stats.First(s => s.Name == "Charm Score");

            Stat charm = new Stat("Charm Misc", StatGroup.AbilityMisc, 8);
            charm.ParentStat = charmScore;
            standardCampaignSetting.Stats.Add(charm);

            var animalHandling = new Skill("Animal Handling", 1);
            animalHandling.Description = "Animal Handling is the Skill to effectively interact with animals. A successful check will shift an animals attitude by one step in a positive direction. See Social Interaction in the Playing Elixr section";
            animalHandling.ParentStat = charmScore;
            animalHandling.SpeedCost = "50ft";
            animalHandling.OnFailure = "If the check fails by a difference of 5 or more, the animal's attitude shifts one step in a negative direction. Otherwise the animal remains at it's previous stance towards the creature.";
            animalHandling.Order = 0;
            standardCampaignSetting.Stats.Add(animalHandling);

            var deception = new Skill("Deception", 1);
            deception.Description = "Deception is the Skill to bluff and misdirect others. If a lie is too unbelievable, a GM may allow the target to roll with Advantage, or increase the Difficulty of performing the Deception.";
            deception.SpeedCost = "0ft";
            deception.OpposedBy = "Insight";
            deception.OnFailure = "Opponents have a chance to notice a tell and become wary of what is said on their turn through an Insight check.";
            deception.ParentStat = charmScore;
            deception.Order = 1;
            standardCampaignSetting.Stats.Add(deception);

            var diplomacy = new Skill("Diplomacy", 1);
            diplomacy.Description = "Diplomacy is the Skill to cause other to see your point of view. A successful check will shift another's attitude towards the creature by one step in a postive direction. Diplomacy cannot be used to coerce a creature into taking an action that would be against their character. Diplomacy checks cannot be used on player characters.";
            diplomacy.SpeedCost = "0ft";
            diplomacy.OpposedBy = "Diplomacy (counter from opponent)";
            diplomacy.OnFailure = "If the check fails by a difference of 5 or more, the target's attitude shifts one step in a negative direction. Otherwise the target remains at it's previous stance towards the creature.";
            diplomacy.ParentStat = charmScore;
            diplomacy.Order = 2;
            standardCampaignSetting.Stats.Add(diplomacy);

            var perform = new Skill("Perform", 1);
            perform.SpeedCost = "Varies, at least 50ft";
            perform.OnFailure = "The audience doesn't pay much attention to the performer, or boos if the performer is particularily bad.";
            perform.Description = "Perform is the Skill to effectively capture the attention of others through song, stories, dance, or playing an instrument. A character's background should specify what talents they have ahead of time. On exceptional checks, the audience may even tip the performer.";
            perform.ParentStat = charmScore;
            perform.Order = 3;
            standardCampaignSetting.Stats.Add(perform);

            var threaten = new Skill("Threaten", 1);
            threaten.Description = "Coerce a creature into performing an action they normally would not do for fear of what you say will happen if they don't.";
            threaten.ParentStat = charmScore;
            threaten.Order = 2;
            threaten.OnFailure = "The subject does not feel threatened";
            threaten.SpeedCost = "30ft";
            standardCampaignSetting.Stats.Add(threaten);
        }
        private void AddChildStats()
        {
            AddStrengthSkillsAndMisc();
            AddAgilitySkillsAndMisc();
            AddFocusSkillsAndMisc();
            AddCharmSkillsAndMisc();

            var allSkills = standardCampaignSetting.Stats.Where(s => s.Group == StatGroup.Skill || s.Group == StatGroup.SkillDefense).ToList();
            allSkills.ForEach(s =>
            {
                var skillMiscStat = new Stat(s.Name + " Misc.", StatGroup.SkillMisc, s.PowerRating);
                skillMiscStat.ParentStat = s;
                standardCampaignSetting.Stats.Add(skillMiscStat);

                s.MaxValueFormula = "{level} + 3";
            });
        }
        private void AddCharacterStats()
        {
            var energy = new Stat("Energy", StatGroup.Character, 3);
            standardCampaignSetting.Stats.Add(energy);

            Stat defense = new Stat("Defense", StatGroup.Character, 3);
            standardCampaignSetting.Stats.Add(defense);

            Stat speed = new Stat("Speed", StatGroup.Character, 6)
            {
                Ratio = 5
            };
            standardCampaignSetting.Stats.Add(speed);
        }

        public async Task SeedInitial(bool force)
        {
            if (force)
            {
                await dbContext.Database.EnsureDeletedAsync();
                await dbContext.Database.MigrateAsync();
            }
            else
            {
                bool alreadyApplied = await dbContext.CampaignSettings.AnyAsync(cs => cs.Code == CampaignSetting.StandardCampaignSettingCode);

                if (alreadyApplied)
                {
                    return;
                }
            }

            theGameMaster = await gamerService.AddGamer("The Game Master", theGameMasterPassword, code: Gamer.TheGameMasterCode);
            standardCampaignSetting.AuthorId = theGameMaster.Id;

            dbContext.CampaignSettings.Add(standardCampaignSetting);
            await dbContext.SaveChangesAsync();

            //Stats need to be inserted (have an Id) before the following can be created (thus the multiple call to SaveChanges).
            AddInitialMods();
            AddModsEachLevel();

            AddEquipment();
            AddChildStats();
            dbContext.Entry(standardCampaignSetting).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();


            AddFeatures();
            AddFlaws();
            AddOaths();

            AddSpells();

            dbContext.Entry(standardCampaignSetting).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            var characteristics = await dbContext.Characteristics.ToListAsync();
            var spells = await dbContext.Spells.ToListAsync();
            var spellCharacteristics = await dbContext.SpellCharacteristics.ToListAsync();
            AddTemplates(characteristics, spells, spellCharacteristics);

            dbContext.Entry(standardCampaignSetting).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            var armors = await dbContext.Armor.ToListAsync();
            var weapons = await dbContext.Weapons.ToListAsync();
            var templates = await dbContext.Templates.ToListAsync();
            var weaponCharacteristics = await dbContext.WeaponCharacteristics.ToListAsync();

            var creatures = AddCreatures(characteristics, armors, weapons, spells, templates, spellCharacteristics, weaponCharacteristics);
            //need to save the natural weapons and special features first

            try
            {
                creatures = creatures.Where(c => c != null).ToList();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            var naturalWeapons = creatures.SelectMany(c => c.SelectedWeapons).Where(sw => sw.Weapon?.Id == 0).Select(sw => sw.Weapon).ToList();
            naturalWeapons.ForEach(nw => dbContext.Weapons.Add(nw));
            var specialCharacteristics = creatures.SelectMany(c => c.SelectedCharacteristics).Where(sc => sc.Characteristic?.Id == 0).Select(sc => sc.Characteristic).ToList();
            specialCharacteristics.ForEach(sc => dbContext.Characteristics.Add(sc));

            await dbContext.SaveChangesAsync();


            creatures.ToList().ForEach(c => dbContext.Creatures.Add(c));

            await dbContext.SaveChangesAsync();
        }
    }
}