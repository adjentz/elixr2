
using System;

namespace Elixr2.Api.Models
{
    public class Armor : EquipmentBase
    {
        public int DefenseBonus { get; set; }

        public int SpeedPenalty { get; set; }
        public int AgilityPenalty { get; set; }

        public override int Power => 1337;
    }
}