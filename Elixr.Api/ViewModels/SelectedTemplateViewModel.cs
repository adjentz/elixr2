using System.Collections.Generic;

namespace Elixr2.Api.ViewModels
{
    public class SelectedTemplateViewModel
    {
        public int SelectedTemplateId { get; set; }
        public TemplateViewModel Template { get; set; }
        public long SelectedAtMS { get; set; }
        public string Notes { get; set; }
    }
}