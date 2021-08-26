using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGSysIntegrator.Application.Contracts.Infrastructure
{
    public interface IPlantItemCreateUpdate
    {
        [Required]
        string objectReference { get; set; }
        string functionalLocation { get; set; }
        string equipment { get; set; }
        string category { get; set; }
        string plant { get; set; }
        string position { get; set; }
        string building { get; set; }
        string floor { get; set; }
        string room { get; set; }
        string section { get; set; }
        string sortField { get; set; }
        string techId { get; set; }
        [Required]
        string name { get; set; }
        string description { get; set; }
        [Required]
        string locationCode { get; set; }        // IMPORTANT: Must use known codes to target e5 system 1000
        List<string> parentObjectReferences { get; set; } 
        

    }
}
