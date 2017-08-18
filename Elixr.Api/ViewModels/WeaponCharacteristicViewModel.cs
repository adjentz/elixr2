using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public class WeaponCharacteristicViewModel
    {
        public int WeaponCharacteristicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AttackBonusMod { get; set; }
        public int DamageBonusMod { get; set; }
        public int? SpecifiedPowerAdjustment { get; set; }
        public string ExtraDamage { get; set; }
    }
}