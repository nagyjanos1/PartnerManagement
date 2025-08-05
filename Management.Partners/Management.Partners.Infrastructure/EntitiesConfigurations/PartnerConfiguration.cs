using Management.Partners.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Partners.Infrastructure.EntitiesConfigurations;

internal class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.ToTable("Partner");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.Description).HasColumnName("Description");

        builder.HasMany(r => r.Addresses)
                .WithOne(r => r.Partner)
                .HasForeignKey(r => r.PartnerId);
    }
}
