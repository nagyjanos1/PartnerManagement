﻿// <auto-generated />
using System;
using Management.Partners.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Management.Partners.Infrastructure.Migrations
{
    [DbContext(typeof(PartnerDbContext))]
    partial class PartnerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Management.Partners.Infrastructure.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("AddressValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AddressValue");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CountryCode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PartnerId");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("Management.Partners.Infrastructure.Entities.Partner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Partner", (string)null);
                });

            modelBuilder.Entity("Management.Partners.Infrastructure.Entities.Address", b =>
                {
                    b.HasOne("Management.Partners.Infrastructure.Entities.Partner", "Partner")
                        .WithMany("Addresses")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("Management.Partners.Infrastructure.Entities.Partner", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
