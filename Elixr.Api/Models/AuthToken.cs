using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Elixr2.Api.Models
{
    public class AuthToken
    {
        public string GamerName { get; set; }
        public int GamerId { get; set; }
        public long SignedUpAtUnixSecond { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; } = (new Guid()).ToString();
        public long ExpiresAtUnixSecond { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + (int)TimeSpan.FromHours(24).TotalMinutes;
        public bool ShouldSerializeSigningString() => false;
        public string SigningString
        {
            get
            {
                List<string> parts = new List<string>();
                parts.Add($"name={GamerName}");
                parts.Add($"id={GamerId}");
                parts.Add($"email={Email}");
                parts.Add($"salt={Salt}");
                parts.Add($"signedUp={SignedUpAtUnixSecond}");
                parts.Add($"expires={ExpiresAtUnixSecond}");
                return string.Join(";", parts);
            }
        }
        public string Signature { get; set; }

        public static AuthToken FromJson(string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthToken>(jsonString);
        }
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });
        }
    }
}