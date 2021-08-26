using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;

namespace PGSysIntegrator.Application.Models
{


    
        // Maximo Asset Management has many hierarchical objects, such as Locations, Workorders, Assets,
        // Failure codes, etc and there are subtle differences between each of these hierarchies.

        // Any collection resource in this REST API follows the same basic structure.

        //       {
        //          “members”:[
        //         {
        //            “href”:”uri”
        //         }
        //    ...
        //            ]
        //            “responseInfo”:{ METADATA ABOUT THE QUERY
        //            “nextPage”:{ “href”:”next page uri”},
        //            “href”:”request uri”,
        //            “pagenum”:
        //         }
        //}

        //    The totalCount and totalPages are not displayed by default.
        //    You can enable totalCount and totalPages by including the query parameter collectioncount=1 to the request.
        //    If you want to see only the total count of records that match the query and not the records,
        //    you use the request query parameter count=1.
        //      This results in the following JSON response:

        //       {
        //          “totalCount”:<total count of records matching the query>
        //       }

        //  To force the response to add null value attributes, use the query parameter _dropnulls=0.

        //"systemid": "AIR",
        //"_rowstamp": "[0 0 0 0 0 10 120 -42]",
        //"locsystemid": 1,
        //"description": "Compressed Air",
        //"href": "http://localhost/maxrest/oslc/os/mxapilocsystem/_QkVERk9SRC9BSVI-"

        /// <summary>
        /// http://sqlmx2012.prometheusgroup.com:9080/maxrest/oslc/os/mxapilocsystem?oslc.select=systemid,description,locsystemid&lean=1&ignorecollectionref=1&_lid=wilson&_lpwd=wilson
        /// </summary>

        public class MaximoSysRequestResponse
        {
            public List<Member> MemberList { get; set; }
        }

        public class Member
        {
            [JsonProperty(PropertyName = "member")]
            public MemberValues Values { get; set; }
            //responseInfo
            public RespInfo ResponseInfo { get; set; }
            [JsonProperty(PropertyName = "href")]
            public string HRef { get; set; }

        }

        public class MemberValues
        {
            [JsonProperty(PropertyName = "systemid")]
            public string SystemId { get; set; }
            [JsonProperty(PropertyName = "_rowstamp")]
            public string RowStamp { get; set; }
            [JsonProperty(PropertyName = "locsystemid")]
            public string LocalSystemId { get; set; }
            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }
            [JsonProperty(PropertyName = "href")]
            public string HRef { get; set; }

        }

        public class RespInfo
        {
            [JsonProperty(PropertyName = "responseInfo")]
            public string ResponseInfo { get; set; }
        }

}
