using Microsoft.EntityFrameworkCore;
using System.Linq;
using Elixr2.Api.Models;
using System.Threading.Tasks;

namespace Elixr2.Api.Services
{
    public abstract class ServiceBase
    {
        private ElixrDbContext dbContext;
        public ServiceBase(ElixrDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected IQueryable<T> StartQuery<T>() where T : class, ICampaignSettingElement
        {
            return dbContext.Set<T>().Where(t => !t.IsDelisted && t.CampaignSettingId == dbContext.CampaignSettings.First(cs => cs.Code == CampaignSetting.StandardCampaignSettingCode).Id);
        }

        public Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}