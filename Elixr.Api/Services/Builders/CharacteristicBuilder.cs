
using Elixr2.Api.Models;
using System.Linq;
using System.Collections.Generic;

namespace Elixr2.Api.Services.Seeding.Builders
{
    class CharacteristicBuilder
    {
        Characteristic _characteristic;
        private CampaignSetting setting;
        public CharacteristicBuilder(CampaignSetting setting)
        {
            _characteristic = new Characteristic();
            _characteristic.CampaignSettingId = setting.Id;
            HasAuthor(setting.AuthorId);
            this.setting = setting;
        }
        public CharacteristicBuilder OfType(CharacteristicType type)
        {
            _characteristic.Type = type;
            return this;
        }
        public CharacteristicBuilder WithMod(StatMod statMod)
        {
            _characteristic.Mods.Add(statMod);
            return this;
        }
        public CharacteristicBuilder WithMod(string name, int modifier)
        {
            var stat = setting.Stats.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
            if (stat == null)
            {
                throw new System.Exception();
            }
            string reason = $"{this._characteristic.Type}: {this._characteristic.Name}";
            StatMod statMod = new StatMod(stat.Id, modifier, reason);
            WithMod(statMod);
            return this;
        }

        public CharacteristicBuilder HasName(string name)
        {
            _characteristic.Name = name;
            return this;
        }
        public CharacteristicBuilder HasDescription(string description)
        {
            _characteristic.Description = description;
            return this;
        }
        public CharacteristicBuilder HasDescriptionFile(string descFilePath, params object[] formatParams)
        {
            descFilePath = descFilePath.Replace("\\", "/");
            string desc = System.IO.File.ReadAllText(descFilePath);
            if (formatParams.Length > 0)
            {
                desc = string.Format(desc, formatParams);
            }
            return HasDescription(desc);
        }
        public CharacteristicBuilder HasSpecificCombatPower(int combatPower)
        {
            _characteristic.SpecifiedCombatPower = combatPower;
            return this;
        }
        public CharacteristicBuilder HasSpecificEnvironmentPower(int environmentPower)
        {
            _characteristic.SpecifiedEnvironmentPower = environmentPower;
            return this;
        }
        public CharacteristicBuilder HasSpecificPresencePower(int presencePower)
        {
            _characteristic.SpecifiedPresencePower = presencePower;
            return this;
        }

        public CharacteristicBuilder HasAuthor(int authorId)
        {
            _characteristic.AuthorId = authorId;
            return this;
        }
        public CharacteristicBuilder WithCondition(string description, int combatReduction, int envReduction, int presenceReduction)
        {
            CharacteristicCondition condition = new CharacteristicCondition
            {
                CombatPowerReduction = combatReduction,
                Description = description,
                EnvironmentPowerReduction = envReduction,
                PresencePowerReduction = presenceReduction
            };
            _characteristic.Conditions.Add(condition);
            return this;
        }
        public CharacteristicBuilder AsUpgradable(string description, int combatPowerIncrease = 0, int environmentPowerIncrease = 0, int presencePowerIncrease = 0, int maxTimesPerLevel = 1, List<StatMod> modsOnUpgrade = null)
        {
            _characteristic.UpgradeDescription = description;
            _characteristic.AdditionalModsOnUpgrade = modsOnUpgrade;
            _characteristic.UpgradeCombatPower = combatPowerIncrease;
            _characteristic.UpgradePresenceCost = presencePowerIncrease;
            _characteristic.UpgradeEnvironmentCost = environmentPowerIncrease;
            _characteristic.CanBeUpgraded = true;
        }
        

        public Characteristic Build()
        {
            try
            {
                return _characteristic;
            }
            finally
            {
                _characteristic = new Characteristic();
                _characteristic.CampaignSettingId = setting.Id;
                HasAuthor(setting.AuthorId);
            }
        }
    }
}