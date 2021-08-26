using System.Net.Http;
using System.Threading.Tasks;
using JsonConvert = Newtonsoft.Json.JsonConvert;
using PGSysIntegrator.Domain.Entities;
using PGSysIntegrator.Domain.Entities.e5;

namespace PGSysIntegrator.Infrastructure.WebAPIClient
{
    public class e5_Caller
    {
        public static string API_BASE = "http://e5-dev.na2.pgdev.io/e5backend/api/integration/connect/MAXIMO/" ;

        private static string apiPath(string method)
        {
            return string.Format("{0}{1}", API_BASE, method);
        }

        public async Task<e5PlantItemCreateUpdateResponseModel> PutPlantItemAsync(e5PlantItemCreateUpdateModel plantItem )
        {
           
           string json = JsonConvert.SerializeObject(plantItem);
           string str = "";
           var response = new HttpResponseMessage();

           e5PlantItemCreateUpdateResponseModel thisResponseModel;

           StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                using (response = await httpClient.PutAsync(apiPath("plant-item/maintain"),httpContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    thisResponseModel = JsonConvert.DeserializeObject<e5PlantItemCreateUpdateResponseModel>(apiResponse);
                }
                str = "" + response.Content + " : " + response.StatusCode;
            }

            return thisResponseModel;
        }

        public async Task<e5PlantItemDeleteResponseModel> DeletePlantItemAsync( e5PlantItemDeleteModel plantItem )
        {
           
            string json = JsonConvert.SerializeObject(plantItem);
            string str = "";
            var response = new HttpResponseMessage();

            e5PlantItemDeleteResponseModel thisResponseModel;

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                using (response = await httpClient.PutAsync(apiPath("plant-item/Delete"),httpContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    thisResponseModel = JsonConvert.DeserializeObject<e5PlantItemDeleteResponseModel>(apiResponse);
                }
                str = "" + response.Content + " : " + response.StatusCode;
            }

            return thisResponseModel;
        }
       
    }
}
