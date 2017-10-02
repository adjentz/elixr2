namespace Elixr2.Api.Models
{
    public abstract class GameElementBase : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CampaignSettingId { get; set; }

        public int AuthorId { get; set; }
        public Gamer Author { get; set; }
        
        public abstract int Power { get; }
    }
}