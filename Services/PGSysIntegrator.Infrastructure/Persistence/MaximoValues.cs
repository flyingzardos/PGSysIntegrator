using PGSysIntegrator.Application.Contracts.Infrastructure;
using System;

namespace PGSysIntegrator.Infrastructure.Persistence
{
    public class MaximoValues : IMaximoValues
    {
          public const string MaximoBaseURI = "https://maximo-na.prometheusgroup.com/maxrest/oslc";
       /*===================================================================================================================
          Examples api formats:
          =======================
          / api formats
          ==============
          Base:   https://maximo.prometheusgroup.com/maxrest/oslc

          oslc/jsonschemas  - [GET] -         /jsonschemas/pg_labor
                            - [GET] -         /jsonschemas/pg_workorder

          oslc/whoami? -      [GET] -         /whoami?lean

          oslc/apiMeta  -     [GET] -         /apiMeta/pg_workorder
                            - [GET] -         /apiMeta/pg_labor

          oslc/script/     -  [GET] -         /script/OSACTION


          Examples os objects:
          ====================
          mxdomain        -   [GET] -          /os/mxdomain
          mxcalendar        - [GET] -          /os/mxcalendar

          pg_savedquery    -  [GET] -          /os/pg_savedquery
          pg_labor    -       [GET] -          /os/pg_labor
          pg_workorder    -   [GET] -          /os/pg_workorder
          pg_workorder        [POST] -         /os/pg_workorder
          pg_workperiods    - [GET] -          /os/pg_workperiods
          pg_craft -          [GET] -          /os/pg_craft
          pg_shift -          [GET] -          /os/pg_shift


        Mario (I'm guessing) - Comments on possible location queries
       ============================================
        So for locations it would be:              /os/mxlocations
        And a specific location: ie BOILER with LocationID=123        /os/mxlocations/123 
        Just not sure exactly how to call it with the location code and not the ID, something like this:       /os/mxlocations?location=BOILER

        ==============================================
        Reference Document: Maximo_REST_API_Guide.pdf
        ==============================================
        19.1. Location hierarchy
        The location hierarchy is always scoped under the LOCSYSTEM object.

        To get a list of systems for the `MXAPILOCSYSTEM`object structure use the following API:     GET /os/mxapilocsystem?oslc.select=systemid,description
        With this API, you go to the top (root) location under that system and select the system that you want to drill down using the href of the system record.
        ===============================================================================================================================*/
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
