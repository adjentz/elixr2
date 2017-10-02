
using System;

namespace Elixr2.Api.Models
{
    public class Item : EquipmentBase
    {
        // Just generic gear.

        public override int Power => throw new NotImplementedException();
    }
}