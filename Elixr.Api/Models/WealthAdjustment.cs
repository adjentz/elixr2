namespace Elixr2.Api.Models
{
    public class WealthAdjustment
    {
        public int Id {get;set;}
        public float Amount { get; set; }
        public string Reason { get; set; }
        public long AdjustedAtMS {get;set;}
    }
}