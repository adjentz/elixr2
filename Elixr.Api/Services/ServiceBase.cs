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
        protected IQueryable<T> Query<T>() where T : ModelBase
        {
            return dbContext.Set<T>().Where(t => !t.IsDelisted);
        }
        protected IQueryable<T> QueryGameElements<T>() where T : GameElementBase
        {
            return dbContext.Set<T>().Where(t => !t.IsDelisted && t.CampaignSettingId == dbContext.CampaignSettings.First(cs => cs.Code == CampaignSetting.StandardCampaignSettingCode).Id);
        }

        protected void AddModel(ModelBase model)
        {
            dbContext.Add(model);
        }
        public Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
        protected void Require(object obj, string message)
        {
            if (obj == null)
            {
                throw new ServiceException(message, ServiceException.ServiceExceptionCode.Validation);
            }
        }
        protected void Require(string str, string message)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ServiceException(message, ServiceException.ServiceExceptionCode.Validation);
            }
        }
        public void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new ServiceException(message, ServiceException.ServiceExceptionCode.Validation);
            }
        }
    }
}