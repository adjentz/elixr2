using System.Threading.Tasks;
using Elixr2.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Elixr2.Api.Services
{
    public class GamerService : ServiceBase
    {
        private readonly UtilityService utilityService;
        public GamerService(UtilityService utilityService, ElixrDbContext dbContext, UserSession userSession)
        : base(dbContext, userSession)
        {
            this.utilityService = utilityService;
        }

        public async Task<Gamer> GetGamerWithCode(string code)
        {
            Require(code, "Code is required");

            return await Query<Gamer>().FirstOrDefaultAsync(g => g.Code.ToLower() == code.ToLower());
        }

        public async Task<bool> GamerIdIsTaken(string gamerId)
        {
            Require(gamerId, "Gamer ID is required");

            return await Query<Gamer>().AnyAsync(g => g.Username.ToLower() == gamerId);
        }
        public async Task<Gamer> AddGamer(string gamerId, string password, string email = null, string code = null)
        {
            Assert(gamerId?.Length > 0, "Must have gamer ID");
            Assert(password?.Length >= 6, "Password must have at least 6 characters");
            Assert(password.ToLower() != "correcthorsebatterystaple", "Maybe don't take advice from web comics so literally");

            bool loginExistsInTheWild = await GamerIdIsTaken(gamerId);
            Assert(!loginExistsInTheWild, "A gamer already exists with ID");

            if (!string.IsNullOrWhiteSpace(email))
            {
                bool emailExistsInTheWild = await Query<Gamer>().AnyAsync(g => g.Email.ToLower() == email.ToLower());
                Assert(!emailExistsInTheWild, "A gamer already exists with given email");
            }

            if (!string.IsNullOrWhiteSpace(code))
            {
                bool codeExistsInTheWild = await Query<Gamer>().AnyAsync(g => g.Code.ToLower() == code.ToLower());
                Assert(!codeExistsInTheWild, "A gamer already exists with given code");
            }

            Gamer gamer = new Gamer
            {
                Code = code,
                Email = email,
                Username = gamerId,
                SecurityHash = utilityService.HashString(password),
                SignedUpAtUnixSecond = System.DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            AddModel(gamer);
            await SaveChangesAsync();

            return gamer;
        }

        public async Task<Gamer> GetGamerWithCredentials(string gamerId, string password)
        {
            Require(gamerId, "Gamer ID is required");
            Require(password, "Password is required");

            gamerId = gamerId.ToLower();
            return await Query<Gamer>().FirstOrDefaultAsync(g => (g.Username.ToLower() == gamerId || g.Email.ToLower() == gamerId) && g.SecurityHash == utilityService.HashString(password));
        }
    }
}