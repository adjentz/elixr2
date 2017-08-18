using System.Collections.Generic;

namespace Elixr2.Api.ViewModels
{
    public class SelectedItemViewModel
    {
        public int SelectedItemId { get; set; }
        public ItemViewModel Item { get; set; }
        public long SelectedAtMS { get; set; }
        public string Notes { get; set; }
    }
}