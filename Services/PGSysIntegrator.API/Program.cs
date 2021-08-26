using PGSysIntegrator.API.Extensions;
using PGSysIntegrator.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace PGSysIntegrator.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args)
            //    .Build()
            //    .MigrateDatabase<ReferenceContext>((context, services) =>
            //    {
            //        var logger = services.GetService<ILogger<PGSysIntegratorContextSeed>>();
            //        PGSysIntegratorContextSeed
            //            .SeedAsync(context, logger)
            //            .Wait();
            //    })
            //    .Run();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
