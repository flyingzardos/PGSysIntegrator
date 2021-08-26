using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PGSysIntegrator.Domain.Common;

namespace PGSysIntegrator.Domain.Entities.e5
{
    public class e5PlantItemCreateUpdateModel : e5EntityBase // derives from abstract class which provides additional properties
    {
      
        [Required]
        public string objectReference { get; set; }	    
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
        public string locationCode { get; set; }        // IMPORTANT: Must use known codes to target e5PlantItemCreateUpdateModel system 1000

        public List<string> parentObjectReferences { get; set; } = new List<string>();



    }
}
