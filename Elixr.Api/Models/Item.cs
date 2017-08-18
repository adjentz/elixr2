
using System;

namespace Elixr2.Api.Models
{
    public class Item : IEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GoldCost { get; set; }
        public int SilverCost { get; set; }
        public int CopperCost { get; set; }
        public float WeightInPounds { get; set; }
        public int CampaignSettingId { get; set; }
        public bool IsDelisted { get; set; }
    }
}