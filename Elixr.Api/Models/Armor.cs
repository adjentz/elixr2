
using System;

namespace Elixr2.Api.Models
{
    public class Armor : IEquipment
    {
        public int GoldCost { get; set; }
        public int SilverCost { get; set; }
        public int CopperCost { get; set; }
        public float WeightInPounds { get; set; }
        public int DefenseBonus { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CampaignSettingId { get; set; }
        public bool IsDelisted { get; set; }
        public int SpeedPenalty { get; set; }
        public int AgilityPenalty { get; set; }
    }
}