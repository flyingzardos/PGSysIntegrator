using MediatR;
using System;
using System.Collections.Generic;


namespace PGSysIntegrator.Application.Features.Reference.Queries.GetCoreLocationsList
{
    public class GetCoreLocationsListQuery : IRequest<List<CoreLocationsVm>>
    {
        public List<CoreLocationsVm> CoreLocationsList { get; set; }

        // CQRS read operation
        public  GetCoreLocationsListQuery(List<CoreLocationsVm> coreLocationsList)
        {
            // verify that List<CoreLocationsVm> was initialized
            CoreLocationsList = coreLocationsList ?? throw new ArgumentNullException(nameof(coreLocationsList));
        }
    }
}
