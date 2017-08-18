using System.Collections.Generic;

namespace Elixr2.Api.ViewModels
{
    public class SelectedArmorViewModel
    {
        public int SelectedArmorId { get; set; }
        public ArmorViewModel Armor { get; set; }
        public string Notes { get; set; }
        public long SelectedAtMS { get; set; }
    }
}