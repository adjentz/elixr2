using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class SelectedTemplate
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public long SelectedAtMS { get; set; }
        public string Notes { get; set; }
    }
}