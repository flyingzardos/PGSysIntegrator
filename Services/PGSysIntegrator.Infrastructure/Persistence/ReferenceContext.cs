using System;
using PGSysIntegrator.Domain.Common;
//using PGSysIntegrator.Domain.Entities.Reference;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using PGSysIntegrator.Application.Features.Reference.Queries.GetPlantItemsListForSystemLocation;

namespace PGSysIntegrator.Infrastructure.Persistence
{
    public class ReferenceContext : DbContext
    {
        public ReferenceContext(DbContextOptions<ReferenceContext> options) : base(options)
        {
        }

     

      //  public DbSet<MaximoCoreLocations> CoreLocations { get; set; }
        public DbSet<PlantItemsVm> DbReferenceContext{ get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<ReferenceEntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
