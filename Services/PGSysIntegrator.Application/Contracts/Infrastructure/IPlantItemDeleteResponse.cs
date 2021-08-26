using PGSysIntegrator.Domain.Enumerations;

namespace PGSysIntegrator.Application.Contracts.Infrastructure
{
    public interface IPlantItemDeleteResponse 
    {
        string internalId { get; set; }
        string objectReference { get; set; }
        e5Enumerations.actionCode actionCode { get; set; }
        e5Enumerations.severityCode severityCode { get; set; }
        string text { get; set; }

    }
}
