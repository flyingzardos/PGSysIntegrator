using PGSysIntegrator.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


//using Microsoft.AspNet.WebApi.Client;

namespace PGSysIntegrator.Infrastructure.WebAPIClient
{

    public class GenericWebApiClient<T> : IDisposable where T : class
    {
        public IConfiguration _iConfiguration;
        
        private HttpClient client = new HttpClient();
        private Uri ServiceBaseUri;

        public GenericWebApiClient(Uri serviceUri)
        {        
            if(serviceUri == null)
            {
                throw new UriFormatException("A valid URI is required.");
            }
            ServiceBaseUri = serviceUri;
        }

        public async Task<IConverter<T, T1>> GetToken<T1>([FromServices]Ie5Values _settings,T t, Type returnType )
        {
            var response = await client.PostAsJsonAsync(ServiceBaseUri, t);

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException("Create failed with " + response.StatusCode.ToString());

            return (IConverter<T, T1>)Convert.ChangeType(response, returnType);

        }

        public async Task< List<T>> GetAll(T t, string segment)
        {

            var response = await client.GetAsync(ServiceBaseUri.AddSegment(segment));
            if(response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<T>>().Result as List<T>;

            }
            else if (response.StatusCode != HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException("Get failed with " + response.StatusCode.ToString());
            }

            return null;
        }

        public async Task<T>  GetById(T t, string segment)
        {
            if (segment == null)
                return default(T);

            var response = await client.GetAsync(ServiceBaseUri.AddSegment(segment));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result as T;
            }
            else if (response.StatusCode != HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException("Get failed with " + response.StatusCode.ToString());
            }

            return null;
        }

        public async Task<T> Edit(T t, string segment)
        {
            var response = await  client.PutAsJsonAsync(ServiceBaseUri.AddSegment(segment), t);

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException("Edit failed with " + response.StatusCode.ToString());

            return (T) Convert.ChangeType(response, typeof(T));
        }

        public async Task<T> Delete(T t, string segment)
        {
            var response =  await  client.DeleteAsync(ServiceBaseUri.AddSegment(segment));

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException("Delete failed with " + response.StatusCode.ToString());

            return (T) Convert.ChangeType(response, typeof(T));
        }

       
        public async Task<IConverter<T, T1>> CreateUpdate<T1>(T t, string segment, Type returnType)
        {
            //HttpContent content;
            //content.Headers.Allow

            var response = await client.PostAsJsonAsync(ServiceBaseUri.AddSegment(segment), t);
          
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException("Create failed with " + response.StatusCode.ToString());

            return (IConverter<T, T1>)Convert.ChangeType(response, returnType);
           
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                client = null;
                ServiceBaseUri = null;
            }
        }

        public void Dispose()
        {
            this.Dispose(false);
            GC.SuppressFinalize(this);
        }

        ~GenericWebApiClient()
        {
            this.Dispose(false);
        }

    }

    static class UriExtensions
    {
        public static Uri AddSegment(this Uri originalUri, string segment)
        {
            UriBuilder ub = new UriBuilder(originalUri);
          //  ub.Path = ub.Path + ((ub.Path.EndsWith("/")) ? "" : "/") + segment;
          ub.Path = ub.Path +  segment;
            return ub.Uri;
        }
    }
}
