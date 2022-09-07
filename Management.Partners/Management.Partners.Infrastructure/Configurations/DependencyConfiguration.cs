using Management.Partners.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Management.Partners.Infrastructure.Configurations
{
    public static class DependencyConfiguration
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PartnerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
