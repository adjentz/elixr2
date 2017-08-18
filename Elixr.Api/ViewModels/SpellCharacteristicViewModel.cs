namespace Elixr2.Api.ViewModels
{
    public class SpellCharacteristicViewModel
    {
        public int SpellCharacteristicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? SpecifiedPowerAdjustment { get; set; }
    }
}