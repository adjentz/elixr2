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
    public class SpellsController
    {
        private readonly SpellsService SpellsService;
        public SpellsController(SpellsService spellsService)
        {
            this.SpellsService = spellsService;
        }
        
        [HttpPost("~/spells/search")]
        public async Task<List<SpellViewModel>> SearchSpells([FromBody]SearchSpellsInput input)
        {
            var spells = await SpellsService.GetSpells(input.Name);
            return spells.Select(s => s.ToViewModel()).ToList();
        }
        public class SearchSpellsInput
        {
            public string Name { get; set; }
        }
    }
}