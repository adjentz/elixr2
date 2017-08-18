namespace Elixr2.Api.Models
{
    public interface IEquipment : ICampaignSettingElement
    {
        int GoldCost { get; set; }
        int SilverCost { get; set; }
        int CopperCost { get; set; }
        float WeightInPounds { get; set; }
    }
}