namespace Elixr2.Api.Services
{
    public class SettingsService
    {
        public string S3AccessKeyId { get; }
        public string S3SecretKey { get; }
        public string SecretHashingKey { get; }
        public string GameMasterPassword { get; private set; }

        public SettingsService(string s3AccessKeyId, string s3SecretKey, string secretHashingKey, string gameMasterPassword)
        {
            this.S3AccessKeyId = s3AccessKeyId;
            this.S3SecretKey = s3SecretKey;
            this.SecretHashingKey = secretHashingKey;
            this.GameMasterPassword = gameMasterPassword;
        }

        public void FlushGameMasterPassword() => GameMasterPassword = null; // lest it somehow be plucked out of memory...
    }
}