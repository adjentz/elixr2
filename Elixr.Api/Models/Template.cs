using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    ///A collection of predefined Mods. Can be used for things like Races, or "Vampiric", or "Skeleton"
    public class Template : ICampaignSettingElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StatMod> Mods { get; set; } = new List<StatMod>();
        public List<SelectedCharacteristic> AppliedCharacteristics { get; set; } = new List<SelectedCharacteristic>();
        public List<SelectedSpell> SelectedSpells { get; set; } = new List<SelectedSpell>();
        public bool IsRace { get; set; }
        public bool IsDelisted { get; set; }
        public int CampaignSettingId { get; set; }
    }
}