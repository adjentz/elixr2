namespace Elixr2.Api.ViewModels
{
    public class SelectedSpellCharacteristicViewModel
    {
        public int SelectedSpellCharacteristicId { get; set; }
        public long TakenAtMS { get; set; }
        public int TakenAtLevel { get; set; }
        public SpellCharacteristicViewModel Characteristic { get; set; }
        public string Notes { get; set; }
    }
}