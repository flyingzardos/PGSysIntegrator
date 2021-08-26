using AutoMapper;
using MediatR;
using PGSysIntegrator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation
{
    public class GetPlantItemsListForSystemLocationQueryHandler : IRequestHandler<GetPlantItemsListForSystemLocationQuery, List<PlantItemsVm>>
    {
        private readonly IReferenceRepository _ReferenceRepository;
        private readonly IMapper _mapper;

        public GetPlantItemsListForSystemLocationQueryHandler(IReferenceRepository referenceRepository, IMapper mapper)
        {
            _ReferenceRepository = referenceRepository ?? throw new ArgumentNullException(nameof(referenceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //  // CQRS read operation handler
        public async Task<List<PlantItemsVm>> Handle(GetPlantItemsListForSystemLocationQuery request, CancellationToken cancellationToken)
        {
            // attempt to get orders for given userName, returns an orderList
            var plantItemsList = await _ReferenceRepository.GetPlantItemsListForSystemLocation(request.SystemIdList, request.LocationCodeList, request.PlantItemLocationsList);
            // convert orderList to an OrdersVm View Model
            return _mapper.Map<List<PlantItemsVm>>(plantItemsList);
        }
    }
}
