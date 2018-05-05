using Microsoft.EntityFrameworkCore;
using SSupply.Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSupply.Products.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(DbContext dbContext) : base(dbContext) { }
    }
}
