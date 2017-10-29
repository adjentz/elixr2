namespace Elixr2.Api.ViewModels
{
    public class SkillViewModel : StatViewModel
    {
        public string OpposedBy { get; set; }
        public string SpeedCost { get; set; }
        public string OnFailure { get; set; }
        public bool HasDefense { get; set; }
    }
}