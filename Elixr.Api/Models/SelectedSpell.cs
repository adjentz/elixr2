using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class SelectedSpell
    {
        public int Id { get; set; }
        public int SpellId { get; set; }
        public Spell Spell { get; set; }
        public long SelectedAtMS { get; set; }
        public int SelectedAtLevel { get; set; }
        public string Notes { get; set; }

        public List<SelectedSpellCharacteristic> SelectedCharacteristics { get; set; } = new List<SelectedSpellCharacteristic>();
    }
}