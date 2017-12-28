using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public class WeaponViewModel : EquipmentViewModel
    {
        public WeaponUseAbility AttackAbility { get; set; }
        public WeaponUseAbility DamageAbility { get; set; }
        public int WeaponId { get; set; }
        public string Damage { get; set; }
        public int Range { get; set; }
        public List<DefaultWeaponCharacteristicViewModel> DefaultCharacteristics { get; set; }
    }
}