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
        
        public override int Power
        {
            get
            {
                //TODO: Each GameElement should have it's own Power, use that instead of calculating here.
                int power = 0;
                power += SelectedSpells.Count;
                power += Mods.Sum(asm => GetStatModPower(asm.StatMod));
                power += SelectedCharacteristics.Sum(sc => GetCharacteristicPower(sc.Characteristic));
                power += SelectedTemplates.Sum(st => GetTemplatePower(st.Template));
                return power;
            }
        }

        private int GetCharacteristicPower(Characteristic characteristic) => characteristic.SpecifiedPowerAdjustment ?? characteristic.Mods.Sum(sm => GetStatModPower(sm));
        private int GetStatModPower(StatMod statMod) => statMod.Stat.PowerRating * (int)Math.Ceiling(statMod.Modifier * 1.0f / statMod.Stat.Ratio);

        private int GetTemplatePower(Template template)
        {
            int power = 0;
            power += template.Mods.Sum(sm => GetStatModPower(sm));
            power += template.AppliedCharacteristics.Sum(ac => GetCharacteristicPower(ac.Characteristic));
            power += template.SelectedSpells.Count;
            return power;
        }
    }
}