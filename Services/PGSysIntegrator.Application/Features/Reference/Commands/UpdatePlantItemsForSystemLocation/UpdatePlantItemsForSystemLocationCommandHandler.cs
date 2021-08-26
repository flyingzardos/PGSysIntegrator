using AutoMapper;
using PGSysIntegrator.Application.Contracts.Persistence;
using PGSysIntegrator.Application.Exceptions;
using PGSysIntegrator.Application.Features.Reference.Commands.CreatePlantItemsForSystemLocation;
using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PGSysIntegrator.Application.Features.Reference.Commands.UpdatePlantItemsForSystemLocation
{
    public class UpdatePlantItemsForSystemLocationCommandHandler : IRequestHandler<UpdatePlantItemsForSystemLocationCommand>
    {
        private readonly IReferenceRepository _referenceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePlantItemsForSystemLocationCommandHandler> _logger;

        public UpdatePlantItemsForSystemLocationCommandHandler(IReferenceRepository referenceRepository, IMapper mapper, ILogger<UpdatePlantItemsForSystemLocationCommandHandler> logger)
        {
            _referenceRepository = referenceRepository ?? throw new ArgumentNullException(nameof(referenceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdatePlantItemsForSystemLocationCommand request, CancellationToken cancellationToken)
        {
            var plantItemsToUpdate = await _referenceRepository.UpdatePlantItemsForSystemLocation(request.SystemIdList, request.LocationCodeList, request.PlantItemsList ); 
            if (plantItemsToUpdate == null)
            {
                throw new NotFoundException(nameof(PlantItemsVm), request.PlantItemsList);
            }
            
            _mapper.Map(request, plantItemsToUpdate, typeof(CreatePlantItemsForSystemLocationCommand), typeof(PlantItemsVm));

            await _referenceRepository.AddAsync(plantItemsToUpdate);

            _logger.LogInformation($"PlantItems for {request.PlantItemsList} were successfully created.");

            return Unit.Value;
        }
    }
}
