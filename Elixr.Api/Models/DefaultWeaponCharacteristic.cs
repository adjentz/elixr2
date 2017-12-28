namespace Elixr2.Api.Models
{
    public class DefaultWeaponCharacteristic : ModelBase
    {
        public int CharacteristicId { get; set; }
        public WeaponCharacteristic Characteristic { get; set; }
        public string Notes { get; set; }
    }
}