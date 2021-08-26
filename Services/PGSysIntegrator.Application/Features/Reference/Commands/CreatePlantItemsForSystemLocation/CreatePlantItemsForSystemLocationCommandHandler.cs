using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PGSysIntegrator.Application.Contracts.Persistence;
using PGSysIntegrator.Application.Exceptions;
using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PGSysIntegrator.Application.Features.Reference.Commands.CreatePlantItemsForSystemLocation
{
    class CreatePlantItemsForSystemLocationCommandHandler: IRequestHandler<CreatePlantItemsForSystemLocationCommand>
    {
        private readonly IReferenceRepository _referenceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePlantItemsForSystemLocationCommandHandler> _logger;
        public CreatePlantItemsForSystemLocationCommandHandler(IReferenceRepository referenceRepository, IMapper mapper, ILogger<CreatePlantItemsForSystemLocationCommandHandler> logger)
        {
            _referenceRepository = referenceRepository ?? throw new ArgumentNullException(nameof(referenceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Unit> Handle(CreatePlantItemsForSystemLocationCommand request, CancellationToken cancellationToken)
        {
            var plantItemsToCreate = await _referenceRepository.CreatePlantItemsForSystemLocation(request.SystemIdList, request.LocationCodeList, request.PlantItemsList  ); 
            if (plantItemsToCreate == null)
            {
                throw new NotFoundException(nameof(PlantItemsVm), request.PlantItemsList);
            }
            
            _mapper.Map(request, plantItemsToCreate, typeof(CreatePlantItemsForSystemLocationCommand), typeof(PlantItemsVm));

            await _referenceRepository.AddAsync(plantItemsToCreate);

            _logger.LogInformation($"PlantItems for {request.PlantItemsList} were successfully created.");

            return Unit.Value;
        }
    }

   
}
