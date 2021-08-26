using MediatR;
using PGSysIntegrator.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation
{
    public class GetPlantItemsListForSystemLocationQuery :  IRequest<List<PlantItemsVm>>
   {
     
       public List<string> SystemIdList { get; set; }
       public List<string> LocationCodeList { get; set; }
       public List<PlantItemsVm> PlantItemLocationsList { get; set; }

        // CQRS read operation
        public  GetPlantItemsListForSystemLocationQuery(List<string> systemIdList,  List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList)
        {
            // attempt validate parameters
            foreach (var id in systemIdList.Where(id => string.IsNullOrEmpty(id))) throw new ArgumentNullOrEmptyException(nameof(id));
            SystemIdList = systemIdList;
            
            foreach (var location in locationCodeList.Where(location => string.IsNullOrEmpty(location))) throw new ArgumentNullOrEmptyException(nameof(location));
            LocationCodeList = locationCodeList;
            
            PlantItemLocationsList = plantItemLocationsList ?? throw new ArgumentNullException(nameof(plantItemLocationsList));

        }
    }


  
}
