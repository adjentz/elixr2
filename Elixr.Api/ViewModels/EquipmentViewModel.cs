using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public abstract class EquipmentViewModel
    {
        
        public int GoldCost { get; set; }
        public int SilverCost { get; set; }
        public int CopperCost { get; set; }
        public float WeightInPounds { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}