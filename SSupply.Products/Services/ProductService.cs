using SSupply.Products.Api.Interfaces;
using SSupply.Products.Interfaces;
using SSupply.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSupply.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductManager _productManager;

        public ProductService(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public Product GetProductById(Guid id)
        {
            return _productManager.GetById(id);
        }

        public IEnumerable<Product> SearchProductsByName(string name)
        {
            return _productManager.GetAllByName(name);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productManager.GetAll();
        }

        public async Task<Guid> InsertNewProduct(Product product)
        {
            return await _productManager.Insert(product);
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productManager.Delete(id);
        }

        public async Task UpdateExistingProduct(Product product)
        {
            await _productManager.Update(product);
        }
    }
}
