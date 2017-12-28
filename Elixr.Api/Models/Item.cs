
using System;

namespace Elixr2.Api.Models
{
    public class Item : EquipmentBase
    {
        // Just generic gear.

        public override int CombatPower => 0;
        public override int PresencePower => 0;
        public override int EnvironmentPower => 0;
    }
}