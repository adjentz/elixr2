using System;
using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class Characteristic : GameElementBase
    {
        public Characteristic()
        {
            Mods = new List<StatMod>();
        }
        public CharacteristicType Type { get; set; }
        public List<StatMod> Mods { get; set; }
        // Can only be added to Races/Templates. A creature without a template is considered itself to be a template for the sake of this property.
        public bool IsTemplateOnly { get; set; }
        //Used to override the calculated power
        public int? SpecifiedPowerAdjustment { get; set; }

        public override int Power => 1337;
    }
}