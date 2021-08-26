using PGSysIntegrator.Application.Contracts.Infrastructure;
using PGSysIntegrator.Domain.Enumerations;

namespace PGSysIntegrator.Application.Models
{
    public class PlantItemCreateUpdateResponse : IPlantItemCreateUpdateResponse
    {
        public string internalId { get; set; }
        public string objectReference { get; set; }
        public e5Enumerations.actionCode actionCode { get; set; }
        public string action { get; set; }
        public e5Enumerations.severityCode severityCode { get; set; }
        public string severity { get; set; }
        public string text { get; set; }

    }
}
