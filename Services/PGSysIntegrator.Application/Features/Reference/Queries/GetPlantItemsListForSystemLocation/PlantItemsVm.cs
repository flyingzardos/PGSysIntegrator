using PGSysIntegrator.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation
{
    // CQRS read class "View Model"
    public class PlantItemsVm : ReferenceEntityBase
    {
       
        public string SystemId  { get; set; }

        public string SiteId { get; set; }

        public string ObjectReferenceId { get; set; }

        public string LocationCode { get; set; }

        public DateTime DeleteDate { get; set; }

        public string ParentObjectReferenceId { get; set; }

    }
}
