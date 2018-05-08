using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SSupply.Products.Interfaces;
using SSupply.Products.Models;
using SSupply.Products.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSupply.Products.Tests.Services
{
    [TestClass]
    [TestCategory("Unit")]
    public class ProductServiceTests
    {
        private Mock<IProductManager> _productManagerMock;
        private ProductService _productService;

        [TestInitialize]
        public void Initialize()
        {
            _productManagerMock = new Mock<IProductManager>();
            _productService = new ProductService(_productManagerMock.Object);
        }

        [TestMethod]
        public void GetProductById_ValidIdIsUsed_ProductIsReturned()
        {
            //Arrange
            var id = Guid.NewGuid();
            _productManagerMock.Setup(x => x.GetById(id)).Returns(new Product());

            //Act
            var product = _productService.GetProductById(id);

            //Assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void GetAllProducts_ProductListIsReturned()
        {
            //Arrange
            _productManagerMock.Setup(x => x.GetAll()).Returns(new List<Product>());

            //Act
            var product = _productService.GetAllProducts();

            //Assert
            Assert.IsNotNull(product);
        }
    }
}
