using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PGSysIntegrator.Application.Contracts.Persistence;

namespace PGSysIntegrator.Application.Features.Reference.Queries.GetCoreLocationsList
{
    public class GetPlantItemsListForLocationQueryHandler : IRequestHandler<GetCoreLocationsListQuery, List<CoreLocationsVm>>
    {
        private readonly IReferenceRepository _ReferenceRepository;
        private readonly IMapper _mapper;

        public GetPlantItemsListForLocationQueryHandler(IReferenceRepository referenceRepository, IMapper mapper)
        {
            _ReferenceRepository = referenceRepository ?? throw new ArgumentNullException(nameof(referenceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //  // CQRS read operation handler
        public async Task<List<CoreLocationsVm>> Handle(GetCoreLocationsListQuery request, CancellationToken cancellationToken)
        {
            // attempt to get orders for given userName, returns an orderList
            var coreLocationList = await _ReferenceRepository.GetCoreLocations(request.CoreLocationsList);
            // convert orderList to an OrdersVm View Model
            return _mapper.Map<List<CoreLocationsVm>>(coreLocationList);
        }
    }
}
