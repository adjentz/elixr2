using System;
using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class SpellCharacteristic : GameElementBase
    {
        public int? SpecifiedPowerAdjustment { get; set; }

        public override int CombatPower => SpecifiedPowerAdjustment ?? 0; //TODO: update as more properties appear?
        public override int PresencePower => 0;
        public override int EnvironmentPower => 0;
    }
}