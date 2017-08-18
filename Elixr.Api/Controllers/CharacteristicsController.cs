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
    public class CharacteristicsController
    {
        private readonly CharacteristicsService characteristicsService;
        public CharacteristicsController(CharacteristicsService characteristicsService)
        {
            this.characteristicsService = characteristicsService;
        }
        
        [HttpPost("~/characteristics/search")]
        public async Task<List<CharacteristicViewModel>> SearchCharacteristics([FromBody]SearchCharacteristicsInput input)
        {
            var characteristics = await characteristicsService.GetCharacteristics(input.Type, input.Name);
            return characteristics.Select(c => c.ToViewModel()).ToList();
        }
        public class SearchCharacteristicsInput
        {
            public string Name { get; set; }
            public CharacteristicType Type { get; set; }
        }
    }
}