using System;
using System.Linq;
using System.Threading.Tasks;
using SSupply.Products.Models;

namespace SSupply.Products.Services
{
    public interface IProductService
    {
        Task DeleteProduct(Guid id);
        IQueryable<Product> GetAllProducts();
        Product GetProductById(Guid id);
        Task<Guid> InsertNewProduct(Product product);
        Task UpdateExistingProduct(Product product);
    }
}