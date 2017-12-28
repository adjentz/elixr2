using Elixr2.Api.Models;

namespace Elixr2.Api.Services.Seeding.Builders
{
    class WeaponBuilder
    {
        private readonly Weapon _weapon;
        private readonly CampaignSetting setting;
        public WeaponBuilder(CampaignSetting setting)
        {
            _weapon = new Weapon();
            _weapon.CampaignSettingId = setting.Id;
            this.setting = setting;
            HasAuthor(setting.AuthorId);
        }

        public WeaponBuilder HasCost(int gold, int silver = 0, int copper = 0)
        {
            _weapon.GoldCost = gold;
            _weapon.SilverCost = silver;
            _weapon.CopperCost = copper;
            return this;
        }

        public WeaponBuilder HasName(string name)
        {
            _weapon.Name = name;
            return this;
        }
        public WeaponBuilder HasDescription(string description)
        {
            _weapon.Description = description;
            return this;
        }
        public WeaponBuilder HasDescriptionFile(string descFilePath)
        {
            descFilePath = descFilePath.Replace("\\", "/");
            string desc = System.IO.File.ReadAllText(descFilePath);
            return HasDescription(desc);
        }
        public WeaponBuilder HasWeight(float pounds)
        {
            _weapon.WeightInPounds = pounds;
            return this;
        }
        public WeaponBuilder UseAttackAbility(WeaponUseAbility ability)
        {
            _weapon.AttackAbility = ability;
            return this;
        }
        public WeaponBuilder UseDamageAbility(WeaponUseAbility ability)
        {
            _weapon.DamageAbility = ability;
            return this;
        }
        public WeaponBuilder HasDamage(string damage)
        {
            _weapon.Damage = damage;
            return this;
        }
        public WeaponBuilder HasRange(int feet)
        {
            _weapon.Range = feet;
            return this;
        }
        public WeaponBuilder HasAuthor(int authorId)
        {
            _weapon.AuthorId = authorId;
            return this;
        }
        public WeaponBuilder WithDefaultWeaponCharacteristic(string name, string description, int power)
        {
            var weaponCharacteristicBuilder = new WeaponCharacteristicBuilder(setting);
            var characteristic = weaponCharacteristicBuilder.HasName(name)
                                       .HasDescription(description)
                                       .HasAuthor(_weapon.AuthorId)
                                       .HasDescription(description)
                                       .HasSpecificCombatPower(power)
                                       .Build();

            _weapon.DefaultCharacteristics.Add(new DefaultWeaponCharacteristic
            {
                Characteristic = characteristic,
            });
            return this;
        }
        public WeaponBuilder WithDefaultWeaponCharacteristic(WeaponCharacteristic characteristic)
        {
            _weapon.DefaultCharacteristics.Add(new DefaultWeaponCharacteristic
            {
                CharacteristicId = characteristic.Id
            });
            return this;
        }
        public Weapon Build() => _weapon;
    }
}