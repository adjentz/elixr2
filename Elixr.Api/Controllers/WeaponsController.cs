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
    public class WeaponsController
    {
        private readonly WeaponsService weaponsService;
        public WeaponsController(WeaponsService weaponsService)
        {
            this.weaponsService = weaponsService;
        }
        
        [HttpPost("~/weapons/search")]
        public async Task<List<WeaponViewModel>> SearchWeapons([FromBody]SearchWeaponsInput input)
        {
            var weapons = await weaponsService.GetWeapons(input.Name);
            return weapons.Select(w => w.ToViewModel()).ToList();
        }
        public class SearchWeaponsInput
        {
            public string Name { get; set; }
        }
    }
}