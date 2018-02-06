namespace Elixr2.Api.Models
{
    public class SelectedCharacteristic : ModelBase
    {
        public long TakenAtMS { get; set; }
        public int TakenAtLevel { get; set; }
        public int CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }
        // Is this characteristic from a template, such as a Race?
        public bool IsTemplateCharacteristic { get; set; }
        public string Notes { get; set; }
        public int CountUpgraded { get; set; }

        public int CombatPower
        {
            get
            {
                int power = Characteristic.CombatPower;
                power += CountUpgraded * AdditionalModsOnUpgrade?.Where(sm => sm.Stat.PowerType == PowerType.Combat).Sum(sm => sm.Power);
                power += CountUpgraded * Characteristic.UpgradeCombatPower;
                return power;
            }
        }
        public int PresencePower
        {
            get
            {
                int power = Characteristic.PresencePower;
                power += CountUpgraded * AdditionalModsOnUpgrade?.Where(sm => sm.Stat.PowerType == PowerType.Presence).Sum(sm => sm.Power);
                power += CountUpgraded * Characteristic.UpgradePresenceCost;
                return power;
            }
        }
        public int EnvironmentPower
        {
            get
            {
                int power = Characteristic.EnvironmentPower;
                power += CountUpgraded * AdditionalModsOnUpgrade?.Where(sm => sm.Stat.PowerType == PowerType.Environment).Sum(sm => sm.Power);
                power += CountUpgraded * Characteristic.UpgradeEnvironmentCost;
                return power;
            }
        }
    }
}