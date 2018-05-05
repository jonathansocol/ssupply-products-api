using SSupply.Products.Data.Interfaces;
using SSupply.Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSupply.Products.Data.Managers
{
    public class ProductManager
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductImage> _productImageRepository;

        public ProductManager(IRepository<Product> productRepository, IRepository<ProductImage> productImageRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
        }

        public Product GetById(Guid id)
        {
            var product = _productRepository.GetById(id);
            //var photo = _productImageRepository.GetById(product.PhotoId);

            return product;
        }

        public IQueryable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public async Task Insert(Product product)
        {
            await _productRepository.Insert(product);
        }

        public async Task Delete(Product product)
        {
            await _productRepository.Delete(product);
        }
    }
}
