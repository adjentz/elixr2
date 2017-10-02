using Elixr2.Api.Models;

namespace Elixr2.Api.Services.Seeding.Builders
{
    class SpellCharacteristicBuilder
    {
        private readonly SpellCharacteristic _spellCharacteristic;
        public SpellCharacteristicBuilder(CampaignSetting setting)
        {
            _spellCharacteristic = new SpellCharacteristic();
            _spellCharacteristic.CampaignSettingId = setting.Id;
            HasAuthor(setting.AuthorId);
        }

        public SpellCharacteristicBuilder HasName(string name)
        {
            _spellCharacteristic.Name = name;
            return this;
        }
        public SpellCharacteristicBuilder HasDescription(string description)
        {
            _spellCharacteristic.Description = description;
            return this;
        }
        public SpellCharacteristicBuilder HasDescriptionFile(string descFilePath)
        {
            descFilePath = descFilePath.Replace("\\", "/");
            string desc = System.IO.File.ReadAllText(descFilePath);
            return HasDescription(desc);
        }
        public SpellCharacteristicBuilder HasSpecificPower(int power)
        {
            _spellCharacteristic.SpecifiedPowerAdjustment = power;
            return this;
        }
        public SpellCharacteristicBuilder HasAuthor(int authorId)
        {
            _spellCharacteristic.AuthorId = authorId;
            return this;
        }
        public SpellCharacteristic Build() => _spellCharacteristic;
    }
}