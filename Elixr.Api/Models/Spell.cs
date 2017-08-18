using System;

namespace Elixr2.Api.Models
{
    public class Spell : ICampaignSettingElement
    {
        public int CampaignSettingId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDelisted { get; set; }

        //A short description about how much Energy is required to produce an effect.
        public string EnergyRequired { get; set; }
        public bool IsConcentration { get; set; }
        public bool DoesDamage { get; set; }
    }
}