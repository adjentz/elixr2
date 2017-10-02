namespace Elixr2.Api.Models
{
    public abstract class EquipmentBase : GameElementBase
    {
        public int GoldCost { get; set; }
        public int SilverCost { get; set; }
        public int CopperCost { get; set; }
        public float WeightInPounds { get; set; }
    }
}