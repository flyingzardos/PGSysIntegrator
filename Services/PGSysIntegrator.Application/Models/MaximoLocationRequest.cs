using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PGSysIntegrator.Application.Models
{
    public class MaximoLocationRequest
    {
        [JsonProperty(PropertyName = "systemId")]
        public string SystemId { get; set; }
      
    }
   public class LocationsForSystem
    {
        [JsonProperty(PropertyName = "systemId")]
        public string SystemId { get; set; }

        [JsonProperty(PropertyName = "locationsId")]
        public string LocationsId { get; set; }

    }
}
