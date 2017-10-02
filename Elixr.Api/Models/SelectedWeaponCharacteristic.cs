namespace Elixr2.Api.Models
{
    public class SelectedWeaponCharacteristic : ModelBase
    {
        public long TakenAtMS { get; set; }
        public int TakenAtLevel { get; set; }
        public int CharacteristicId { get; set; }
        public WeaponCharacteristic Characteristic { get; set; }
        public string Notes { get; set; }
    }
}