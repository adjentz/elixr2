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
    public class TemplatesController
    {
        private readonly TemplatesService templatesService;
        public TemplatesController(TemplatesService templatesService)
        {
            this.templatesService = templatesService;
        }
        
        [HttpPost("~/templates/search")]
        public async Task<List<TemplateViewModel>> SearchTemplates([FromBody]SearchTemplatesInput input)
        {
            var templates = await templatesService.GetTemplates(input.OnlyRaces, input.Name);
            return templates.Select(t => t.ToViewModel()).ToList();
        }
        public class SearchTemplatesInput
        {
            public string Name { get; set; }
            public bool OnlyRaces { get; set; }
        }
    }
}