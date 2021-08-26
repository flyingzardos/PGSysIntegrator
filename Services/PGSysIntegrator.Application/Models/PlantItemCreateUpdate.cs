using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PGSysIntegrator.Application.Contracts.Infrastructure;
using PGSysIntegrator.Domain.Enumerations;


namespace PGSysIntegrator.Application.Models
{
   
    public class PlantItemCreateUpdate : IPlantItemCreateUpdate
    {
        [Required]
        public string objectReference { get; set; }	     // locationCode_assetCode
        public string functionalLocation { get; set; }
        public string equipment { get; set; }
        public string category { get; set; }
        public string plant { get; set; }
        public string position { get; set; }
        public string building { get; set; }
        public string floor { get; set; }
        public string room { get; set; }
        public string section { get; set; }
        public string sortField { get; set; }
        public string techId { get; set; }
        [Required]
        public string name { get; set; }	           
        public string description { get; set; }
        [Required]
        public string locationCode { get; set; }        // IMPORTANT: Must use known codes to target e5 system 1000

        public List<string> parentObjectReferences { get; set; } = new List<string>();

    }

  
    

    

  

}
