using Elixr2.Api.Models;

namespace Elixr2.Api.Services.Seeding
{
    class SpellBuilder
    {
        private Spell _spell;
        public SpellBuilder(CampaignSetting setting)
        {
            this._spell = new Spell();
            this._spell.CampaignSettingId = setting.Id;
        }

        public SpellBuilder HasName(string name)
        {
            this._spell.Name = name;
            return this;
        }
        public SpellBuilder HasDescription(string desc)
        {
            this._spell.Description = desc;
            return this;
        }
        public SpellBuilder HasDescriptionFile(string path)
        {
            path = path.Replace("\\", "/");
            string desc = System.IO.File.ReadAllText(path);
            return this.HasDescription(desc);
        }
        public SpellBuilder HasEnergyRequirement(string energyCost)
        {
            _spell.EnergyRequired = energyCost;
            return this;
        }
        public SpellBuilder MarkConcentration(bool isConcentration = true)
        {
            _spell.IsConcentration = isConcentration;
            return this;
        }
        public SpellBuilder MarkDoesDamage(bool doesDamage = true)
        {
            _spell.DoesDamage = doesDamage;
            return this;
        }

        public Spell Build() => _spell;
    }
}