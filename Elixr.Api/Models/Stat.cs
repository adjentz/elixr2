namespace Elixr2.Api.Models
{
    public class Stat : ModelBase
    {
        public Stat()
        {
        }
        public Stat(string name, StatGroup group, int powerRating, int maxValue = 0, int ratio = 1)
        {
            this.Name = name;
            this.Group = group;
            this.PowerRating = powerRating;
            this.MaxValue = maxValue;
            this.Ratio = ratio;
            this.DisplayName = name; //until proven otherwise
        }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public StatGroup Group { get; set; }
        public int MaxValue { get; set; }
        public string MaxValueFormula { get; set; }
        public int PowerRating { get; set; }
        public bool NonModdable { get; set; }
        public int Ratio { get; set; }
        //Order within the group
        public int Order { get; set; }

        public string Description {get;set;}

        public int? ParentStatId { get; set; }
        public Stat ParentStat { get; set; }
    }
}