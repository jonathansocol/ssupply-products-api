using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SSupply.Products.Models;

namespace SSupply.Products.Services
{
    public interface IProductService
    {
        Task DeleteProduct(Guid id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> SearchProductsByName(string name);
        Product GetProductById(Guid id);
        Task<Guid> InsertNewProduct(Product product);
        Task UpdateExistingProduct(Product product);
    }
}