using System.Collections.Generic;
using Newtonsoft.Json;

namespace PGSysIntegrator.Application.Models
{
    public class MaximoLocationResponse
    {
        public List<MaximoLocationMember> MaximoLocationResponseList{ get; set; }
    }

   public class MaximoLocationMember
    {
        //"_rowstamp": "[0 0 0 0 0 10 117 -103]",
        //"locationsid": 196,
        //"location": "BR200",
        //"description": "HVAC System- Main Office",
        //"href": "http://localhost/maxrest/oslc/os/mxapioperloc/_QlIyMDAvQkVERk9SRA--"
        
        [JsonProperty(PropertyName = "_rowstamp")]
        public string RowStamp { get; set; }
      
        [JsonProperty(PropertyName = "locationsid")]
        public string LocationsId { get; set; }
        
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
       
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "siteId")]
        public string SiteId { get; set; }
        
        [JsonProperty(PropertyName = "href")]
        public string HRef { get; set; }
        //"lochierarchy":
        [JsonProperty(PropertyName = "lochierarchy")]
        public Parent LocationHierarchy { get; set; } = new Parent();
    }

   public class Parent
   {
       //"lochierarchy": {
       //"parent": "BR400"
       [JsonProperty(PropertyName = "parent")]
       public string ParentName { get; set; }
       [JsonIgnore]
       public string ParentId { get; set; }
   }

}
