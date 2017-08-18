using System.Collections.Generic;
using Elixr2.Api.Models;

namespace Elixr2.Api.ViewModels
{
    public class WealthAdjustmentViewModel
    {
        public int WealthAdjustmentId { get; set; }
        public float Amount { get; set; }
        public string Reason { get; set; }
        public long AdjustedAtMS { get; set; }
    }
}