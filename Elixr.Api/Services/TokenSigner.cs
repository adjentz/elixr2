using System;
using System.Security.Cryptography;
using System.Text;
using Elixr2.Api.Models;

namespace Elixr2.Api.Services
{
    public class TokenSigner
    {
        private readonly UtilityService utilityService;
        public TokenSigner(UtilityService utilityService)
        {
            this.utilityService = utilityService;
        }

        public void SignToken(AuthToken token)
        {
            token.Signature = utilityService.HashString(token.SigningString);
        }

        public (bool valid, string message) ValidateToken(AuthToken token)
        {
            string givenSignature = token.Signature;
            SignToken(token);
            if (givenSignature != token.Signature)
            {
                return (false, "Invalid Session");
            }

            long currentSecond = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (currentSecond < token.ExpiresAtUnixSecond)
            {
                return (false, "Session Expired");
            }

            return (true, null);
        }
    }
}