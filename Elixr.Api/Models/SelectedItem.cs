using System.Collections.Generic;

namespace Elixr2.Api.Models
{
    public class SelectedItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public long SelectedAtMS { get; set; }
        public string Notes { get; set; }
    }
}