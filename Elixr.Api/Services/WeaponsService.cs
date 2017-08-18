using System.Linq;
using Elixr2.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Elixr2.Api.Services
{
    public class WeaponsService : ServiceBase
    {
        public WeaponsService(ElixrDbContext dbContext)
        : base(dbContext)
        { }
        public async Task<List<Weapon>> GetWeapons(string name = null)
        {
            var weaponQuery = StartQuery<Weapon>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                weaponQuery = weaponQuery.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }

            weaponQuery = weaponQuery.OrderBy(c => c.Name);
            return await weaponQuery.ToListAsync();
        }
    }
}