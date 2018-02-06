using System.Threading.Tasks;
using System.Collections.Generic;
using Elixr2.Api.ViewModels;
using System.Linq;
using Elixr2.Api.Services;
using Elixr2.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using Elixr2.Api.Models;

namespace Elixr2.Api.Controllers
{
    public class StatsController
    {
        private readonly StatsService statsService;
        public StatsController(StatsService statsService)
        {
            this.statsService = statsService;
        }

        [HttpGet("stats/{group}")]
        public async Task<List<StatViewModel>> GetStatsInGroup(StatGroup group)
        {
            var stats = await statsService.GetStatsAsync(group);
            return stats.Select(s => s.ToViewModel()).ToList();
        }

        [HttpGet("stats/moddable")]
        public async Task<List<StatViewModel>> GetStatsInGroup()
        {
            var stats = await statsService.GetModdableStatsAsync();
            return stats.Select(s => s.ToViewModel()).ToList();
        }

        [HttpGet("skills")]
        public async Task<List<SkillViewModel>> GetSkills()
        {
            var skills = await statsService.GetSkillsAsync();
            return skills.Select(s => s.ToViewModel()).ToList();
        }
    }
}