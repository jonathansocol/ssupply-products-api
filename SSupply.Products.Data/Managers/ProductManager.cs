using SSupply.Products.Data.Interfaces;
using SSupply.Products.Data.Models;
using SSupply.Products.Exceptions;
using SSupply.Products.Interfaces;
using SSupply.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSupply.Products.Data.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<ProductDefinition> _productDefinitionRepository;

        public ProductManager(IRepository<ProductDefinition> productDefinitionRepository)
        {
            _productDefinitionRepository = productDefinitionRepository;
        }

        public Product GetById(Guid id)
        {
            var productDefinition = _productDefinitionRepository.GetById(id);

            if (productDefinition == null)
            {
                throw new ProductNotFoundException(id);
            }

            var product = new Product
            (
                productDefinition.Id, 
                productDefinition.Name,
                productDefinition.Photo, 
                productDefinition.Price,
                productDefinition.LastUpdated
            );

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _productDefinitionRepository
                .GetAll()
                .Select(x => new Product(x.Id, x.Name, x.Photo, x.Price, x.LastUpdated));
            
            return products;
        }

        public IEnumerable<Product> GetAllByName(string name)
        {
            return _productDefinitionRepository
                .GetAllBy(x => x.Name.ToLower().Contains(name.ToLower()))
                .Select(x => new Product(x.Id, x.Name, x.Photo, x.Price, x.LastUpdated));
        }

        public async Task<Guid> Insert(Product product)
        {
            var productDefinition = new ProductDefinition
            {
                Name = product.Name,
                Photo = product.Photo,
                Price = product.Price,
                LastUpdated = DateTime.UtcNow
            };

            var newProduct = await _productDefinitionRepository.Insert(productDefinition);

            await _productDefinitionRepository.Commit();
            
            return newProduct.Id;
        }

        public async Task Update(Product product)
        {
            var productDefinition = _productDefinitionRepository.GetById(product.Id);
            
            if (productDefinition == null)
            {
                throw new ProductNotFoundException(product.Id);
            }

            productDefinition.Name = product.Name;
            productDefinition.Photo = product.Photo;
            productDefinition.Price = product.Price;
            productDefinition.LastUpdated = DateTime.UtcNow;

            await _productDefinitionRepository.Commit();
        }

        public async Task Delete(Guid id)
        {
            var productDefinition = _productDefinitionRepository.GetById(id);

            await _productDefinitionRepository.Delete(productDefinition);
            await _productDefinitionRepository.Commit();            
        }
    }
}
