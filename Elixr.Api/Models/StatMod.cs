namespace Elixr2.Api.Models
{
    public class StatMod : ModelBase
    {
        public StatMod() { }
        public StatMod(int statId, int modifier, string reason)
        {
            this.StatId = statId;
            this.Modifier = modifier;
            this.Reason = reason;
        }
        public string Reason { get; set; }
        public int StatId { get; set; }
        public Stat Stat { get; set; }
        public int Modifier { get; set; }
    }
}