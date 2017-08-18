namespace Elixr2.Api.Models
{
    public class SelectedSpellCharacteristic
    {
        public int Id { get; set; }
        public long TakenAtMS { get; set; }
        public int TakenAtLevel { get; set; }
        public int CharacteristicId { get; set; }
        public SpellCharacteristic Characteristic { get; set; }
        public string Notes { get; set; }
    }
}