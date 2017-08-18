using Elixr2.Api.Models;

namespace Elixr2.Api.Services.Seeding.Builders
{
    class ItemBuilder
    {
        private readonly Item _item;
        public ItemBuilder(CampaignSetting setting)
        { 
            _item = new Item();
            _item.CampaignSettingId = setting.Id;
        }

        public ItemBuilder HasCost(int gold, int silver = 0, int copper = 0)
        {
            _item.GoldCost = gold;
            _item.SilverCost = silver;
            _item.CopperCost = copper;
            return this;
        }

        public ItemBuilder HasName(string name)
        {
            _item.Name = name;
            return this;
        }
        public ItemBuilder HasDescription(string description)
        {
            _item.Description = description;
            return this;
        }
        public ItemBuilder HasDescriptionFile(string descFilePath)
        {
            string desc = System.IO.File.ReadAllText(descFilePath);
            return HasDescription(desc);
        }
        public ItemBuilder HasWeight(float pounds)
        {
            _item.WeightInPounds = pounds;
            return this;
        }
        public Item Build() => _item;
    }
}