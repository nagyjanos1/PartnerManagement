using Management.Partners.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Partners.Infrastructure
{
    internal class PartnerDbContext : DbContext
    {
        public virtual DbSet<Partner> Partners { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public PartnerDbContext(DbContextOptions<PartnerDbContext> options): base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PartnerDbContext).Assembly);
        }
    }
}
