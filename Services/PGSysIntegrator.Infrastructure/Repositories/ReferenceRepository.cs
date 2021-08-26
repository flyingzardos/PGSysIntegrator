using System;
using PGSysIntegrator.Application.Contracts.Persistence;
//using PGSysIntegrator.Domain.Entities.Reference;
using PGSysIntegrator.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
//using PGSysIntegrator.Application.Features.Reference.Queries.GetCoreLocationsList;
//using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForLocation;
using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation;

namespace PGSysIntegrator.Infrastructure.Repositories
{

    public class ReferenceRepository : RepositoryBase<PlantItemsVm>,  IReferenceRepository
    {

        #region Constructor

        public ReferenceRepository(ReferenceContext dbContext) : base(dbContext)
        {
        }

        #endregion Constructor
        
        #region MaximoCoreLocations

        //Task AddAsync(IEnumerable<MaximoCoreLocations> locationsToCreate);
        //public async Task AddAsync(IEnumerable<MaximoCoreLocations> locationsToCreate)
        //{

        //}

        //Task<IEnumerable<MaximoCoreLocations>> GetCoreLocations(List<CoreLocationsVm> coreLocations);
        //public async Task<IEnumerable<MaximoCoreLocations>> GetCoreLocations(List<CoreLocationsVm> coreLocations) {
        //    var LocationList = await _dbContext.CoreLocations
        //        .ToListAsync();
        //    return LocationList;
        //}

        #endregion MaximoCoreLocations

        #region PlantItemsVm

        //Task AddAsync(IEnumerable<PlantItemsVm> plantItemsToCreate);
        public async Task AddAsync(IEnumerable<PlantItemsVm> plantItemsToCreate)
        {

        }

        //Task<IEnumerable<PlantItemsVm>> GetPlantItemsListForLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList);
        public async Task<IEnumerable<PlantItemsVm>> GetPlantItemsListForSystemLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList) {
            var LocationList = await _dbContext.DbReferenceContext
              .ToListAsync();
            return LocationList;
        }

        //Task<IEnumerable<PlantItemsVm>> CreatePlantItemsForLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList);
        public async Task<IEnumerable<PlantItemsVm>> CreatePlantItemsForSystemLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList) {
            var LocationList = await _dbContext.DbReferenceContext
                .ToListAsync();
            return LocationList;
        }

        //Task<IEnumerable<PlantItemsVm>> DeletePlantItemsForLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList);
        public async Task<IEnumerable<PlantItemsVm>> DeletePlantItemsForSystemLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList) {
            var LocationList = await _dbContext.DbReferenceContext
                .ToListAsync();
            return LocationList;
        }

        //Task<IEnumerable<PlantItemsVm>> UpdatePlantItemsForLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList);
        public async Task<IEnumerable<PlantItemsVm>> UpdatePlantItemsForSystemLocation(List<string> systemIdList, List<string> locationCodeList, List<PlantItemsVm> plantItemLocationsList) {
            var LocationList = await _dbContext.DbReferenceContext
                .ToListAsync();
            return LocationList;
        }
       
        #endregion PlantItemsVm

        //public Task<IReadOnlyList<PlantItemsVm>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IReadOnlyList<PlantItemsVm>> GetAsync(Expression<Func<PlantItemsVm, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IReadOnlyList<PlantItemsVm>> GetAsync(Expression<Func<PlantItemsVm, bool>> predicate = null, Func<IQueryable<PlantItemsVm>, IOrderedQueryable<PlantItemsVm>> orderBy = null, string includeString = null,
        //    bool disableTracking = true)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IReadOnlyList<PlantItemsVm>> GetAsync(Expression<Func<PlantItemsVm, bool>> predicate = null, Func<IQueryable<PlantItemsVm>, IOrderedQueryable<PlantItemsVm>> orderBy = null, List<Expression<Func<PlantItemsVm, object>>> includes = null, bool disableTracking = true)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<PlantItemsVm> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<PlantItemsVm> AddAsync(PlantItemsVm entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(PlantItemsVm entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteAsync(PlantItemsVm entity)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
