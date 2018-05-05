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

        public IQueryable<Product> GetAllProducts()
        {
            return _productManager.GetAll();
        }

        public async Task InsertNewProduct(Product product)
        {
            await _productManager.Insert(product);
        }

        public async Task DeleteProduct(Product product)
        {
            await _productManager.Delete(product);
        }
    }
}
