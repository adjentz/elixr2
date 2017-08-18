using System.Collections.Generic;

namespace Elixr2.Api.ViewModels
{
    public class SelectedWeaponViewModel
    {
        public int SelectedWeaponId { get; set; }
        public WeaponViewModel Weapon { get; set; }
        public long SelectedAtMS { get; set; }
        public string Notes { get; set; }
        public List<SelectedWeaponCharacteristicViewModel> AppliedCharacteristics { get; set; }
    }
}