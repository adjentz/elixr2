using System.Linq;
using Elixr2.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Elixr2.Api.Services
{
    public class CharacteristicsService : ServiceBase
    {
        public CharacteristicsService(ElixrDbContext dbContext)
        : base(dbContext)
        { }
        public async Task<List<Characteristic>> GetCharacteristics(CharacteristicType type, string name = null)
        {
            var characteristicsQuery = StartQuery<Characteristic>()
                                        .Include(c => c.Mods).ThenInclude(sm => sm.Stat)
                                        .Where(c => c.Type == type);

            if (!string.IsNullOrWhiteSpace(name))
            {
                characteristicsQuery = characteristicsQuery.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }

            characteristicsQuery = characteristicsQuery.OrderBy(c => c.Name);
            return await characteristicsQuery.ToListAsync();
        }
    }
}