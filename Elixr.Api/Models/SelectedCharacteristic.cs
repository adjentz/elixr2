namespace Elixr2.Api.Models
{
    public class SelectedCharacteristic
    {
        public int Id { get; set; }
        public long TakenAtMS { get; set; }
        public int TakenAtLevel { get; set; }
        public int CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }
        // Is this characteristic from a template, such as a Race?
        public bool IsTemplateCharacteristic { get; set; }
        public string Notes { get; set; }
    }
}