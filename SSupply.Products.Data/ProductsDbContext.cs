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

        public virtual DbSet<ProductEntity> Products { get; set; }
    }
}
