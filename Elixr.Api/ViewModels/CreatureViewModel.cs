using System.Collections.Generic;

namespace Elixr2.Api.ViewModels
{
    public class CreatureViewModel
    {
        public int CreatureId { get; set; }

        public int Level { get; set; }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Skin { get; set; }
        public string Description { get; set; }

        public bool IsCharacter { get; set; }

        public List<AppliedStatModViewModel> Mods { get; set; }
        public List<SelectedTemplateViewModel> SelectedTemplates { get; set; }
        public List<SelectedCharacteristicViewModel> SelectedCharacteristics { get; set; }
        public List<SelectedArmorViewModel> SelectedArmor { get; set; }
        public List<SelectedWeaponViewModel> SelectedWeapons { get; set; }
        public List<SelectedItemViewModel> SelectedItems { get; set; }
        public List<SelectedSpellViewModel> SelectedSpells { get; set; }
        public List<WealthAdjustmentViewModel> WealthAdjustments { get; set; }

        public int CombatPower { get; set; }
        public int EnvironmentPower { get; set; }
        public int PresencePower { get; set; }
        public int GearPower { get; set; }
    }
}