using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Elixr2.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Elixr2.Api.Services
{
    public class StatsService : ServiceBase
    {
        public StatsService(ElixrDbContext dbContext, UserSession userSession)
        : base(dbContext, userSession) { }

        public async Task<List<Stat>> GetStatsAsync(StatGroup group)
        {
            var query = Query<Stat>().Where(s => s.Group == group);
            return await query.ToListAsync();
        }

        public async Task<List<Stat>> GetModdableStatsAsync()
        {
            var query = Query<Stat>().Where(s => !s.NonModdable)
                                     .OrderBy(s => s.DisplayName ?? s.Name);
                                     
            return await query.ToListAsync();
        }

        public async Task<List<Skill>> GetSkillsAsync()
        {
            var skills = await Query<Stat>().Where(s => s is Skill).ToListAsync();
            return skills.Select(s => s as Skill).ToList();
        }
    }
}