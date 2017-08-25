using Elixr2.Api.Models;

namespace Elixr2.Api.Services.Seeding.Builders
{
    class WeaponBuilder
    {
        private readonly Weapon _weapon;
        public WeaponBuilder(CampaignSetting setting)
        {
            _weapon = new Weapon();
            _weapon.CampaignSettingId = setting.Id;
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
        public WeaponBuilder HasReach(bool hasReach = true)
        {
            _weapon.HasReach = hasReach;
            return this;
        }
        public WeaponBuilder MarkTwoHanded(bool twoHanded = true)
        {
            _weapon.IsTwoHanded = twoHanded;
            return this;
        }
        public WeaponBuilder MarkPiercing(bool piercing = true)
        {
            _weapon.CanPierce = piercing;
            return this;
        }
        public WeaponBuilder MarkSlashing(bool slashing = true)
        {
            _weapon.CanSlash = slashing;
            return this;
        }
        public WeaponBuilder MarkBludgeoning(bool bludgeoning = true)
        {
            _weapon.CanBludgeon = bludgeoning;
            return this;
        }
        public WeaponBuilder MarkIgnoresArmor(bool ignoresArmor = true)
        {
            _weapon.IgnoresArmor = ignoresArmor;
            return this;
        }
        public Weapon Build() => _weapon;
    }
}