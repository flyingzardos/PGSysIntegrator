using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PGSysIntegrator.Application.Contracts.Persistence;
using PGSysIntegrator.Application.Exceptions;
using PGSysIntegrator.Application.Features.Reference.Commands.DeletePlantItemForSystemLocation;
using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PGSysIntegrator.Application.Features.Reference.Commands.DeletePlantItemsForLocation
{


    class DeletePlantItemsForLocationCommandHandler: IRequestHandler<DeletePlantItemsForSystemLocationCommand>
    {
        private readonly IReferenceRepository _referenceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePlantItemsForLocationCommandHandler> _logger;
        public DeletePlantItemsForLocationCommandHandler(IReferenceRepository referenceRepository, IMapper mapper, ILogger<DeletePlantItemsForLocationCommandHandler> logger)
        {
            _referenceRepository = referenceRepository ?? throw new ArgumentNullException(nameof(referenceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Unit> Handle(DeletePlantItemsForSystemLocationCommand request, CancellationToken cancellationToken)
        {
            var plantItemsToDelete = await _referenceRepository.DeletePlantItemsForSystemLocation(request.SystemIdList, request.LocationCodeList, request.PlantItemsList );
            if (plantItemsToDelete == null)
            {
                throw new NotFoundException(nameof(PlantItemsVm), request.PlantItemsList);
            }
            
            _mapper.Map(request, plantItemsToDelete, typeof(DeletePlantItemsForSystemLocationCommand), typeof(PlantItemsVm));

            await _referenceRepository.AddAsync(plantItemsToDelete);

            _logger.LogInformation($"PlantItems for {request.PlantItemsList} were successfully deleted.");

            return Unit.Value;
        }
    }
}
