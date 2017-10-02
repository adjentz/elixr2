using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class SelectedArmor : ModelBase
    {
        public int ArmorId { get; set; }
        public Armor Armor { get; set; }
        public string Notes { get; set; }
        public long SelectedAtMS { get; set; }
    }
}