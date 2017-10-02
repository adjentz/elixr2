using System.Linq;
using Elixr2.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Elixr2.Api.Services
{
    public class ArmorService : ServiceBase
    {
        public ArmorService(ElixrDbContext dbContext)
        : base(dbContext)
        { }
        public async Task<List<Armor>> GetArmor(string name = null)
        {
            var armorQuery = QueryGameElements<Armor>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                armorQuery = armorQuery.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }

            armorQuery = armorQuery.OrderBy(c => c.DefenseBonus).ThenBy(c => c.Name);
            return await armorQuery.ToListAsync();
        }
    }
}