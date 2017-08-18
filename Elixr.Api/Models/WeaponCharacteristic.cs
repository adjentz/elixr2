using System;
using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class WeaponCharacteristic : ICampaignSettingElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CampaignSettingId { get; set; }
        public bool IsDelisted { get; set; }

        public int AttackBonusMod {get;set;}
        public int DamageBonusMod {get;set;}
        public string ExtraDamage {get; set; }

        public int? SpecifiedPowerAdjustment { get; set; }
    }
}