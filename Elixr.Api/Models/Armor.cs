
using System;

namespace Elixr2.Api.Models
{
    public class Armor : EquipmentBase
    {
        public int DefenseBonus { get; set; }

        public int SpeedPenalty { get; set; }
        public int AgilityPenalty { get; set; }

        public override int CombatPower
        {
            get
            {
                int power = CampaignSetting.DefenseScale 
                - (int)Math.Ceiling(SpeedPenalty * 1.0 * CampaignSetting.SpeedScalePer5ft / 5)
                - (AgilityPenalty * CampaignSetting.AbilityScoreScale);

                return Math.Max(power, 0);
            }
        }
        public override int PresencePower => 0;
        public override int EnvironmentPower => 0;
    }
}