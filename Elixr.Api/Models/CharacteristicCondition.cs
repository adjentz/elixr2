namespace Elixr2.Api.Models
{
    class CharacteristicCondition : ModelBase
    {
        public string Description { get; set; }
        public int CombatPowerReduction { get; set; }
        public int EnvironmentPowerReduction { get; set; }
        public int PresencePowerReduction { get; set; }
    }
}