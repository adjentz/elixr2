using System;
using System.Collections.Generic;
using System.Linq;

namespace Elixr2.Api.Models
{
    public enum WeaponUseAbility
    {
        Strength = 0,
        Agility = 1,
        Focus = 2,
        Charm = 3, // Not sure if there's actually a use for this, but in the interest of completeness...
        None = 4
    }
    public class Weapon : EquipmentBase
    {
        public WeaponUseAbility AttackAbility { get; set; }
        public WeaponUseAbility DamageAbility { get; set; }

        public string Damage { get; set; }
        public int Range { get; set; }

        public List<DefaultWeaponCharacteristic> DefaultCharacteristics { get; set; } = new List<DefaultWeaponCharacteristic>();

        public override int CombatPower
        {
            get
            {
                int power = Dice.FromNotation(Damage).AverageRoll;
                power += (int)Math.Ceiling(Range / 5.0); // ?? Make relative to CampaignSetting.SpeedScalePer5ft
                power += DefaultCharacteristics.Sum(dc => dc.Characteristic.CombatPower);

                // ?? Consider Attack/Damage Ability? -=1 for Ability == None ? 

                return power;
            }
        }
        public override int PresencePower => DefaultCharacteristics.Sum(dc => dc.Characteristic.PresencePower);
        public override int EnvironmentPower => DefaultCharacteristics.Sum(dc => dc.Characteristic.EnvironmentPower);
    }
}