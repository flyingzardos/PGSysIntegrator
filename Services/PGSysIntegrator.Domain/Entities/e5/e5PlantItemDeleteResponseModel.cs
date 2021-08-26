using PGSysIntegrator.Domain.Enumerations;

namespace PGSysIntegrator.Domain.Entities.e5
{
    public class e5PlantItemDeleteResponseModel
    {
        public string internalId { get; set; }
        public string objectReference { get; set; }
        public e5Enumerations.actionCode actionCode { get; set; }
        public e5Enumerations.severityCode severityCode { get; set; }
        public string text { get; set; }
    }
}
