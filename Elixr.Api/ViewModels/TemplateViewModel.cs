using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public class TemplateViewModel
    {
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StatModViewModel> Mods { get; set; }
        public List<SelectedCharacteristicViewModel> AppliedCharacteristics { get; set; }
        public List<SelectedSpellViewModel> SelectedSpells { get; set; }
        public bool IsRace { get; set; }
    }
}