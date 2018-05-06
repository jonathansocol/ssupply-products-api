﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SSupply.Products.Data;
using System;

namespace SSupply.Products.Data.Migrations
{
    [DbContext(typeof(ProductsDbContext))]
    partial class ProductsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SSupply.Products.Data.Models.ProductDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("ProductDefinitions");
                });

            modelBuilder.Entity("SSupply.Products.Data.Models.ProductImage", b =>
                {
                    b.Property<Guid>("ProductDefinitionId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Image")
                        .IsRequired();

                    b.HasKey("ProductDefinitionId");

                    b.ToTable("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
