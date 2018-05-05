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

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.LastUpdated).IsConcurrencyToken();
        }
    }
}
