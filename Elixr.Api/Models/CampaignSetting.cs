using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class CampaignSetting : ModelBase
    {
        public const string StandardCampaignSettingCode = "20170415191948";
        public const int SpeedScalePer5ft = 5;
        public const int DefenseScale = 3;
        public const int EnergyScale = 3;
        public const int AttackBonusScale = 4;
        public const int DamageBonusScale = 4;
        public const int AbilityScoreScale = 5;
        public const int SkillScoreScale = 2;

        public string Code { get; set; }
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

        public int AuthorId { get; set; }
        public Gamer Author { get; set; }
    }

}