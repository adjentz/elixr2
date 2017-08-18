using System;
using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class Characteristic : ICampaignSettingElement
    {
        public Characteristic()
        {
            Mods = new List<StatMod>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CharacteristicType Type { get; set; }
        public List<StatMod> Mods { get; set; }
        public int CampaignSettingId { get; set; }
        public bool IsDelisted { get; set; }
        // Can only be added to RAces/Templates. A creature without a template is considered itself to be a template for the sake of this property.
        public bool IsTemplateOnly { get; set; }
        //Used to override the calculated power
        public int? SpecifiedPowerAdjustment { get; set; }
    }
}