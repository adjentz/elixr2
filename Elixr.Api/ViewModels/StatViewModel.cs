using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public class StatViewModel
    {
        public int StatId { get; set; }
        public string Name { get; set; }
        public StatGroup Group { get; set; }
        public int MaxValue { get; set; }
        public int PowerRating { get; set; }
        public bool NonModdable { get; set; }
        public int Ratio { get; set; }
        public int ParentStatId { get; set; }
        public int Order { get; set; }
        public string DisplayName { get; set; }
        public string MaxValueFormula { get; set; }
        public string Description { get; set; }
    }
}