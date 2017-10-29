using System.Collections.Generic;

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
        public bool CanBeAcquired {get;set;}

        public override int Power => throw new System.NotImplementedException();
    }
}