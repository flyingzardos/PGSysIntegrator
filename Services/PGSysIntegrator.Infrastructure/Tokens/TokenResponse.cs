using PGSysIntegrator.Application.Contracts.Infrastructure;
using Newtonsoft.Json;

namespace PGSysIntegrator.Infrastructure.Tokens
{
    public class TokenResponse : ITokenResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public int refresh_expires_in { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        [JsonProperty(PropertyName = "not-before-policy")]
        public int not_before_policy { get; set; }
        public string session_state { get; set; }
        public string scope { get; set; }
    }

}
