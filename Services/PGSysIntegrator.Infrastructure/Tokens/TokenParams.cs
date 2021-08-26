using PGSysIntegrator.Application.Contracts.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace PGSysIntegrator.Infrastructure.Tokens
{
    public class TokenParams : ITokenParams
    {
        [Required]
       public string client_id { get; set; }
        [Required]
        public  string client_secret { get; set; }
        [Required]
        public  string grant_type { get; set; }
    }

}
