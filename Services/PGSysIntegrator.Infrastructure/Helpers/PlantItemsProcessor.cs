using System;
using System.Collections.Generic;
using PGSysIntegrator.Application.Contracts.Infrastructure;
using PGSysIntegrator.Domain.Entities.e5;

using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


namespace PGSysIntegrator.Infrastructure.Helpers
{
    public class PlantItemsProcessor : IPlantItemsProcessor
    {
        #region Constructors

        // Constructor
        public PlantItemsProcessor(IConfiguration configuration)
        {

            // ToDo: get config values from config file...
         //   var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            IPlantItemCreateUpdateResponse createUpdateResponseModel;
           
            IPlantItemDelete deleteModel;
            IPlantItemDeleteResponse deleteResponseModel;

            //   createUpdateModel.
            //if(serviceUri == null)
            //{
            //    throw new UriFormatException("A valid URI is required.");
            //}
            //ServiceBaseUri = serviceUri;
        }

        #endregion Constructors

        public e5PlantItemCreateUpdateModel InitializePlantCreateUpdateModels()
        {

            List<string> parentObjectReferencesList = new List<string>();
            parentObjectReferencesList.Add("");
            e5PlantItemCreateUpdateModel responseModel = new e5PlantItemCreateUpdateModel();

            e5PlantItemCreateUpdateModel createUpdateModelModel = new e5PlantItemCreateUpdateModel();
            createUpdateModelModel.objectReference = "waltsObjectRef2";
            createUpdateModelModel.functionalLocation = "";
            createUpdateModelModel.equipment = "";
            createUpdateModelModel.category = "";
            createUpdateModelModel.plant = "";
            createUpdateModelModel.position = "";
            createUpdateModelModel.building = "";
            createUpdateModelModel.floor = "";
            createUpdateModelModel.room = "";
            createUpdateModelModel.section = "";
            createUpdateModelModel.sortField = "";
            createUpdateModelModel.techId = "";
            createUpdateModelModel.name = "WhatzInAname";
            createUpdateModelModel.description = "test data from walt";
            createUpdateModelModel.locationCode = "1000";
            createUpdateModelModel.parentObjectReferences = parentObjectReferencesList;

            return createUpdateModelModel;

        }

      
    }
}
