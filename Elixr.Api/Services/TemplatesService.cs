using System.Linq;
using Elixr2.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Elixr2.Api.Services
{
    public class TemplatesService : ServiceBase
    {
        public TemplatesService(ElixrDbContext dbContext)
        : base(dbContext)
        { }
        public async Task<List<Template>> GetTemplates(bool onlyRaces, string name = null)
        {
            var templatesQuery = StartQuery<Template>()
                                        .Include(t => t.Mods).ThenInclude(sm => sm.Stat)
                                        .Include(t => t.AppliedCharacteristics).ThenInclude(tc => tc.Characteristic).ThenInclude(c => c.Mods).ThenInclude(sm => sm.Stat)
                                        .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                templatesQuery = templatesQuery.Where(t => t.Name.ToLower().Contains(name.ToLower()));
            }
            if (onlyRaces)
            {
                templatesQuery = templatesQuery.Where(t => t.IsRace);
            }

            templatesQuery = templatesQuery.OrderBy(t => t.Name);
            return await templatesQuery.ToListAsync();
        }
    }
}