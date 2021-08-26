using MediatR;
using PGSysIntegrator.Application.Models;
using System.Collections.Generic;
using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation;

namespace PGSysIntegrator.Application.Features.Reference.Commands.CreatePlantItemsForSystemLocation
{
    public class CreatePlantItemsForSystemLocationCommand : IRequest
    {
        public List<string> SystemIdList { get; set; }
        public List<string> LocationCodeList { get; set; }
        public List<PlantItemsVm> PlantItemsList{ get; set; }
    }
}
