using Elixr2.Api.Models;
using Elixr2.Api.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using Elixr2.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Elixr2.Api.Extensions;

namespace Elixr2.Api.Controllers
{
    public class ArmorController
    {
        private readonly ArmorService armorService;
        public ArmorController(ArmorService armorService)
        {
            this.armorService = armorService;
        }
        
        [HttpPost("~/armor/search")]
        public async Task<List<ArmorViewModel>> SearchArmor([FromBody]SearchArmorInput input)
        {
            var armor = await armorService.GetArmor(input.Name);
            return armor.Select(a => a.ToViewModel()).ToList();
        }
        public class SearchArmorInput
        {
            public string Name { get; set; }
        }
    }
}