using System.Collections.Generic;
using Elixr2.Api.Models;
using System.Linq;

namespace Elixr2.Api.Services.Seeding.Builders
{
    class TemplateBuilder
    {
        private readonly CampaignSetting setting;
        private readonly Template _template;
        private readonly List<Characteristic> characteristics;
        private readonly List<Spell> spells;
        private readonly List<SpellCharacteristic> spellCharacteristics;
        public TemplateBuilder(CampaignSetting setting, List<Characteristic> characteristics, List<Spell> spells, List<SpellCharacteristic> spellCharacteristics)
        {
            this.characteristics = characteristics;
            _template = new Template();
            _template.CampaignSettingId = setting.Id;
            this.setting = setting;
            this.spells = spells;
            this.spellCharacteristics = spellCharacteristics;
        }

        public TemplateBuilder AsRace(bool isRace)
        {
            _template.IsRace = isRace;
            return this;
        }
        public TemplateBuilder HasName(string name)
        {
            _template.Name = name;
            return this;
        }
        public TemplateBuilder HasDescription(string description)
        {
            _template.Description = description;
            return this;
        }
        public TemplateBuilder HasDescriptionFile(string descFilePath)
        {
            descFilePath = descFilePath.Replace("\\", "/");
            string desc = System.IO.File.ReadAllText(descFilePath);
            return HasDescription(desc);
        }

        public TemplateBuilder WithSpecialCharacteristic(string name, string descriptionFilePath, int power, CharacteristicType type = CharacteristicType.Feature)
        {
            string desc = System.IO.File.Exists(descriptionFilePath) ? System.IO.File.ReadAllText(descriptionFilePath) : descriptionFilePath;
            Characteristic characteristic = new Characteristic
            {
                CampaignSettingId = setting.Id,
                Description = desc,
                IsDelisted = true,
                IsTemplateOnly = true,
                Name = name,
                SpecifiedPowerAdjustment = power,
                Type = type
            };
            _template.AppliedCharacteristics.Add(new SelectedCharacteristic
            {
                Characteristic = characteristic,
                IsTemplateCharacteristic = true,
            });

            return this;
        }
        public TemplateBuilder WithCharacteristic(string name, string notes = null)
        {
            var characteristic = this.characteristics.First(c => c.Name.ToLower() == name.ToLower());
            SelectedCharacteristic selectedCharacteristic = new SelectedCharacteristic
            {
                IsTemplateCharacteristic = true,
                CharacteristicId = characteristic.Id,
                Notes = notes
            };
            _template.AppliedCharacteristics.Add(selectedCharacteristic);
            return this;
        }

        public TemplateBuilder WithSpell(string spellName, string notes = null)
        {
            var spell = this.spells.First(s => s.Name.ToLower() == spellName.ToLower());
            var selectedSpell = new SelectedSpell
            {
                SpellId = spell.Id,
                Spell = spell,
                Notes = notes,
            };
            _template.SelectedSpells.Add(selectedSpell);
            return this;
        }

        public TemplateBuilder WithSpellCharacteristic(string spellName, string characteristicName)
        {
            var selectedSpell = _template.SelectedSpells.First(ss => ss.Spell.Name.ToLower() == spellName.ToLower());
            var spellCharacteristic = spellCharacteristics.First(sc => sc.Name.ToLower() == characteristicName.ToLower());

            selectedSpell.SelectedCharacteristics.Add(new SelectedSpellCharacteristic
            {
                CharacteristicId = spellCharacteristic.Id,
            });
            return this;
        }

        public TemplateBuilder WithMod(string statName, int mod, string reason = null)
        {
            var stat = setting.Stats.First(s => s.Name.ToLower() == statName.ToLower());
            if (string.IsNullOrWhiteSpace(reason))
            {
                string templateType = _template.IsRace ? "Race" : "Template";
                reason = $"{templateType}: {_template.Name}";
            }
            StatMod statMod = new StatMod(stat.Id, mod, reason);
            _template.Mods.Add(statMod);
            return this;
        }

        public Template Build()
        {
            _template.SelectedSpells.ForEach(ss => ss.Spell = null);
            return _template;
        }
    }
}