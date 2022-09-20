using System.Reflection;
using Management.Partners.Application.Commands;
using Management.Partners.Infrastructure.Configurations;
using MediatR;

namespace Management.Partners.WebApi.Configurations
{
    public static class DependencyConfiguration
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(AddPartnerCommand).GetTypeInfo().Assembly);

            services.Configure<DbConnectionConfiguration>(configuration.GetSection(DbConnectionConfiguration.SectionName));

            services.AddOptions<DbConnectionConfiguration>();

            services.RegisterInfrastructureDependencies();
        }
    }
}
