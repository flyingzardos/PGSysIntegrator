using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using PGSysIntegrator.Application.Models;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace PGSysIntegrator.Infrastructure.WebAPIClient
{
    public class Maximo_Caller
    {
        public static string API_BASE = "http://Maximo-dev.na2.pgdev.io/Maximobackend/api/integration/connect/MAXIMO/" ;
        private Uri ServiceBaseUri;

        private static string apiPath(string method)
        {
            return string.Format("{0}{1}", API_BASE, method);
        }

        public async Task<MaximoLocationMember> GetPlantItemsAsync(LocationsForSystem locationItem, Uri baseUri, string segment, string ApiKey)
        {
            string json = JsonConvert.SerializeObject(locationItem);
            string str = "";
            var response = new HttpResponseMessage();
            string apiResponse;
           
            MaximoLocationMember thisResponseModel = new MaximoLocationMember();

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            ServiceBaseUri = baseUri;
             httpClient.DefaultRequestHeaders.Add("MAXAUTH",  ApiKey);
            
            response = await httpClient.GetAsync(ServiceBaseUri.AddSegment(segment));
            apiResponse = await response.Content.ReadAsStringAsync();
            thisResponseModel = JsonConvert.DeserializeObject<MaximoLocationMember>(apiResponse);
            str = "" + response.Content + " : " + response.StatusCode;

            //using (var httpClient = new HttpClient())
            //{
            //    using (response = await httpClient.GetAsync(ServiceBaseUri.AddSegment(segment)))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        thisResponseModel = JsonConvert.DeserializeObject<MaximoLocationMember>(apiResponse);
            //    }
            //    str = "" + response.Content + " : " + response.StatusCode;
            //}

            return thisResponseModel;
        }
    }
   
}