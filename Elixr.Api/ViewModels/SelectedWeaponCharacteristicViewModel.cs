using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public class SelectedWeaponCharacteristicViewModel
    {
        public int SelectedWeaponCharacteristicId { get; set; }
        public long TakenAtMS { get; set; }
        public int TakenAtLevel { get; set; }
        public WeaponCharacteristicViewModel Characteristic { get; set; }
        public string Notes { get; set; }
    }
}