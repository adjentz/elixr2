namespace Elixr2.Api.Models
{
    public class Skill : Stat
    {
        public Skill()
        {

        }
        public Skill(string name, int power)
        : base(name, StatGroup.Skill, power)
        { }
        public string OpposedBy { get; set; }
        public string SpeedCost { get; set; }
        public string OnFailure { get; set; }
        public bool HasDefense { get; set; }
    }
}