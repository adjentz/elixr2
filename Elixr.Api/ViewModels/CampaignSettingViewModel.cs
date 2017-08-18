using System.Collections.Generic;

namespace Elixr2.Api.ViewModels
{
    public class CampaignSettingViewModel
    {
        public int CampaignSettingId { get; set; }
        public string Name { get; set; }
        public List<StatViewModel> Stats { get; set; }
        public float StartingWealth { get; set; }
        public int StartingAbilityPoints { get; set; }
        public int MaxAbilityScore { get; set; }
        public int SkillPointsEachLevel { get; set; }
        public int BaseDefense { get; set; }
        public int MaxSkillRanksAboveLevel { get; set; }
        public int CharacteristicPointsEachLevel { get; set; }
        public List<StatModViewModel> InitialMods { get; set; }
        public List<StatModViewModel> ModsEachLevel { get; set; }
    }
}