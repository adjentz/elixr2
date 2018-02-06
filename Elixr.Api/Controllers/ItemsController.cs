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
    public class ItemsController
    {
        private readonly ItemsService ItemsService;
        public ItemsController(ItemsService itemsService)
        {
            this.ItemsService = itemsService;
        }
        
        [HttpPost("items/search")]
        public async Task<List<ItemViewModel>> SearchItems([FromBody]SearchItemsInput input)
        {
            var Items = await ItemsService.GetItems(input.Name);
            return Items.Select(w => w.ToViewModel()).ToList();
        }
        public class SearchItemsInput
        {
            public string Name { get; set; }
        }
    }
}