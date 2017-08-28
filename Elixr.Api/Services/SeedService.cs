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
        public SeedService(ElixrDbContext dbContext)
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

            Stat athletics = new Stat("Athletics", StatGroup.SkillDefense, 2);
            athletics.ParentStat = strengthScore;
            standardCampaignSetting.Stats.Add(athletics);

            Stat climb = new Stat("Climb", StatGroup.Skill, 1);
            climb.ParentStat = strengthScore;
            climb.Order = 0;
            standardCampaignSetting.Stats.Add(climb);

            Stat intimidate = new Stat("Intimidate", StatGroup.Skill, 1);
            intimidate.ParentStat = strengthScore;
            intimidate.Order = 1;
            standardCampaignSetting.Stats.Add(intimidate);

            Stat swim = new Stat("Swim", StatGroup.Skill, 1);
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

            Stat acrobatics = new Stat("Acrobatics", StatGroup.SkillDefense, 2);
            acrobatics.ParentStat = agilityScore;
            standardCampaignSetting.Stats.Add(acrobatics);

            Stat escapeArtist = new Stat("Escape Artist", StatGroup.Skill, 1);
            escapeArtist.ParentStat = agilityScore;
            escapeArtist.Order = 0;
            standardCampaignSetting.Stats.Add(escapeArtist);

            Stat initiative = new Stat("Initiative", StatGroup.Skill, 1);
            initiative.ParentStat = agilityScore;
            initiative.Order = 1;
            standardCampaignSetting.Stats.Add(initiative);

            Stat sleightOfHand = new Stat("Sleight of Hand", StatGroup.Skill, 1);
            sleightOfHand.ParentStat = agilityScore;
            sleightOfHand.Order = 2;
            standardCampaignSetting.Stats.Add(sleightOfHand);

            Stat stealth = new Stat("Stealth", StatGroup.Skill, 1);
            stealth.ParentStat = agilityScore;
            sleightOfHand.Order = 3;
            standardCampaignSetting.Stats.Add(stealth);
        }
        private void AddFocusSkillsAndMisc()
        {
            Stat focusScore = standardCampaignSetting.Stats.First(s => s.Name == "Focus Score");

            Stat focusMisc = new Stat("Focus Misc", StatGroup.AbilityMisc, 8);
            focusMisc.ParentStat = focusScore;
            standardCampaignSetting.Stats.Add(focusMisc);

            Stat concentration = new Stat("Concentration", StatGroup.SkillDefense, 2);
            concentration.ParentStat = focusScore;
            standardCampaignSetting.Stats.Add(concentration);

            Stat engineer = new Stat("Engineer", StatGroup.Skill, 1);
            engineer.ParentStat = focusScore;
            engineer.Order = 0;
            standardCampaignSetting.Stats.Add(engineer);

            Stat insight = new Stat("Insight", StatGroup.Skill, 1);
            insight.ParentStat = focusScore;
            insight.Order = 1;
            standardCampaignSetting.Stats.Add(insight);

            Stat medicine = new Stat("Medicine", StatGroup.Skill, 1);
            medicine.ParentStat = focusScore;
            insight.Order = 2;
            standardCampaignSetting.Stats.Add(medicine);

            Stat perception = new Stat("Perception", StatGroup.Skill, 1);
            perception.ParentStat = focusScore;
            insight.Order = 3;
            standardCampaignSetting.Stats.Add(perception);

            Stat recall = new Stat("Recall", StatGroup.Skill, 1);
            recall.ParentStat = focusScore;
            insight.Order = 4;
            standardCampaignSetting.Stats.Add(recall);

            Stat survival = new Stat("Survival", StatGroup.Skill, 1);
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

            Stat animalHandling = new Stat("Animal Handling", StatGroup.Skill, 1);
            animalHandling.ParentStat = charmScore;
            animalHandling.Order = 0;
            standardCampaignSetting.Stats.Add(animalHandling);

            Stat deception = new Stat("Deception", StatGroup.Skill, 1);
            deception.ParentStat = charmScore;
            deception.Order = 1;
            standardCampaignSetting.Stats.Add(deception);

            Stat diplomacy = new Stat("Diplomacy", StatGroup.Skill, 1);
            diplomacy.ParentStat = charmScore;
            diplomacy.Order = 2;
            standardCampaignSetting.Stats.Add(diplomacy);

            Stat perform = new Stat("Perform", StatGroup.Skill, 1);
            perform.ParentStat = charmScore;
            perform.Order = 3;
            standardCampaignSetting.Stats.Add(perform);
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
                creatures = creatures.ToList();
            }
            catch(System.Exception ex)
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