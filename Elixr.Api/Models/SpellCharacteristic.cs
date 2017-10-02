using System;
using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class SpellCharacteristic : GameElementBase
    {
        public int? SpecifiedPowerAdjustment { get; set; }

        public override int Power => SpecifiedPowerAdjustment ?? 0; //TODO: update as more properties appear?
    }
}