using System;
using System.Collections.Generic;
using System.Linq;

namespace Elixr2.Api.Models
{
    public class Creature : GameElementBase
    {
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Skin { get; set; }
        public int Level { get; set; }
        public bool IsCharacter { get; set; }

        public List<WealthAdjustment> WealthAdjustments { get; set; } = new List<WealthAdjustment>();
        public List<AppliedStatMod> Mods { get; set; } = new List<AppliedStatMod>();
        public List<SelectedTemplate> SelectedTemplates { get; set; } = new List<SelectedTemplate>();
        public List<SelectedCharacteristic> SelectedCharacteristics { get; set; } = new List<SelectedCharacteristic>();
        public List<SelectedArmor> SelectedArmor { get; set; } = new List<SelectedArmor>();
        public List<SelectedWeapon> SelectedWeapons { get; set; } = new List<SelectedWeapon>();
        public List<SelectedItem> SelectedItems { get; set; } = new List<SelectedItem>();
        public List<SelectedSpell> SelectedSpells { get; set; } = new List<SelectedSpell>();

        public int GearPower
        {
            get
            {
                return SelectedWeapons.Sum(sw => sw.Weapon.CombatPower)
                + SelectedArmor.Sum(sa => sa.Armor.CombatPower)
                + SelectedItems.Sum(si => si.Item.CombatPower);
            }
        }
        public override int CombatPower
        {
            get
            {
                int power = SelectedSpells.Sum(ss => ss.Spell.CombatPower);
                power += Mods.Where(asm => asm.StatMod.Stat.PowerType == PowerType.Combat).Sum(asm => asm.StatMod.Power);
                power += SelectedCharacteristics.Sum(sc => sc.Characteristic.CombatPower);
                power += SelectedTemplates.Sum(st => st.Template.CombatPower);
                return power;
            }
        }
        public override int PresencePower
        {
            get
            {
                int power = SelectedSpells.Sum(ss => ss.Spell.PresencePower);
                power += Mods.Select(asm => asm.StatMod).Where(sm => sm.Stat.PowerType == PowerType.Presence).Sum(sm => sm.Power);
                power += SelectedCharacteristics.Sum(sc => sc.Characteristic.PresencePower);
                power += SelectedTemplates.Sum(st => st.Template.PresencePower);
                return power;
            }
        }

        public override int EnvironmentPower
        {
            get
            {
                int power = SelectedSpells.Sum(ss => ss.Spell.EnvironmentPower);
                power += Mods.Select(asm => asm.StatMod).Where(sm => sm.Stat.PowerType == PowerType.Environment).Sum(sm => sm.Power);
                power += SelectedCharacteristics.Sum(sc => sc.Characteristic.EnvironmentPower);
                power += SelectedTemplates.Sum(st => st.Template.EnvironmentPower);
                return power;
            }
        }
    }
}