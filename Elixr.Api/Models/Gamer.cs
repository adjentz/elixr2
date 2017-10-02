namespace Elixr2.Api.Models
{
    public class Gamer : ModelBase
    {
        public const string TheGameMasterCode = "tgm";
        
        public string GamerId { get; set; }
        public string Code { get; set; }
        public string SecurityHash { get; set; }
        public string Email { get; set; }
        public string ProfileMarkdown { get; set; }
    }
}