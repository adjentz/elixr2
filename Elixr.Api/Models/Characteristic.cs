using System;
using System.Collections.Generic;
using System.Linq;

namespace Elixr2.Api.Models
{
    public class Characteristic : GameElementBase
    {
        public Characteristic()
        {
            Mods = new List<StatMod>();
        }

        public CharacteristicUpgrade UpgradeDescription { get; set; }

        public CharacteristicType Type { get; set; }
        public List<StatMod> Mods { get; set; }
        public List<CharacteristicCondition> Conditions { get; set; }
        // Can only be added to Races/Templates. A creature without a template is considered itself to be a template for the sake of this property.
        public bool IsTemplateOnly { get; set; }

        public int? SpecifiedCombatPower { get; set; }
        public int? SpecifiedPresencePower { get; set; }
        public int? SpecifiedEnvironmentPower { get; set; }

        public override int CombatPower
        {
            get
            {
                int power = SpecifiedCombatPower ?? Mods.Where(sm => sm.Stat.PowerType == PowerType.Combat).Sum(sm => sm.Power);
                return power - Conditions?.Sum(c => c.CombatPowerReduction);
            }
        }
        public override int PresencePower
        {
            get
            {
                int power = SpecifiedPresencePower ?? Mods.Where(sm => sm.Stat.PowerType == PowerType.Presence).Sum(sm => sm.Power);
                return power - Conditions?.Sum(c => c.PresencePowerReduction);
            }
        }
        public override int EnvironmentPower
        {
            get
            {
                int power = SpecifiedEnvironmentPower ?? Mods.Where(sm => sm.Stat.PowerType == PowerType.Environment).Sum(sm => sm.Power);
                return power - Conditions?.Sum(c => c.EnvironmentPowerReduction);
            }
        }

    }
}