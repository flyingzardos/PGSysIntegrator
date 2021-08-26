using PGSysIntegrator.Application.Contracts.Infrastructure;
using System;

namespace PGSysIntegrator.Infrastructure.Persistence
{
    public class e5Values : Ie5Values
    {
        //  public const string e5BaseURI = "http://e5-dev.na2.pgdev.io/e5backend/api/integration/connect/MAXIMO";
       
        public const string PlantItemsCreateUpdateURISegment = "/maintain";
        public const string PlantItemsDeleteURISegment = "/delete";

        public void info(string str)
        {
            Console.WriteLine(str);
        }

        ////public INestedService NestedService { get; set; }

        ////public RootService(Func<string,INestedService> nestedServiceFactory)
        ////{
        ////    NestedService = nestedServiceFactory("ConnectionStringHere");
        ////}
    }
}
