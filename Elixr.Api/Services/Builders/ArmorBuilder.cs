using Elixr2.Api.Models;

namespace Elixr2.Api.Services.Seeding.Builders
{
    class ArmorBuilder
    {
        private readonly Armor _armor;
        public ArmorBuilder(CampaignSetting setting)
        { 
            _armor = new Armor();
            _armor.CampaignSettingId = setting.Id;
        }

        public ArmorBuilder HasCost(int gold, int silver = 0, int copper = 0)
        {
            _armor.GoldCost = gold;
            _armor.SilverCost = silver;
            _armor.CopperCost = copper;
            return this;
        }

        public ArmorBuilder HasName(string name)
        {
            _armor.Name = name;
            return this;
        }
        public ArmorBuilder HasDescription(string description)
        {
            _armor.Description = description;
            return this;
        }
        public ArmorBuilder HasDescriptionFile(string descFilePath)
        {
            descFilePath = descFilePath.Replace("\\", "/");
            string desc = System.IO.File.ReadAllText(descFilePath);
            return HasDescription(desc);
        }
        public ArmorBuilder HasWeight(float pounds)
        {
            _armor.WeightInPounds = pounds;
            return this;
        }
        public ArmorBuilder HasDefenseBonus(int defense)
        {
            _armor.DefenseBonus = defense;
            return this;
        }

        public ArmorBuilder HasSpeedPenalty(int penalty)
        {
            _armor.SpeedPenalty = penalty;
            return this;
        }

        public ArmorBuilder HasAgilityPenalty(int penalty)
        {
            _armor.AgilityPenalty = penalty;
            return this;
        }
        public Armor Build() => _armor;
    }
}