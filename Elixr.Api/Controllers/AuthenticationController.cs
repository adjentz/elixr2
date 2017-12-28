using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Elixr2.Api.Services;
using Elixr2.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Elixr2.Api.Controllers
{
    public class AuthenticationController
    {
        private readonly GamerService gamerService;
        public AuthenticationController(GamerService gamerService)
        {
            this.gamerService = gamerService;
        }

        private AuthToken GetTokenForGamer(Gamer gamer)
        {
            return new AuthToken
            {
                Email = gamer.Email,
                GamerId = gamer.Id,
                GamerName = gamer.Username,
                SignedUpAtUnixSecond = gamer.SignedUpAtUnixSecond
            };
        }
        private string TokenToBase64(AuthToken token)
        {
            string json = token.ToJson();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
            return System.Convert.ToBase64String(bytes);
        }
        [HttpPost("login")]
        public async Task<AuthenticationOutput> Login([FromBody]AuthenticationInput input)
        {
            var gamer = await gamerService.GetGamerWithCredentials(input.GamerName, input.Password);
            return new AuthenticationOutput
            {
                Base64Token = TokenToBase64(GetTokenForGamer(gamer))
            };
        }

        [HttpPost("signup")]
        public async Task<AuthenticationOutput> Signup([FromBody]SignupInput input)
        {
            var gamer = await gamerService.AddGamer(input.GamerName, input.Password, input.Email);
            return new AuthenticationOutput
            {
                Base64Token = TokenToBase64(GetTokenForGamer(gamer))
            };
        }

        public class AuthenticationInput
        {
            public string GamerName { get; set; }
            public string Password { get; set; }
        }
        public class SignupInput : AuthenticationInput
        {
            public string Email { get; set; }
        }
        public class AuthenticationOutput
        {
            public string Base64Token { get; set; }
        }
    }
}