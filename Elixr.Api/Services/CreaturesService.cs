using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elixr2.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Elixr2.Api.Services
{
    public class CreaturesService : ServiceBase
    {
        private ElixrDbContext dbContext;
        public CreaturesService(ElixrDbContext dbContext)
        : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        private IQueryable<Creature> CreaturesQuery
        {
            get
            {
                return StartQuery<Creature>().Include(c => c.Mods).ThenInclude(asm => asm.StatMod).ThenInclude(sm => sm.Stat)
                                                                 .Include(c => c.SelectedArmor).ThenInclude(sa => sa.Armor)
                                                                 .Include(c => c.SelectedCharacteristics).ThenInclude(sc => sc.Characteristic).ThenInclude(c => c.Mods).ThenInclude(sm => sm.Stat)
                                                                 .Include(c => c.SelectedItems).ThenInclude(si => si.Item)
                                                                 .Include(c => c.SelectedSpells).ThenInclude(ss => ss.Spell)
                                                                 .Include(c => c.SelectedSpells).ThenInclude(ss => ss.SelectedCharacteristics).ThenInclude(sc => sc.Characteristic)
                                                                 .Include(c => c.SelectedTemplates).ThenInclude(st => st.Template).ThenInclude(t => t.Mods).ThenInclude(sm => sm.Stat)
                                                                 .Include(c => c.SelectedTemplates).ThenInclude(st => st.Template).ThenInclude(t => t.AppliedCharacteristics).ThenInclude(ac => ac.Characteristic).ThenInclude(c => c.Mods).ThenInclude(sm => sm.Stat)
                                                                 .Include(c => c.SelectedTemplates).ThenInclude(st => st.Template).ThenInclude(t => t.SelectedSpells).ThenInclude(ss => ss.Spell)
                                                                 .Include(c => c.SelectedTemplates).ThenInclude(st => st.Template).ThenInclude(t => t.SelectedSpells).ThenInclude(ss => ss.SelectedCharacteristics).ThenInclude(sc => sc.Characteristic)
                                                                 .Include(c => c.SelectedWeapons).ThenInclude(sw => sw.Weapon)
                                                                 .Include(c => c.SelectedWeapons).ThenInclude(sw => sw.AppliedCharacteristics).ThenInclude(ac => ac.Characteristic)
                                                                 .Include(c => c.WealthAdjustments);
            }
        }
        // public async Task<int> GetCreaturePower(int creatureId)
        // {
        //     return await StartQuery<Creature>().Where(c => c.Id == creatureId)
        //                                 .SumAsync(c => 
        //                                     c.SelectedTemplates.Sum(st => st.Template.AppliedCharacteristics.Sum(ac => ac.Characteristic.SpecifiedPowerAdjustment 
        //                                                                                                                ?? ac.Characteristic.Mods.Sum(sm => sm.))))
        // }
        public async Task<Creature> GetCreatureById(int id)
        {
            return await CreaturesQuery.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task CreateCreature(Creature creature)
        {
            dbContext.Creatures.Add(creature);
            await dbContext.SaveChangesAsync();
        }
        public async Task UpdateCreature(Creature creature)
        {
            dbContext.Entry(creature).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Creature>> GetCreatures()
        {
            return await CreaturesQuery.OrderBy(c => c.Name).ToListAsync();
        }
    }
}