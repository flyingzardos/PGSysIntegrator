using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PGSysIntegrator.Application.Contracts.Infrastructure;
//using PGSysIntegrator.Application.Features.Reference.Queries.GetCoreLocationsList;
//using PGSysIntegrator.Domain.Entities.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PGSysIntegrator.Application.Exceptions;
using PGSysIntegrator.Application.Models;
using PGSysIntegrator.Domain.Entities.e5;
using PGSysIntegrator.Infrastructure.Helpers;
using PGSysIntegrator.Infrastructure.WebAPIClient;

namespace PGSysIntegrator.API.Controllers
{

    //public class PGSysIntegratorController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PGSysIntegratorController   : ControllerBase   //<T>: ControllerBase where T : ModelBase 
    {
     
        public DataSettings _dataSettings { get; }
        #region Initialization

       
        public IConfiguration _iConfiguration;
       // private readonly IMediator _mediator;

        public PGSysIntegratorController(IOptions<DataSettings> dataSettings,IConfiguration iConfiguration) //, IMediator mediator
        {
            _dataSettings = dataSettings.Value;
            _iConfiguration = iConfiguration;
           // _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #endregion Initialization

        #region ==========    PGSysIntegrator

        #region Gets

        // GET api/<PGSysIntegratorController>/5

        //[HttpGet( Name = "GetCoreLocations")]
        //[ProducesResponseType(typeof(IEnumerable<CoreLocationsVm>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<IEnumerable<CoreLocationsVm>>> GetCoreLocations()
        //{
        //    List<MaximoCoreLocations> coreLocations = new List<MaximoCoreLocations>();


        //    // NOT Implemented


        //    //// ToDo: Call Maximo Adapter and create a list of all locations without parent locations
        //    //// ToDo: Create model to hold that data for presentation

        //    //var query = new GetCoreLocationsListQuery(coreLocations);
        //    //coreLocations = await _mediator.Send(query);



        //    return Ok(coreLocations);;
        //}

        //[HttpGet("{userName}", Name = "SyncLocation")]
        //[ProducesResponseType(typeof(IEnumerable<CoreLocationsVm>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<IEnumerable<CoreLocationsVm>>> SyncLocation()
        //{
        //    List<MaximoCoreLocations> coreLocations = new List<MaximoCoreLocations>();


        //    // NOT Implemented


        //    //// ToDo: Call Maximo Adapter and create a list of all locations without parent locations
        //    //// ToDo: Create model to hold that data for presentation

        //    //var query = new GetCoreLocationsListQuery(coreLocations);
        //    //coreLocations = await _mediator.Send(query);



        //    return Ok(coreLocations);;
        //}
        [HttpGet(Name = "SyncLocation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> SyncSystemLocations([FromQuery] string systemId, [FromQuery] List<string> locationIdList)
        {

            // attempt validate that system id is valid and there are locations
            if (string.IsNullOrEmpty(systemId))
            {
                throw new ArgumentNullOrEmptyException(nameof(systemId));
            }

            if (locationIdList == null)
            {
                throw new ArgumentNullOrEmptyException(nameof(locationIdList));
            }



            foreach (var loc in locationIdList.Where(loc => string.IsNullOrEmpty(loc)))
            {
                throw new ArgumentNullOrEmptyException(nameof(loc));
            }

            // each member is a list for the level of the initial call on the level
            List<MaximoLocationMember> LocationMemberList = new List<MaximoLocationMember>();

            #region Initialize Maximo Uri
            string maximoServiceUri = _iConfiguration.GetValue<string>("Data:maximo_systemLocationBase");

            
           
           // string segmentBeforeSysId = _iConfiguration.GetValue<string>("Data:maximo_systemLocationBeforeSystemId");
           string segmentBeforeSysId = " pg_lochierarchy?oslc.where=locancestor.systemid=";
            // remove '/' which is being applied by Visual Studio
            //===================================================
        //    segmentBeforeSysId = segmentBeforeSysId.Remove(16, 1);
       // maximo_systemLocationAfterSystemId

      // string segmentAfterSysId =  _iConfiguration.GetValue<string>("Data:maximo_systemLocationAfterSystemId");
      string segmentAfterSysId = " and locancestor.ancestor=";
            // locationCode goes here
            string afterLocation = _iConfiguration.GetValue<string>("Data:maximo_systemLocationAfterLocation");
            string uNPw = _iConfiguration.GetValue<string>("Data:maximo_systemLocationUser") + _iConfiguration.GetValue<string>("Data:maximo_systemLocationPwd");

            string afterLocationPredicate = afterLocation; //+ uNPw;
            string apiKey = _iConfiguration.GetValue<string>("Data:maximo_ApiKey");
            #endregion Initialize Maximo Uri

            Maximo_Caller maximoCaller = new Maximo_Caller();

            Uri serviceBaseUri;
            serviceBaseUri = new Uri(maximoServiceUri);//   "http://sqlmx2012.prometheusgroup.com:9080/maxrest/oslc/os/mxapilocsystem"

            int pos = 0;
            foreach (string loc in locationIdList)
            {
                // make list for this parent's children
                MaximoLocationMember mbr = new MaximoLocationMember();
             //  string segment = "ctx=systemID=" + "\"" + "PRIMARY"+  "\"" +  "&oslc.select=location,description, locationsid&lean=1&ignorecollectionref=1";

                //string segment =  " ?ctx=systemID=\"PRIMARY\"&oslc.select=location,description, locationsid&lean=1&ignorecollectionref=1";
                var sysCode = System.Net.WebUtility.UrlEncode("\"" + systemId +  "\"");
                var locCode = System.Net.WebUtility.UrlEncode("\"" + loc +  "\"");

                string segment =  segmentBeforeSysId + sysCode  + segmentAfterSysId + locCode +  afterLocationPredicate;
            
         
                // + '"'    + '"'        + '"'     '"' +
                LocationsForSystem locationItem = new LocationsForSystem();
                locationItem.SystemId = systemId;
                locationItem.LocationsId = loc;
                segment = segment.Remove(0, 1); 
                // call to get basic maximo data for location
                LocationMemberList[pos] = await maximoCaller.GetPlantItemsAsync(locationItem, serviceBaseUri, segment, apiKey);
               
                // don't add to collection if the return was not valid
                if (string.IsNullOrEmpty(LocationMemberList[pos].Location))
                    LocationMemberList.Add(mbr);

                pos++;
            }

            SortingHelper sorter = new SortingHelper();
            LocationMemberList = sorter.BubbleSortByChildLocations(LocationMemberList);
            // ToDo: TEST -> Bubble up algo

            // insert parentId into LocationHierarchy
            e5_Caller e5Caller = new e5_Caller();
            List<e5PlantItemCreateUpdateModel> createUpdateList = new List<e5PlantItemCreateUpdateModel>();

            foreach (MaximoLocationMember member in LocationMemberList)
            {

                e5PlantItemCreateUpdateModel e5model = new e5PlantItemCreateUpdateModel();

                // compare every member to the one selected
                for (int x = 0; x <= LocationMemberList.Count - 1; x++)
                {
                    // if the selected member is a parent to the current member
                    if (LocationMemberList[x].LocationHierarchy.ParentName.Contains(member.Location))
                    {
                        // set current member parents ID
                        member.LocationHierarchy.ParentId = member.LocationsId;
                        // this should handle multiple parents
                        e5model.parentObjectReferences.Add("L" + member.LocationsId);
                    }

                    // ToDo TEST -> e5model.parentObjectReferences
                }


                e5model.objectReference = "L" + member.LocationsId;
                e5model.name = member.Location;
                e5model.description = member.Description;
                e5model.locationCode = member.SiteId;

                createUpdateList.Add(e5model);
                //  Send Create/Update Post to e5
                e5PlantItemCreateUpdateResponseModel response = new e5PlantItemCreateUpdateResponseModel();

                response = await e5Caller.PutPlantItemAsync(e5model);

                // ToDo: Reference track all of this

            }


            return Ok();
        }
        #endregion Gets

        #region Posts

        // POST api/<PGSysIntegratorController>
        //  [HttpPost]
        //public async Task<PGSysIntegratorPlantItemCreateUpdateResponseModel> PostPlantItemCreateUpdate([FromServices]IPGSysIntegratorValues settings, [FromBody] PGSysIntegratorPlantItemCreateUpdateModel item)
        //{



        //    return (PGSysIntegratorPlantItemCreateUpdateResponseModel)Convert.ChangeType(resp, typeof(PGSysIntegratorPlantItemCreateUpdateResponseModel));
        //}

        // POST api/<PGSysIntegratorController>
        // [Route("api/PGSysIntegrator/PostGeneric")]
        // [HttpPost("api/PGSysIntegratorController/PostGeneric")]
        //[HttpPost]
        //public async Task<IConverter<T, T1>> PostGeneric<T1>([FromBody] T t, Type returnType)
        //{
        //    /*************************************************
        //    * This method is intended for ALL POST calls
        //    ***************************************************/
        //    #region Initialize Uri
        //    string serviceUri = "http://PGSysIntegrator-dev.na2.pgdev.io/PGSysIntegratorbackend/api/integration/connect/MAXIMO";
        //    Uri _serviceBaseUri = new Uri(serviceUri);
        //    GenericWebApiClient<PlantItemCreateUpdateModel> apiClient;
        //    #endregion Initialize Uri
        //    // ===================================
        //    // ToDo: Remove - initialization for development only
        //    // ===================================

        //    if (typeof(T) == typeof(PlantItemCreateUpdateModel))
        //    {
        //        string segment = "/plant-item/maintain"; //ToDo: get value from config...
        //      //  IPlantItemCreateUpdateResponse createUpdateResponseModel;
        //        IPlantItemsProcessor thisPlantItemsProcessor = new PlantItemsProcessor();
        //        var item = thisPlantItemsProcessor.InitializePlantCreateUpdateModels();
        //        apiClient = new GenericWebApiClient<PlantItemCreateUpdateModel>(_serviceBaseUri);
        //        var resp = await apiClient.CreateUpdate<T>(item, segment, typeof(T));
        //        var neededModel = (IConverter<T, T1>)Convert.ChangeType(resp, returnType);
        //        return (IConverter<T, T1>)Convert.ChangeType(resp, returnType);
        //    }
        //    // ===============================
        //    return null;
        //    //                                                              return (PlantItemCreateUpdateResponseModel) Convert.ChangeType(resp, typeof(PlantItemCreateUpdateResponseModel));
        //}

        #endregion Posts

        #region Puts

        // PUT api/<PGSysIntegratorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        #endregion Puts

        #region Deletes

        // DELETE api/<PGSysIntegratorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion Deletes

       #endregion ==========     PGSysIntegrator
    }
}
