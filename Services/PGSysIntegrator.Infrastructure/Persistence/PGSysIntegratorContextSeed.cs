using Microsoft.Extensions.Logging;
using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGSysIntegrator.Infrastructure.Persistence
{
    public class PGSysIntegratorContextSeed
    {
        public static async Task SeedAsync(ReferenceContext referenceContext, ILogger<PGSysIntegratorContextSeed> logger)
        {            
            if (!referenceContext.DbReferenceContext.Any())
            {
                referenceContext.DbReferenceContext.AddRange(GetPreconfiguredTransferReferences());
                await referenceContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ReferenceContext).Name);
            }
        }

        private static IEnumerable<PlantItemsVm> GetPreconfiguredTransferReferences()
        {
            return new List<PlantItemsVm>
            {
                // int  Id, string SystemId, string ObjectReferenceId, string LocationCode, DateTime CreateDate, DateTime LastChangeDate,  DateTime DeleteDate
                new PlantItemsVm() {SystemId = "SystemID", ObjectReferenceId= "ObjectReferenceId", LocationCode = "LocationCode"}
            };
        }
    }
}
