using PGSysIntegrator.Application.Contracts.Infrastructure;
using System;

namespace PGSysIntegrator.Infrastructure.Persistence
{
    public class PGSysIntegratorValues : IPGSysIntegratorValues
    {
        //  public const string e5BaseURI = "http://";
       
        //public const string PlantItemsCreateUpdateURISegment = "/maintain";
        //public const string PlantItemsDeleteURISegment = "/delete";

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
