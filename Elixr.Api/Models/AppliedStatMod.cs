namespace Elixr2.Api.Models
{
    public class AppliedStatMod
    {
        public int Id { get; set; }
        public int StatModId { get; set; }
        public StatMod StatMod { get; set; }
        public int AppliedAtLevel { get; set; }
        public long AppliedAtUnixMS {get;set;}
    }
}