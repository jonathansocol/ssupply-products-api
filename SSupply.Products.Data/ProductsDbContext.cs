using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using SSupply.Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSupply.Products.Data
{
    public class ProductsDbContext : DbContext
    {
        protected ProductsDbContext() { }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }

        public virtual DbSet<ProductDefinition> ProductDefinitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDefinition>().Property(x => x.LastUpdated).IsConcurrencyToken();
        }
    }
}
