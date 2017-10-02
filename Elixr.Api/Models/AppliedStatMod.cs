namespace Elixr2.Api.Models
{
    public class AppliedStatMod : ModelBase
    {
        public int StatModId { get; set; }
        public StatMod StatMod { get; set; }
        public int AppliedAtLevel { get; set; }
        public long AppliedAtUnixMS {get;set;}
    }
}