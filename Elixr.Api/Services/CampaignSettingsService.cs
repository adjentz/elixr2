using System.Linq;
using Elixr2.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Elixr2.Api.Services
{
    public class CampaignSettingsService
    {
        private readonly ElixrDbContext dbContext;
        public CampaignSettingsService(ElixrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private IQueryable<CampaignSetting> SettingsQuery
        {
            get
            {
                return dbContext.CampaignSettings.Include(cs => cs.Stats)
                                                 .Include(cs => cs.InitialMods).ThenInclude(im => im.Stat)
                                                 .Include(cs => cs.ModsEachLevel).ThenInclude(mel => mel.Stat);
            }
        }
        public async Task<CampaignSetting> GetCampaignSettingById(int settingId)
        {
            return await SettingsQuery.FirstOrDefaultAsync(cs => cs.Id == settingId);
        }

        public async Task<CampaignSetting> GetCampaignSettingByCode(long code)
        {
            return await SettingsQuery.FirstOrDefaultAsync(cs => cs.Code == code);
        }
    }
}