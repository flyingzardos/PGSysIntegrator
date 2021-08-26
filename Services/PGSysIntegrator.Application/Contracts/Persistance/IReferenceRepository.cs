//using PGSysIntegrator.Domain.Entities.Reference;
using System.Collections.Generic;
using System.Threading.Tasks;
// using PGSysIntegrator.Application.Features.Reference.Queries.GetCoreLocationsList;
using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation;


namespace PGSysIntegrator.Application.Contracts.Persistence
{
    public interface IReferenceRepository : IAsyncRepository<PlantItemsVm> //, IAsyncRepository<MaximoCoreLocations>
    {
        //Task<IEnumerable<MaximoCoreLocations>> GetCoreLocations(List<CoreLocationsVm> coreLocations);
        //Task AddAsync(IEnumerable<MaximoCoreLocations> locationsToCreate);

        Task<IEnumerable<PlantItemsVm>> GetPlantItemsListForSystemLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList);
        Task<IEnumerable<PlantItemsVm>> CreatePlantItemsForSystemLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList);
        Task<IEnumerable<PlantItemsVm>> DeletePlantItemsForSystemLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList);
        Task<IEnumerable<PlantItemsVm>> UpdatePlantItemsForSystemLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList);

        Task AddAsync(IEnumerable<PlantItemsVm> plantItemsToCreate);
    }
}
