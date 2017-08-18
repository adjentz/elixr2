namespace Elixr2.Api.ViewModels
{
    public class AppliedStatModViewModel
    {
        public int AppliedStatModId { get; set; }
        public StatModViewModel StatMod { get; set; }
        public int AppliedAtLevel { get; set; }
        public long AppliedAtUnixMS {get;set;}
    }
}