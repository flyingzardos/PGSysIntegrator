﻿using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation;
using MediatR;
using System.Collections.Generic;

namespace PGSysIntegrator.Application.Features.Reference.Commands.UpdatePlantItemsForSystemLocation
{
    public class UpdatePlantItemsForSystemLocationCommand : IRequest 
    {
        public List<string> SystemIdList { get; set; }
        public List<string> LocationCodeList { get; set; }
        public List<PlantItemsVm> PlantItemsList{ get; set; }
    }
}
