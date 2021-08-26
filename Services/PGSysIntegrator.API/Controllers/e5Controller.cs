using PGSysIntegrator.Application.Contracts.Infrastructure;
using PGSysIntegrator.Domain.Entities;
using PGSysIntegrator.Infrastructure.Helpers;
using PGSysIntegrator.Infrastructure.Tokens;
using PGSysIntegrator.Infrastructure.WebAPIClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
// using PGSysIntegrator.Application.Features.Reference.Queries.GetCoreLocationsList;
using PGSysIntegrator.Domain.Entities.e5;
//using PGSysIntegrator.Domain.Entities.Reference;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PGSysIntegrator.API.Controllers 
{
    //<T> : ApiController where T : ModelBase 

    [ApiController]
    [Route("api/v1/[controller]")]
    public class e5Controller   : ControllerBase   //<T>: ControllerBase where T : ModelBase 
    {
     

      //  #region Initialization

       
      //  public IConfiguration _iConfiguration;
      //  private readonly IMediator _mediator;
      //  public  Ie5Values _log;

      //  public e5Controller(Ie5Values log, IConfiguration iConfiguration,IMediator mediator)
      //  {
      //      _iConfiguration = iConfiguration;
      //      _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
      //      _log = log;
      //  }

      //#endregion Initialization

       #region ==========    e5

      //  #region Gets

      // // GET api/<e5Controller>/5
       
      //  //[HttpGet("{userName}", Name = "GetCoreLocations")]
      //  //[ProducesResponseType(typeof(IEnumerable<MaximoCoreLocations>), (int)HttpStatusCode.OK)]
      //  //public async Task<ActionResult<IEnumerable<MaximoCoreLocations>>> GetCoreLocations()
      //  //{
      //  //    //List<MaximoCoreLocations> coreLocations = new List<MaximoCoreLocations>();


      //  //    //var query = new GetCoreLocationsListQuery();
      //  //    //var orders = await _mediator.Send(query);
      //  //    // ToDo: Call Maximo Adapter and create a list of all locations without parent locations
      //  //    // ToDo: Create model to hold that data for presentation


      //  //    return Ok(coreLocations);;
      //  //}

      //  #endregion Gets

       #region Posts

      //  // POST api/<e5Controller>
      //  [HttpPost]
      //  public async Task<e5PlantItemCreateUpdateResponseModel> PostPlantItemCreateUpdate([FromServices]Ie5Values settings, [FromBody] e5PlantItemCreateUpdateModel item)
      //  {

      //      // Handle Token
      //      // ============
      //      string tokenUri = _iConfiguration.GetValue<string>("Data:e5-Token-URI");
      //      Uri serviceTokenUri = new Uri(tokenUri);
      //      var apiTokenClient = new GenericWebApiClient<ITokenParams>(serviceTokenUri);

      //      var tokenModel = new TokenModel();
      //      tokenModel = tokenModel.GetAndSetToken(_iConfiguration.GetValue<string>("Data:e5-Token-client_id"),
      //          _iConfiguration.GetValue<string>("Data:e5-Token-client_secret"),
      //          _iConfiguration.GetValue<string>("Data:e5-Token-grant_type"));

      //      var resp1 = await apiTokenClient.GetToken<ITokenParams>(settings, tokenModel.tokenParams, typeof(ITokenResponse));
      //      tokenModel.tokenResponse = (ITokenResponse)Convert.ChangeType(resp1, typeof(ITokenResponse));

      //      /*************************************************
      //       * This method is ONLY good for 1 type of POST call
      //       ***************************************************/
      //      #region Initialize Uri
      //      string serviceUri = _iConfiguration.GetValue<string>("Data:e5-BaseURI");
      //      Uri serviceBaseUri = new Uri(serviceUri);
      //      string segment = _iConfiguration.GetValue<string>("Data:e5-Segment-PlantItem");
      //      segment = segment + _iConfiguration.GetValue<string>("Data:e5-Segment-PlantItem-CreateUpdate");

      //      #endregion Initialize Uri

       

      //      var apiClient = new GenericWebApiClient<e5PlantItemCreateUpdateModel>(serviceBaseUri);

           
      //      // options.headers['Authorization'] = 'Bearer ' + jwtToken;
      //      // ===================================
      //      // ToDo: Remove - initialization for development only
      //      // ===================================
      //      IPlantItemsProcessor thisPlantItemsProcessor = new PlantItemsProcessor();
      //      item = thisPlantItemsProcessor.InitializePlantCreateUpdateModels();
      //      // ===============================

      //      var resp = await apiClient.CreateUpdate<e5PlantItemCreateUpdateResponseModel>(item, segment, typeof(e5PlantItemCreateUpdateResponseModel));

      //      return (e5PlantItemCreateUpdateResponseModel)Convert.ChangeType(resp, typeof(e5PlantItemCreateUpdateResponseModel));
      //  }

        // POST api/<e5Controller>
       // [Route("api/e5/PostGeneric")]
       // [HttpPost("api/e5Controller/PostGeneric")]
        //[HttpPost]
        //public async Task<IConverter<T, T1>> PostGeneric<T1>([FromBody] T t, Type returnType)
        //{
        //    /*************************************************
        //    * This method is intended for ALL POST calls
        //    ***************************************************/
        //    #region Initialize Uri
        //    string serviceUri = "http://e5-dev.na2.pgdev.io/e5backend/api/integration/connect/MAXIMO";
        //    Uri _serviceBaseUri = new Uri(serviceUri);
        //    GenericWebApiClient<PlantItemCreateUpdate> apiClient;
        //    #endregion Initialize Uri
        //    // ===================================
        //    // ToDo: Remove - initialization for development only
        //    // ===================================

        //    if (typeof(T) == typeof(PlantItemCreateUpdate))
        //    {
        //        string segment = "/plant-item/maintain"; //ToDo: get value from config...
        //      //  IPlantItemCreateUpdateResponse createUpdateResponseModel;
        //        IPlantItemsProcessor thisPlantItemsProcessor = new PlantItemsProcessor();
        //        var item = thisPlantItemsProcessor.InitializePlantCreateUpdateModels();
        //        apiClient = new GenericWebApiClient<PlantItemCreateUpdate>(_serviceBaseUri);
        //        var resp = await apiClient.CreateUpdate<T>(item, segment, typeof(T));
        //        var neededModel = (IConverter<T, T1>)Convert.ChangeType(resp, returnType);
        //        return (IConverter<T, T1>)Convert.ChangeType(resp, returnType);
        //    }
        //    // ===============================
        //    return null;
        //    //                                                              return (PlantItemCreateUpdateResponse) Convert.ChangeType(resp, typeof(PlantItemCreateUpdateResponse));
        //}

        #endregion Posts

        #region Puts

        //// PUT api/<e5Controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        #endregion Puts

        #region Deletes

        //// DELETE api/<e5Controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        #endregion Deletes

       #endregion ==========     e5
    }
}
