using System.Collections.Generic;
using Elixr2.Api.Models;
using System.Linq;
using System;

namespace Elixr2.Api.Services.Seeding.Builders
{
    class CreatureBuilderContext
    {
        public CampaignSetting Setting { get; set; }
        public List<Characteristic> Characteristics { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armors { get; set; }
        public List<Spell> Spells { get; set; }
        public List<Template> Templates { get; set; }
        public List<WeaponCharacteristic> WeaponCharacteristics { get; set; }
        public List<SpellCharacteristic> SpellCharacteristics { get; set; }

    }
    class CreatureBuilder
    {
        private Creature creature;
        private readonly CreatureBuilderContext context;
        public CreatureBuilder(CreatureBuilderContext ctx)
        {
            creature = new Creature();
            creature.CampaignSettingId = ctx.Setting.Id;
            this.context = ctx;
        }

        public CreatureBuilder HasName(string name)
        {
            this.creature.Name = name;
            return this;
        }

        public CreatureBuilder HasDescription(string description)
        {
            creature.Description = description;
            return this;
        }
        public CreatureBuilder HasDescriptionFile(string descFilePath)
        {
            descFilePath = descFilePath.Replace("\\", "/");
            string desc = System.IO.File.Exists(descFilePath) ? System.IO.File.ReadAllText(descFilePath) : descFilePath;
            return HasDescription(desc);
        }

        public CreatureBuilder HasLifespan(string lifespan = null)
        {
            this.creature.Age = lifespan;
            return this;
        }
        public CreatureBuilder HasAverageWeight(string avgWeight = null)
        {
            this.creature.Weight = avgWeight;
            return this;
        }
        public CreatureBuilder HasAverageHeight(string avgHeight = null)
        {
            this.creature.Height = avgHeight;
            return this;
        }
        public CreatureBuilder HasRacialAbilityScores(int strength, int agility, int focus, int charm)
        {
            return this.WithMod("Racial Strength Score", strength)
                        .WithMod("Racial Agility Score", agility)
                        .WithMod("Racial Focus Score", focus)
                        .WithMod("Racial Charm Score", charm);
        }
        public CreatureBuilder HasHair(string hair = null)
        {
            this.creature.Hair = hair;
            return this;
        }
        public CreatureBuilder HasEyes(string eyes = null)
        {
            this.creature.Eyes = eyes;
            return this;
        }

        public CreatureBuilder WithSpecialWeaponCharacteristic(string weaponName, WeaponCharacteristic characteristic)
        {
            var selectedWeapon = creature.SelectedWeapons.First(sw => sw.Weapon.Name.ToLower() == weaponName.ToLower());
            selectedWeapon.AppliedCharacteristics.Add(new SelectedWeaponCharacteristic
            {
                Characteristic = characteristic
            });
            return this;
        }
        public CreatureBuilder WithSpecialWeaponCharacteristic(string weaponName, string name, string descriptionOrPath, int powerAdjustment, CharacteristicType type = CharacteristicType.Feature)
        {
            descriptionOrPath = descriptionOrPath.Replace("\\", "/");
            WeaponCharacteristic weaponCharacteristic = new WeaponCharacteristic
            {
                CampaignSettingId = creature.CampaignSettingId,
                Description = System.IO.File.Exists(descriptionOrPath) ? System.IO.File.ReadAllText(descriptionOrPath) : descriptionOrPath,
                IsDelisted = true,
                Name = name,
                SpecifiedPowerAdjustment = powerAdjustment
            };

            return WithSpecialWeaponCharacteristic(weaponName, weaponCharacteristic);
        }

        public CreatureBuilder WithSpecialCharacteristic(string name, string descriptionPath, int powerAdjustment, CharacteristicType type = CharacteristicType.Feature, params string[] formatParameters)
        {
            descriptionPath = descriptionPath.Replace("\\", "/");
            string description = System.IO.File.Exists(descriptionPath) ? System.IO.File.ReadAllText(descriptionPath) : descriptionPath;
            description = string.Format(description, formatParameters);

            CharacteristicBuilder builder = new CharacteristicBuilder(context.Setting);
            var characteristic = builder.HasDescription(description)
                                        .HasName(name)
                                        .HasSpecificPowerAdjustment(powerAdjustment)
                                        .OfType(type)
                                        .Build();

            this.creature.SelectedCharacteristics.Add(new SelectedCharacteristic
            {
                Characteristic = characteristic,
                IsTemplateCharacteristic = true
            });
            return this;
        }

        public CreatureBuilder WithSpecialCharacteristic(Characteristic characteristic)
        {
            this.creature.SelectedCharacteristics.Add(new SelectedCharacteristic
            {
                Characteristic = characteristic,
                IsTemplateCharacteristic = true
            });
            return this;
        }

        public CreatureBuilder HasSkin(string skin)
        {
            this.creature.Skin = skin;
            return this;
        }

        public CreatureBuilder HasPrimaryStats(int energy = 0, int defense = 0, int speed = 0)
        {
            return this.WithMod("Speed", speed)
                       .WithMod("Defense", defense)
                       .WithMod("Energy", energy);
        }
        public CreatureBuilder HasSkills(int athletics = 0, int climb = 0, int intimidate = 0, int swim = 0, // strength skills
        int acrobatics = 0, int escapeArtist = 0, int initiative = 0, int sleightOfHand = 0, int stealth = 0, // agility skills
        int concentration = 0, int engineer = 0, int insight = 0, int medicine = 0, int perception = 0, int recall = 0, int survival = 0, // focus skills
        int animalHandling = 0, int deception = 0, int diplomacy = 0, int perform = 0, int threaten = 0) // charm skills
        {
            return this.WithMod("Athletics", athletics)
                        .WithMod("Climb", climb)
                        .WithMod("Intimidate", intimidate)
                        .WithMod("Swim", swim)
                        .WithMod("Acrobatics", acrobatics)
                        .WithMod("Escape Artist", escapeArtist)
                        .WithMod("Initiative", initiative)
                        .WithMod("Sleight of Hand", sleightOfHand)
                        .WithMod("Stealth", stealth)
                        .WithMod("Concentration", concentration)
                        .WithMod("Engineer", engineer)
                        .WithMod("Insight", insight)
                        .WithMod("Medicine", medicine)
                        .WithMod("Perception", perception)
                        .WithMod("Recall", recall)
                        .WithMod("Survival", survival)
                        .WithMod("Animal Handling", animalHandling)
                        .WithMod("Deception", deception)
                        .WithMod("Diplomacy", diplomacy)
                        .WithMod("Perform", perform)
                        .WithMod("Threaten", threaten);
        }
        public CreatureBuilder WithMod(string stat, int mod, string reason = null)
        {
            if (mod == 0)
            {
                return this;
            }
            if (string.IsNullOrWhiteSpace(reason))
            {
                reason = $"Natural {reason}";
            }
            StatMod statMod = new StatMod
            {
                StatId = context.Setting.Stats.First(s => s.Name.ToLower() == stat.ToLower()).Id,
                Modifier = mod,
                Reason = reason,
            };
            creature.Mods.Add(new AppliedStatMod
            {
                StatMod = statMod,
            });

            return this;
        }
        public CreatureBuilder WithTemplates(params string[] templateNames)
        {
            foreach (var name in templateNames)
            {
                WithTemplate(name);
            }
            return this;
        }
        public CreatureBuilder WithTemplate(string templateName, string notes = null)
        {
            var template = context.Templates.First(t => t.Name.ToLower() == templateName.ToLower());
            creature.SelectedTemplates.Add(new SelectedTemplate
            {
                SelectedAtMS = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                TemplateId = template.Id,
                Notes = notes
            });
            return this;
        }
        public CreatureBuilder WithCharacteristics(params string[] names)
        {
            foreach (var name in names)
            {
                WithCharacteristic(name);
            }
            return this;
        }
        public CreatureBuilder WithCharacteristic(string name, string notes = null)
        {
            var characteristic = context.Characteristics.First(c => c.Name.ToLower() == name.ToLower());
            SelectedCharacteristic selectedCharacteristic = new SelectedCharacteristic
            {
                IsTemplateCharacteristic = true,
                CharacteristicId = characteristic.Id,
                Characteristic = characteristic,
                Notes = notes
            };
            creature.SelectedCharacteristics.Add(selectedCharacteristic);
            return this;
        }

        public CreatureBuilder WithArmors(params string[] armorNames)
        {
            foreach (var name in armorNames)
            {
                WithArmor(name);
            }
            return this;
        }
        public CreatureBuilder WithArmor(string armorName, string notes = null)
        {
            var armor = context.Armors.First(a => a.Name.ToLower() == armorName.ToLower());
            var selectedArmor = new SelectedArmor
            {
                ArmorId = armor.Id,
                Notes = notes,
                SelectedAtMS = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };
            creature.SelectedArmor.Add(selectedArmor);
            return this;
        }

        public CreatureBuilder WithWeaponCharacteristic(string weaponName, string characteristicName)
        {
            var weapon = creature.SelectedWeapons.First(sw => sw.Weapon.Name.ToLower() == weaponName.ToLower());
            var characteristic = this.context.WeaponCharacteristics.First(wc => wc.Name.ToLower() == characteristicName.ToLower());

            weapon.AppliedCharacteristics.Add(new SelectedWeaponCharacteristic
            {
                CharacteristicId = characteristic.Id,
            });
            return this;
        }
        public CreatureBuilder WithSpellCharacteristic(string spellName, string characteristicName)
        {
            var selectedSpell = creature.SelectedSpells.First(ss => ss.Spell.Name.ToLower() == spellName.ToLower());
            var characteristic = this.context.SpellCharacteristics.First(sc => sc.Name.ToLower() == characteristicName.ToLower());
            selectedSpell.SelectedCharacteristics.Add(new SelectedSpellCharacteristic
            {
                CharacteristicId = characteristic.Id,
            });
            return this;
        }

        public CreatureBuilder WithWeapons(params string[] weaponNames)
        {
            foreach (var name in weaponNames)
            {
                WithWeapon(name);
            }
            return this;
        }
        public CreatureBuilder WithWeapon(string spellName, string notes = null)
        {
            var weapon = context.Weapons.First(w => w.Name.ToLower() == spellName.ToLower());
            var selectedWeapon = new SelectedWeapon
            {
                WeaponId = weapon.Id,
                Weapon = weapon,
                Notes = notes,
                SelectedAtMS = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };
            creature.SelectedWeapons.Add(selectedWeapon);
            return this;
        }

        public CreatureBuilder WithNaturalWeapon(string name, WeaponUseAbility attackAbility, WeaponUseAbility damageAbility, string damage,
        bool slash = false, bool pierce = false, bool bludgeon = false, bool reach = false, int range = 0, bool ignoresArmor = false, string desc = null, string notes = null)
        {
            WeaponBuilder builder = new WeaponBuilder(context.Setting);
            builder.HasName(name)
                    .HasDescription(desc ?? "Natural Weapon")
                    .HasDamage(damage)
                    .UseDamageAbility(damageAbility)
                    .UseAttackAbility(attackAbility)
                    .HasRange(range)
                    .HasReach(reach)
                    .MarkBludgeoning(bludgeon)
                    .MarkPiercing(pierce)
                    .MarkSlashing(slash)
                    .MarkIgnoresArmor(ignoresArmor);

            Weapon weapon = builder.Build();
            weapon.IsDelisted = true;
            creature.SelectedWeapons.Add(new SelectedWeapon
            {
                Notes = notes ?? "Natural Weapon",
                Weapon = weapon
            });
            return this;
        }

        public CreatureBuilder WithSpells(params string[] spellNames)
        {
            foreach (var name in spellNames)
            {
                WithSpell(name);
            }
            return this;
        }
        public CreatureBuilder WithSpell(string spellName, string notes = null)
        {
            var spell = context.Spells.First(w => w.Name.ToLower() == spellName.ToLower());
            var selectedSpell = new SelectedSpell
            {
                SpellId = spell.Id,
                Spell = spell,
                Notes = notes,
                SelectedAtMS = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };
            creature.SelectedSpells.Add(selectedSpell);
            return this;
        }
        public Creature BuildAndReset()
        {
            creature.SelectedWeapons.Where(sw => sw.WeaponId > 0).ToList().ForEach(sw => sw.Weapon = null);
            try
            {
                return creature;
            }
            finally
            {
                creature = new Creature();
                creature.CampaignSettingId = this.context.Setting.Id;
            }
        }
    }
}