using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGSysIntegrator.Domain.Common;

namespace PGSysIntegrator.Domain.Entities.Reference
{
    public class PlantItemsTransferred : ReferenceEntityBase // derives from abstract class which provides additional properties
    {
        [Key]
        public int PlantItemsTransferredKey { get; set; }
        public string IntegrationCode  { get; set; } // IS THE MAIN REFERENCE OF LOCATION.
                                                     //                                   In e5 Called LocationCode in API (NOT locationId)
                                                     // PLEASE NOTE The objectReference values used in these calls must match the values that are already in the system 
                                                    //              otherwise duplicates will be added.
                                                    //              ===================================
        public string MaximoId { get; set; }
        public string e5IdId { get; set; }
        public string LocationCode { get; set; }
        public DateTime InitialTransferDate { get; set; }
        public DateTime LastChangedDate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
