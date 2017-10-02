namespace Elixr2.Api.Services
{
    public class UtilityService
    {
        private readonly string secretKey;
        public UtilityService(SettingsService settingsService)
        {
            this.secretKey = settingsService.SecretHashingKey;
        }

        public string HashString(string plainText)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(plainText + secretKey);
                var hashed = sha.ComputeHash(bytes);
                return System.Convert.ToBase64String(hashed);
            }
        }
    }
}