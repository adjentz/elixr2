namespace Elixr2.Api.Models
{
    public class WealthAdjustment : ModelBase
    {
        public float Amount { get; set; }
        public string Reason { get; set; }
        public long AdjustedAtMS {get;set;}
    }
}