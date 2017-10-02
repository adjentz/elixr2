using System.Linq;
using Elixr2.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Elixr2.Api.Services
{
    public class SpellsService : ServiceBase
    {
        public SpellsService(ElixrDbContext dbContext)
        : base(dbContext)
        { }
        public async Task<List<Spell>> GetSpells(string name = null)
        {
            var spellsQuery = QueryGameElements<Spell>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                spellsQuery = spellsQuery.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }

            spellsQuery = spellsQuery.OrderBy(c => c.Name);
            return await spellsQuery.ToListAsync();
        }
    }
}