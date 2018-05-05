using System;
using System.Linq;
using System.Threading.Tasks;
using SSupply.Products.Models;

namespace SSupply.Products.Api.Interfaces
{
    public interface IProductService
    {
        Task DeleteProduct(Product product);
        IQueryable<Product> GetAllProducts();
        Product GetProductById(Guid id);
        Task InsertNewProduct(Product product);
    }
}