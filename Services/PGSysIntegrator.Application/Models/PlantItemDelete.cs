using System.Collections.Generic;
using PGSysIntegrator.Application.Contracts.Infrastructure;

namespace PGSysIntegrator.Application.Models
{
    public class PlantItemDelete : IPlantItemDelete
    {
        public List<string> objectReferences { get; set; } = new List<string>();

    }
}
