using System;
using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class WeaponCharacteristic : GameElementBase
    {
        public int AttackBonusMod { get; set; }
        public int DamageBonusMod { get; set; }
        public string ExtraDamage { get; set; }

        public int? SpecifiedPowerAdjustment { get; set; }

        public override int Power => throw new NotImplementedException();
    }
}