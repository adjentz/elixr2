namespace Elixr2.Api.ViewModels
{
    public class StatModViewModel
    {
        public int StatModId { get; set; }
        public string Reason { get; set; }
        public int StatId {get;set;}
        public StatViewModel Stat { get; set; }
        public int Modifier { get; set; }
        public int AppliedAtLevel { get; set; }
    }
}