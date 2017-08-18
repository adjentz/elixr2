using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public class CharacteristicViewModel
    {
        public List<StatModViewModel> Mods { get; set; }
        public string Name { get; set; }
        public int CharacteristicId { get; set; }
        public string Description { get; set; }
        public CharacteristicType Type { get; set; }
        public int? SpecifiedPowerAdjustment { get; set; }
    }
}