using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PGSysIntegrator.Application.Contracts.Infrastructure
{
    public interface ITokenParams
    {
       
        [Required]
        string client_id { get; set; }
        [Required]
        string client_secret { get; set; }
        [Required]
        string grant_type { get; set; }
        
    }


  public interface ITokenResponse
    {
        string access_token { get; set; }
        int expires_in { get; set; }
        int refresh_expires_in { get; set; }
        string refresh_token { get; set; }
        string token_type { get; set; }
        [JsonProperty(PropertyName = "not-before-policy")]
        int not_before_policy { get; set; }
        string session_state { get; set; }
        string scope { get; set; }
    }


}
