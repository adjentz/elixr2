
using Elixr2.Api.Models;
using System.Linq;

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
        public CharacteristicBuilder HasSpecificPowerAdjustment(int? power = null)
        {
            _characteristic.SpecifiedPowerAdjustment = power;
            return this;
        }
        public CharacteristicBuilder HasAuthor(int authorId)
        {
            _characteristic.AuthorId = authorId;
            return this;
        }
        public Characteristic Build()
        {
            return _characteristic;
        }
    }
}