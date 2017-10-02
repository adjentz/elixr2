using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class SelectedWeapon : ModelBase
    {
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
        public long SelectedAtMS { get; set; }
        public string Notes { get; set; }
        public List<SelectedWeaponCharacteristic> AppliedCharacteristics { get; set; } = new List<SelectedWeaponCharacteristic>();
    }
}