namespace Elixr2.Api.Models
{
    public class StatMod
    {
        public StatMod() { }
        public StatMod(int statId, int modifier, string reason)
        {
            this.StatId = statId;
            this.Modifier = modifier;
            this.Reason = reason;
        }
        public int Id { get; set; }
        public string Reason { get; set; }
        public int StatId { get; set; }
        public Stat Stat { get; set; }
        public int Modifier { get; set; }
    }
}