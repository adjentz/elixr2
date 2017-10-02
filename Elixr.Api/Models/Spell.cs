using System;

namespace Elixr2.Api.Models
{
    public class Spell : GameElementBase
    {
        //A short description about how much Energy is required to produce an effect.
        public string EnergyRequired { get; set; }
        public bool IsConcentration { get; set; }
        public bool DoesDamage { get; set; }

        public override int Power => 1;
    }
}