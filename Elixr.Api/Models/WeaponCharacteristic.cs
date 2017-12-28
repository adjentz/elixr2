using System;
using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class WeaponCharacteristic : GameElementBase
    {
        public int AttackBonusMod { get; set; }
        public int DamageBonusMod { get; set; }
        public string ExtraDamage { get; set; }

        public int? SpecifiedCombatPower { get; set; }
        
        public override int CombatPower
        {
            get
            {
                if(SpecifiedCombatPower.HasValue)
                {
                    return SpecifiedCombatPower.Value;
                }

                int power = 0;
                if(!string.IsNullOrWhiteSpace(ExtraDamage))
                {
                    power += Dice.FromNotation(ExtraDamage).AverageRoll;
                }
                power += AttackBonusMod * CampaignSetting.AttackBonusScale;
                power += DamageBonusMod * CampaignSetting.DamageBonusScale;
                return power;
            }
        }
        public override int PresencePower => 0;
        public override int EnvironmentPower => 0;
    }
}