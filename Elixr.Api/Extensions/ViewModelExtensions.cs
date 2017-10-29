using Elixr2.Api.Models;
using Elixr2.Api.ViewModels;
using System.Linq;

namespace Elixr2.Api.Extensions
{
    public static class ViewModelExtensions
    {
        public static CharacteristicViewModel ToViewModel(this Characteristic characteristic)
        {
            return new CharacteristicViewModel
            {
                Mods = characteristic.Mods.Select(m => m.ToViewModel()).ToList(),
                Name = characteristic.Name,
                Description = characteristic.Description,
                Type = characteristic.Type,
                CharacteristicId = characteristic.Id,
                SpecifiedPowerAdjustment = characteristic.SpecifiedPowerAdjustment
            };
        }

        public static TemplateViewModel ToViewModel(this Template template)
        {
            return new TemplateViewModel
            {
                TemplateId = template.Id,
                Name = template.Name,
                Description = template.Description,
                Mods = template.Mods.Select(m => m.ToViewModel()).ToList(),
                AppliedCharacteristics = template.AppliedCharacteristics.Select(tc => tc.ToViewModel()).ToList(),
                SelectedSpells = template.SelectedSpells.Select(ss => ss.ToViewModel()).ToList(),
                IsRace = template.IsRace
            };
        }
        public static SelectedCharacteristicViewModel ToViewModel(this SelectedCharacteristic takenCharacteristic)
        {
            return new SelectedCharacteristicViewModel
            {
                SelectedCharacteristicId = takenCharacteristic.Id,
                TakenAtMS = takenCharacteristic.TakenAtMS,
                TakenAtLevel = takenCharacteristic.TakenAtLevel,
                Characteristic = takenCharacteristic.Characteristic.ToViewModel(),
                IsTemplateCharacteristic = takenCharacteristic.IsTemplateCharacteristic,
                Notes = takenCharacteristic.Notes
            };
        }
        public static StatViewModel ToViewModel(this Stat stat)
        {
            return new StatViewModel
            {
                StatId = stat.Id,
                Name = stat.Name,
                Group = stat.Group,
                MaxValue = stat.MaxValue,
                MaxValueFormula = stat.MaxValueFormula,
                PowerRating = stat.PowerRating,
                NonModdable = stat.NonModdable,
                Ratio = stat.Ratio,
                ParentStatId = stat.ParentStatId ?? 0,
                Order = stat.Order,
                DisplayName = stat.DisplayName,
                Description = stat.Description
            };
        }
        public static StatModViewModel ToViewModel(this StatMod mod)
        {
            return new StatModViewModel
            {
                StatModId = mod.Id,
                Reason = mod.Reason,
                StatId = mod.StatId,
                Stat = mod.Stat?.ToViewModel(),
                Modifier = mod.Modifier,
            };
        }

        public static AppliedStatModViewModel ToViewModel(this AppliedStatMod appliedMod)
        {
            return new AppliedStatModViewModel
            {
                AppliedStatModId = appliedMod.Id,
                StatMod = appliedMod.StatMod.ToViewModel(),
                AppliedAtLevel = appliedMod.AppliedAtLevel
            };
        }
        public static CampaignSettingViewModel ToViewModel(this CampaignSetting setting)
        {
            return new CampaignSettingViewModel
            {
                CampaignSettingId = setting.Id,
                Name = setting.Name,
                Stats = setting.Stats.Select(s => s.ToViewModel()).ToList(),
                BaseDefense = setting.BaseDefense,
                MaxAbilityScore = setting.MaxAbilityScore,
                StartingAbilityPoints = setting.StartingAbilityPoints,
                SkillPointsEachLevel = setting.SkillPointsEachLevel,
                InitialMods = setting.InitialMods.Select(im => im.ToViewModel()).ToList(),
                ModsEachLevel = setting.ModsEachLevel.Select(mel => mel.ToViewModel()).ToList(),
                StartingWealth = setting.StartingWealth,
                MaxSkillRanksAboveLevel = setting.MaxSkillRanksAboveLevel,
                CharacteristicPointsEachLevel = setting.CharacteristicPointsEachLevel
            };
        }


        public static CreatureViewModel ToViewModel(this Creature creature)
        {
            return new CreatureViewModel
            {
                CreatureId = creature.Id,
                Level = creature.Level,
                Name = creature.Name,
                Age = creature.Age,
                Gender = creature.Gender,
                Weight = creature.Weight,
                Height = creature.Height,
                Hair = creature.Hair,
                Eyes = creature.Eyes,
                Skin = creature.Skin,
                Description = creature.Description,
                IsCharacter = creature.IsCharacter,
                Mods = creature.Mods.Select(m => m.ToViewModel()).ToList(),
                SelectedCharacteristics = creature.SelectedCharacteristics.Select(sc => sc.ToViewModel()).ToList(),
                SelectedWeapons = creature.SelectedWeapons.Select(sw => sw.ToViewModel()).ToList(),
                SelectedArmor = creature.SelectedArmor.Select(sa => sa.ToViewModel()).ToList(),
                SelectedTemplates = creature.SelectedTemplates.Select(st => st.ToViewModel()).ToList(),
                SelectedItems = creature.SelectedItems.Select(si => si.ToViewModel()).ToList(),
                SelectedSpells = creature.SelectedSpells.Select(ss => ss.ToViewModel()).ToList(),
                WealthAdjustments = creature.WealthAdjustments.Select(wa => wa.ToViewModel()).ToList()
            };
        }

        public static WeaponViewModel ToViewModel(this Weapon weapon)
        {
            return new WeaponViewModel
            {
                AttackAbility = weapon.AttackAbility,
                DamageAbility = weapon.DamageAbility,
                Damage = weapon.Damage,
                Range = weapon.Range,
                HasReach = weapon.HasReach,
                WeaponId = weapon.Id,
                Name = weapon.Name,
                Description = weapon.Description,
                GoldCost = weapon.GoldCost,
                SilverCost = weapon.SilverCost,
                CopperCost = weapon.CopperCost,
                WeightInPounds = weapon.WeightInPounds,
                IsTwoHanded = weapon.IsTwoHanded,
                CanSlash = weapon.CanSlash,
                CanBludgeon = weapon.CanBludgeon,
                CanPierce = weapon.CanPierce
            };
        }

        public static ArmorViewModel ToViewModel(this Armor armor)
        {
            return new ArmorViewModel
            {
                DefenseBonus = armor.DefenseBonus,
                ArmorId = armor.Id,
                SpeedPenalty = armor.SpeedPenalty,
                AgilityPenalty = armor.AgilityPenalty,
                GoldCost = armor.GoldCost,
                SilverCost = armor.SilverCost,
                CopperCost = armor.CopperCost,
                WeightInPounds = armor.WeightInPounds,
                Name = armor.Name,
                Description = armor.Description
            };
        }

        public static ItemViewModel ToViewModel(this Item item)
        {
            return new ItemViewModel
            {
                GoldCost = item.GoldCost,
                SilverCost = item.SilverCost,
                CopperCost = item.CopperCost,
                WeightInPounds = item.WeightInPounds,
                Name = item.Name,
                Description = item.Description,
                ItemId = item.Id
            };
        }

        public static SpellViewModel ToViewModel(this Spell spell)
        {
            return new SpellViewModel
            {
                SpellId = spell.Id,
                Name = spell.Name,
                Description = spell.Description,
                EnergyRequired = spell.EnergyRequired,
                IsConcentration = spell.IsConcentration,
                DoesDamage = spell.DoesDamage
            };
        }

        public static SelectedTemplateViewModel ToViewModel(this SelectedTemplate selectedTemplate)
        {
            return new SelectedTemplateViewModel
            {
                SelectedTemplateId = selectedTemplate.Id,
                Template = selectedTemplate.Template.ToViewModel(),
                SelectedAtMS = selectedTemplate.SelectedAtMS,
                Notes = selectedTemplate.Notes
            };
        }

        public static SelectedArmorViewModel ToViewModel(this SelectedArmor selectedArmor)
        {
            return new SelectedArmorViewModel
            {
                SelectedArmorId = selectedArmor.Id,
                Armor = selectedArmor.Armor.ToViewModel(),
                Notes = selectedArmor.Notes,
                SelectedAtMS = selectedArmor.SelectedAtMS
            };
        }

        public static SelectedWeaponViewModel ToViewModel(this SelectedWeapon selectedWeapon)
        {
            return new SelectedWeaponViewModel
            {
                SelectedWeaponId = selectedWeapon.Id,
                Weapon = selectedWeapon.Weapon.ToViewModel(),
                SelectedAtMS = selectedWeapon.SelectedAtMS,
                Notes = selectedWeapon.Notes,
                AppliedCharacteristics = selectedWeapon.AppliedCharacteristics.Select(ac => ac.ToViewModel()).ToList()
            };
        }

        public static SelectedItemViewModel ToViewModel(this SelectedItem selectedItem)
        {
            return new SelectedItemViewModel
            {
                SelectedItemId = selectedItem.Id,
                Item = selectedItem.Item.ToViewModel(),
                SelectedAtMS = selectedItem.SelectedAtMS,
                Notes = selectedItem.Notes
            };
        }
        public static SelectedSpellViewModel ToViewModel(this SelectedSpell selectedSpell)
        {
            return new SelectedSpellViewModel
            {
                SelectedSpellId = selectedSpell.Id,
                Spell = selectedSpell.Spell.ToViewModel(),
                SelectedAtMS = selectedSpell.SelectedAtMS,
                Notes = selectedSpell.Notes,
                SelectedAtLevel = selectedSpell.SelectedAtLevel,
                SelectedCharacteristics = selectedSpell.SelectedCharacteristics.Select(sc => sc.ToViewModel()).ToList()
            };
        }
        public static SelectedSpellCharacteristicViewModel ToViewModel(this SelectedSpellCharacteristic selectedSpellCharacteristic)
        {
            return new SelectedSpellCharacteristicViewModel
            {
                Characteristic = selectedSpellCharacteristic.Characteristic.ToViewModel(),
                SelectedSpellCharacteristicId = selectedSpellCharacteristic.Id,
                Notes = selectedSpellCharacteristic.Notes,
                TakenAtLevel = selectedSpellCharacteristic.TakenAtLevel,
                TakenAtMS = selectedSpellCharacteristic.TakenAtMS
            };
        }

        public static SpellCharacteristicViewModel ToViewModel(this SpellCharacteristic spellCharacteristic)
        {
            return new SpellCharacteristicViewModel
            {
                Description = spellCharacteristic.Description,
                SpellCharacteristicId = spellCharacteristic.Id,
                Name = spellCharacteristic.Name,
                SpecifiedPowerAdjustment = spellCharacteristic.SpecifiedPowerAdjustment
            };
        }

        public static WeaponCharacteristicViewModel ToViewModel(this WeaponCharacteristic weaponCharacteristic)
        {
            return new WeaponCharacteristicViewModel
            {
                Description = weaponCharacteristic.Description,
                Name = weaponCharacteristic.Name,
                SpecifiedPowerAdjustment = weaponCharacteristic.SpecifiedPowerAdjustment,
                WeaponCharacteristicId = weaponCharacteristic.Id,
                AttackBonusMod = weaponCharacteristic.AttackBonusMod,
                DamageBonusMod = weaponCharacteristic.DamageBonusMod,
                ExtraDamage = weaponCharacteristic.ExtraDamage
            };
        }
        public static SelectedWeaponCharacteristicViewModel ToViewModel(this SelectedWeaponCharacteristic selectedWeaponCharacteristic)
        {
            return new SelectedWeaponCharacteristicViewModel
            {
                Characteristic = selectedWeaponCharacteristic.Characteristic.ToViewModel(),
                Notes = selectedWeaponCharacteristic.Notes,
                SelectedWeaponCharacteristicId = selectedWeaponCharacteristic.Id,
                TakenAtLevel = selectedWeaponCharacteristic.TakenAtLevel,
                TakenAtMS = selectedWeaponCharacteristic.TakenAtMS
            };
        }
        public static WealthAdjustmentViewModel ToViewModel(this WealthAdjustment wealthAdjustment)
        {
            return new WealthAdjustmentViewModel
            {
                WealthAdjustmentId = wealthAdjustment.Id,
                Amount = wealthAdjustment.Amount,
                Reason = wealthAdjustment.Reason,
                AdjustedAtMS = wealthAdjustment.AdjustedAtMS
            };
        }
        public static SkillViewModel ToViewModel(this Skill skill)
        {
            return new SkillViewModel
            {
                StatId = skill.Id,
                Name = skill.Name,
                Group = skill.Group,
                MaxValue = skill.MaxValue,
                MaxValueFormula = skill.MaxValueFormula,
                PowerRating = skill.PowerRating,
                NonModdable = skill.NonModdable,
                Ratio = skill.Ratio,
                ParentStatId = skill.ParentStatId ?? 0,
                Order = skill.Order,
                DisplayName = skill.DisplayName,
                SpeedCost = skill.SpeedCost,
                OpposedBy = skill.OpposedBy,
                Description = skill.Description,
                HasDefense = skill.HasDefense,
                OnFailure = skill.OnFailure
            };
        }
    }
}