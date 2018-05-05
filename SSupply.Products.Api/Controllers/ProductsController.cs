using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSupply.Products.Models;
using SSupply.Products.Services;

namespace SSupply.Products.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductsController(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_productService.GetAllProducts());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound(id);
            }

            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.InsertNewProduct(product);

                return Created(_httpContextAccessor.HttpContext.Request.Path.Value, null);
            }

            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]string value)
        {
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound(id);
            }

            return Ok();
        }
    }
}
