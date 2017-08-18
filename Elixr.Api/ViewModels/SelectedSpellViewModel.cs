using System.Collections.Generic;

namespace Elixr2.Api.ViewModels
{
    public class SelectedSpellViewModel
    {
        public int SelectedSpellId { get; set; }
        public SpellViewModel Spell { get; set; }
        public long SelectedAtMS { get; set; }
        public int SelectedAtLevel { get; set; }
        public string Notes { get; set; }
        public List<SelectedSpellCharacteristicViewModel> SelectedCharacteristics { get; set; }

    }
}