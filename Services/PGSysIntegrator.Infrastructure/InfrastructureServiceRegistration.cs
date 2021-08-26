using PGSysIntegrator.Application.Contracts.Infrastructure;
using PGSysIntegrator.Application.Contracts.Persistence;
using PGSysIntegrator.Application.Models;
using PGSysIntegrator.Infrastructure.Mail;
using PGSysIntegrator.Infrastructure.Persistence;
using PGSysIntegrator.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PGSysIntegrator.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddDbContext<ReferenceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IntegratorConnectionString")));
           // services.AddScoped();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));                        
            services.AddScoped<IReferenceRepository, ReferenceRepository>();
            

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.Configure<DataSettings>(c => configuration.GetSection("Data"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
