using System;

namespace Elixr2.Api.Models
{
    public enum WeaponUseAbility
    {
        Strength = 0,
        Agility = 1,
        Focus = 2,
        Charm = 3, // Not sure if there's actually a use for this, but in the interest of completeness...
        None = 4
    }
    public class Weapon : IEquipment
    {
        public WeaponUseAbility AttackAbility { get; set; }
        public WeaponUseAbility DamageAbility { get; set; }

        public string Damage { get; set; }
        public int Range { get; set; }
        public bool HasReach { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GoldCost { get; set; }
        public int SilverCost { get; set; }
        public int CopperCost { get; set; }
        public float WeightInPounds { get; set; }
        public int CampaignSettingId { get; set; }
        public bool IsDelisted { get; set; }
        public bool IsTwoHanded { get; set; }
        public bool CanSlash { get; set; }
        public bool CanBludgeon { get; set; }
        public bool CanPierce { get; set; }
        //Similar to touch/ranged-touch attack from 3.x
        public bool IgnoresArmor {get;set;}
    }
}