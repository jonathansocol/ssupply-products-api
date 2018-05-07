using SSupply.Products.Data.Interfaces;
using SSupply.Products.Data.Models;
using SSupply.Products.Exceptions;
using SSupply.Products.Interfaces;
using SSupply.Products.Models;
using System;
using System.Collections;
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
            var productImage = _productImageRepository.GetById(id);

            if (productDefinition == null || productImage == null)
            {
                throw new ProductNotFoundException(id);
            }

            var product = new Product
            (
                productDefinition.Id, 
                productDefinition.Name,
                productImage.Image, 
                productDefinition.Price
            );

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productDefinitionRepository
                .GetAll()
                .Select(x => new Product(x.Id, x.Name, null, x.Price));
        }

        public IEnumerable<Product> GetAllByName(string name)
        {
            return _productDefinitionRepository
                .GetAllBy(x => x.Name.ToLower().Contains(name.ToLower()))
                .Select(x => new Product(x.Id, x.Name, null, x.Price));
        }

        public async Task<Guid> Insert(Product product)
        {
            var productDefinition = new ProductDefinition
            {
                Name = product.Name,
                Price = product.Price,
                LastUpdated = DateTime.UtcNow
            };

            var newProduct = await _productDefinitionRepository.Insert(productDefinition);

            var productImage = new ProductImage
            {
                ProductDefinitionId = newProduct.Id,
                Image = product.Photo
            };

            await _productImageRepository.Insert(productImage);

            await _productDefinitionRepository.Commit();
            await _productImageRepository.Commit();

            return newProduct.Id;
        }

        public async Task Update(Product product)
        {
            var productDefinition = _productDefinitionRepository.GetById(product.Id);
            var productImage = _productImageRepository.GetById(product.Id);

            if (productDefinition == null || productImage == null)
            {
                throw new ProductNotFoundException(product.Id);
            }

            productDefinition.Name = product.Name;
            productDefinition.Price = product.Price;
            productDefinition.LastUpdated = DateTime.UtcNow;

            productImage.Image = product.Photo;

            await _productDefinitionRepository.Commit();
            await _productImageRepository.Commit();
        }

        public async Task Delete(Guid id)
        {
            var productImage = _productImageRepository.GetById(id);
            var productDefinition = _productDefinitionRepository.GetById(id);

            await _productImageRepository.Delete(productImage);
            await _productDefinitionRepository.Delete(productDefinition);

            await _productDefinitionRepository.Commit();
            await _productImageRepository.Commit();
        }
    }
}
