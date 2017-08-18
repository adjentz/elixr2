namespace Elixr2.Api.Models
{
    public interface ICampaignSettingElement
    {
        int CampaignSettingId { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool IsDelisted { get; set; }
    }
}