namespace Elixr2.Api.ViewModels
{
    public class DefaultWeaponCharacteristicViewModel
    {
        public int DefaultWeaponCharacteristicId {get;set;}
        public WeaponCharacteristicViewModel Characteristic { get; set; }
        public string Notes { get; set; }
    }
}