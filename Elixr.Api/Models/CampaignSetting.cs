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
        public const int SkillRankScale = 1;
        public const int DetectionScalePer10Ft = 3
        public const int ResistanceEnergy = 6;
        public static int ImmunityEnergy => ResistanceEnergy * 2;
        public const int ResistancePoison = 6;
        public const int ImmunityPoision = 9;
        public const int ImmunityAnyPoision = 18;        
        public const int ResistancePhysical = 10;
        public const int ResistanceMindAffecting = 10;
        public const int ImmunityMindAffecting => ResistanceMindAffecting * 2;
        public const int LearnSpell = 1;
        public const int SpeakLanguageScale = 1;
        public static int ImmunityPhysical => ResistancePhysical * 2; 
        public static int FlyScalePer10ft => SpeedScalePer5ft *  2 * 6;
        
        public enum RepeatingMultiplier
        {
            OnceEver = 1,
            OncePerDay = 2,
            OncePerEncounter = 3,
            OncePerRound = 4
        }

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