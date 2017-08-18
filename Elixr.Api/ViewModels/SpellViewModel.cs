using System;

namespace Elixr2.Api.ViewModels
{
    public class SpellViewModel
    {
        public int SpellId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnergyRequired { get; set; }
        public bool IsConcentration { get; set; }
        public bool DoesDamage { get; set; }
    }
}