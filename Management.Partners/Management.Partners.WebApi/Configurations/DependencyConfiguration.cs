using Management.Partners.Infrastructure.Configurations;

namespace Management.Partners.WebApi.Configurations
{
    public static class DependencyConfiguration
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbConnectionConfiguration>(configuration.GetSection(DbConnectionConfiguration.SectionName));

            services.AddOptions<DbConnectionConfiguration>();

            services.RegisterInfrastructureDependencies();
        }
    }
}
