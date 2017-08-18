using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class CampaignSetting
    {
        public static long StandardCampaignSettingCode = 20170415191948;

        public int Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public int CharacteristicPointsEachLevel { get; set; }
        public float StartingWealth { get; set; }
        public int StartingAbilityPoints { get; set; }
        public int MaxAbilityScore { get; set; }
        public int SkillPointsEachLevel { get; set; }
        public int MaxSkillRanksAboveLevel { get; set; }
        public int BaseDefense { get; set; }
        public List<StatMod> InitialMods { get; set; } = new List<StatMod>();
        public List<StatMod> ModsEachLevel { get; set; } = new List<StatMod>();
        public List<Stat> Stats { get; set; } = new List<Stat>();
    }

}