using System.Linq;
using Elixr2.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Elixr2.Api.Services
{
    public class WeaponsService : ServiceBase
    {
        public WeaponsService(ElixrDbContext dbContext, UserSession userSession)
        : base(dbContext, userSession)
        { }
        public async Task<List<Weapon>> GetWeapons(string name = null)
        {
            var weaponQuery = QueryGameElements<Weapon>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                weaponQuery = weaponQuery.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }

            weaponQuery = weaponQuery.Include(w => w.DefaultCharacteristics).ThenInclude(dc => dc.Characteristic).OrderBy(c => c.Name);
            return await weaponQuery.ToListAsync();
        }
    }
}