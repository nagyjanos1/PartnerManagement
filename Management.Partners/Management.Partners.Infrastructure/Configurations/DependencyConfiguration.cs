using AutoMapper.Extensions.ExpressionMapping;
using Management.Partners.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Management.Partners.Infrastructure.Configurations
{
    public static class DependencyConfiguration
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddDbContext<PartnerDbContext>(ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(InfrastuctureMapperConfig));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new InfrastuctureMapperConfig());
                cfg.AddExpressionMapping();
            });
        }
    }
}
