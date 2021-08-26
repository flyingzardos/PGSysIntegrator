using PGSysIntegrator.Domain.Entities.e5;

namespace PGSysIntegrator.Application.Contracts.Infrastructure
{
    public interface IPlantItemsProcessor
    {
      
        public e5PlantItemCreateUpdateModel InitializePlantCreateUpdateModels();

    }
}
