using Elixr2.Api.Models;

namespace Elixr2.Api.Services.Seeding.Builders
{
    class WeaponCharacteristicBuilder
    {
        private readonly WeaponCharacteristic _weaponCharacteristic;
        public WeaponCharacteristicBuilder(CampaignSetting setting)
        {
            _weaponCharacteristic = new WeaponCharacteristic();
            _weaponCharacteristic.CampaignSettingId = setting.Id;
        }

        public WeaponCharacteristicBuilder HasName(string name)
        {
            _weaponCharacteristic.Name = name;
            return this;
        }
        public WeaponCharacteristicBuilder HasAttackBonusMod(int mod)
        {
            _weaponCharacteristic.AttackBonusMod = mod;
            return this;
        }
        public WeaponCharacteristicBuilder HasDamageBonusMod(int mod)
        {
            _weaponCharacteristic.DamageBonusMod = mod;
            return this;
        }
        public WeaponCharacteristicBuilder HasExtraDamage(string damage)
        {
            _weaponCharacteristic.ExtraDamage = damage;
            return this;
        }
        public WeaponCharacteristicBuilder HasDescription(string description)
        {
            _weaponCharacteristic.Description = description;
            return this;
        }
        public WeaponCharacteristicBuilder HasDescriptionFile(string descFilePath, params string[] formatStrParams)
        {
            descFilePath = descFilePath.Replace("\\", "/");
            string desc = System.IO.File.ReadAllText(descFilePath);
            desc = string.Format(desc, formatStrParams);
            return HasDescription(desc);
        }
        public WeaponCharacteristicBuilder HasSpecificPower(int power)
        {
            _weaponCharacteristic.SpecifiedPowerAdjustment = power;
            return this;
        }
        public WeaponCharacteristic Build() => _weaponCharacteristic;
    }
}