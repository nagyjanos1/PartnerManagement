using Management.Partners.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Partners.Infrastructure.EntitiesConfigurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
            builder.Property(r => r.Name).HasColumnName("Name").IsRequired();
            builder.Property(r => r.CountryCode).HasColumnName("CountryCode").IsRequired();
            builder.Property(r => r.ZipCode).HasColumnName("ZipCode").IsRequired();
            builder.Property(r => r.City).HasColumnName("City").IsRequired();
            builder.Property(r => r.AddressValue).HasColumnName("AddressValue").IsRequired();

            builder.Property(r => r.PartnerId).HasColumnName("PartnerId").IsRequired();

            builder.HasOne(r => r.Partner)
                    .WithMany(r => r.Addresses)
                    .HasForeignKey(r => r.PartnerId);
        }
    }
}
