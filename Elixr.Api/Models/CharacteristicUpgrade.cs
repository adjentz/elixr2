namespace Elixr2.Api.Models
{
    class CharacteristicUpgrade : ModelBase
    {
        public string Description { get; set; }
        public int CombatPowerIncrease { get; set; }
        public int EnvironmentPowerIncrease { get; set; }
        public int PresencePowerIncrease { get; set; }
        public List<StatMod> AdditionalModsOnUpgrade { get; set; }
        public int MaxUpgradesPerLevel {get;set;} = 1;
    }
}