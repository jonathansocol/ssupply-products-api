using SSupply.Products.Data.Interfaces;
using SSupply.Products.Data.Models;
using SSupply.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSupply.Products.Data.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<ProductDefinition> _productDefinitionRepository;
        private readonly IRepository<ProductImage> _productImageRepository;

        public ProductManager(IRepository<ProductDefinition> productDefinitionRepository, IRepository<ProductImage> productImageRepository)
        {
            _productDefinitionRepository = productDefinitionRepository;
            _productImageRepository = productImageRepository;
        }

        public Product GetById(Guid id)
        {
            var productDefinition = _productDefinitionRepository.GetById(id);
            var productPhoto = _productImageRepository.GetById(id);

            var product = new Product
            (
                productDefinition.Id, 
                productDefinition.Name, 
                productPhoto.Image, 
                productDefinition.Price
            );

            return product;
        }

        public IQueryable<Product> GetAll()
        {
            return _productDefinitionRepository.GetAll().Select(x => new Product(x.Id, x.Name, null, x.Price));
        }

        public async Task Insert(Product product)
        {
            var productDefinition = new ProductDefinition
            {
                Name = product.Name,
                Price = product.Price,
                LastUpdated = DateTime.UtcNow
            };

            var productImage = new ProductImage
            {
                ProductId = product.Id,
                Image = product.Photo
            };

            await _productDefinitionRepository.Insert(productDefinition);
            await _productImageRepository.Insert(productImage);
        }

        public async Task Delete(Product product)
        {
            var productImage = _productImageRepository.GetById(product.Id);
            var productDefinition = _productDefinitionRepository.GetById(product.Id);

            await _productImageRepository.Delete(productImage);
            await _productDefinitionRepository.Delete(productDefinition);
        }
    }
}
