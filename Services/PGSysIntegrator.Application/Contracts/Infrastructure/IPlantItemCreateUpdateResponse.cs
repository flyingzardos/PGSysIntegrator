using PGSysIntegrator.Domain.Enumerations;

namespace PGSysIntegrator.Application.Contracts.Infrastructure
{
    public interface IPlantItemCreateUpdateResponse
    {
        string internalId { get; set; }
        string objectReference { get; set; }
        e5Enumerations.actionCode actionCode { get; set; }
        string action { get; set; }
        e5Enumerations.severityCode severityCode { get; set; }
        string severity { get; set; }
        string text { get; set; }

    }
}
