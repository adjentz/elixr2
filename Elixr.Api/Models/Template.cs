using System.Collections.Generic;
using System.Linq;

namespace Elixr2.Api.Models
{
    ///A collection of predefined Mods. Can be used for things like Races, or "Vampiric", or "Skeleton"
    public class Template : GameElementBase
    {
        public List<StatMod> Mods { get; set; } = new List<StatMod>();
        public List<SelectedCharacteristic> AppliedCharacteristics { get; set; } = new List<SelectedCharacteristic>();
        public List<SelectedSpell> SelectedSpells { get; set; } = new List<SelectedSpell>();
        public bool IsRace { get; set; }
        // False if a creature must be born/created with this template.
        public bool CanBeAcquired { get; set; }

        public override int CombatPower
        {
            get
            {
                int power = SelectedSpells.Sum(ss => ss.Spell.CombatPower);
                power += Mods.Where(sm => sm.Stat.PowerType == PowerType.Combat).Sum(sm => sm.Power);
                power += AppliedCharacteristics.Sum(sc => sc.CombatPower);
                return power;
            }
        }
        public override int PresencePower
        {
            get
            {
                int power = SelectedSpells.Sum(ss => ss.Spell.PresencePower);
                power += Mods.Where(sm => sm.Stat.PowerType == PowerType.Presence).Sum(sm => sm.Power);
                power += AppliedCharacteristics.Sum(sc => sc.PresencePower);
                return power;
            }
        }

        public override int EnvironmentPower
        {
            get
            {
                int power = SelectedSpells.Sum(ss => ss.Spell.EnvironmentPower);
                power += Mods.Where(sm => sm.Stat.PowerType == PowerType.Environment).Sum(sm => sm.Power);
                power += AppliedCharacteristics.Sum(sc => sc.EnvironmentPower);
                return power;
            }
        }
    }
}