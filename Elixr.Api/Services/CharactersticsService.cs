using System.Linq;
using Elixr2.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Elixr2.Api.ViewModels;

namespace Elixr2.Api.Services
{
    public class CharacteristicsService : ServiceBase
    {
        public CharacteristicsService(ElixrDbContext dbContext, UserSession userSession)
        : base(dbContext, userSession)
        { }

        public async Task<Characteristic> CreateCharacteristic(CharacteristicViewModel viewModel)
        {
            Characteristic newCharacteristic = new Characteristic
            {
                AuthorId = GamerId,
                Description = viewModel.Description,
                Name = viewModel.Name,
                Mods = viewModel.Mods.Select(m => new StatMod
                {
                    StatId = m.StatId,
                    Modifier = m.Modifier,
                    Reason = m.Reason
                }).ToList(),
                
            };
            AddModel(newCharacteristic);
            await SaveChangesAsync();
            return newCharacteristic;
        }

        public async Task<List<Characteristic>> GetCharacteristics(CharacteristicType type, string name = null)
        {
            var characteristicsQuery = QueryGameElements<Characteristic>()
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