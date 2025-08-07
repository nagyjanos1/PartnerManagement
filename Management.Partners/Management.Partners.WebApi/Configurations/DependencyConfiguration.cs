using System.Reflection;
using Management.Partners.Application.Partners.Commands;
using Management.Partners.Infrastructure.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Partners.WebApi.Configurations;

public static class DependencyConfiguration
{
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(AddPartnerCommand).GetTypeInfo().Assembly);

        services.Configure<DbConnectionConfiguration>(configuration.GetSection(DbConnectionConfiguration.SectionName));

        services.AddOptions<DbConnectionConfiguration>();

        services.RegisterInfrastructureDependencies();
    }
      
    public static IHost MigrateDatabase<T>(this IHost webHost) where T : DbContext
    {
        using (var scope = webHost.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var db = services.GetRequiredService<T>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
        return webHost;
    }
}
