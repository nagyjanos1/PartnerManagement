using Management.Partners.Infrastructure.Configurations;
using Management.Partners.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Management.Partners.Infrastructure
{
    internal class PartnerDbContext : DbContext
    {
        private readonly string _connectionString;

        public virtual DbSet<Partner> Partners { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public PartnerDbContext(IOptions<DbConnectionConfiguration> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer(_connectionString, builder => 
                { 
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PartnerDbContext).Assembly);
        }
    }
}
