using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGSysIntegrator.Application.Contracts.Infrastructure;
using PGSysIntegrator.Domain.Enumerations;

namespace PGSysIntegrator.Application.Models
{
    public class PlantItemDeleteResponse : IPlantItemDeleteResponse 
    {
        public string internalId { get; set; }
        public string objectReference { get; set; }
        public e5Enumerations.actionCode actionCode { get; set; }
        public e5Enumerations.severityCode severityCode { get; set; }
        public string text { get; set; }

    }
}
