using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public class ArmorViewModel : EquipmentViewModel
    {
        public int DefenseBonus { get; set; }
        public int ArmorId { get; set; }
        public int SpeedPenalty { get; set; }
        public int AgilityPenalty { get; set; }
    }
}