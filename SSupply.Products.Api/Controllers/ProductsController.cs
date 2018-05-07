using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSupply.Products.Api.Models;
using SSupply.Products.Exceptions;
using SSupply.Products.Models;
using SSupply.Products.Services;

namespace SSupply.Products.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductService productService, 
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper
            )
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
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

        [HttpGet("search/{term}")]
        public ActionResult Get(string term)
        {
            var product = _productService.SearchProductsByName(term);

            if (product == null)
            {
                return NotFound(term);
            }

            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ProductDefinitionDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(productDto);

                var id = await _productService.InsertNewProduct(product);

                return Created($"{_httpContextAccessor.HttpContext.Request.Path.Value}/{id}", null);
            }

            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody]ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = _mapper.Map<Product>(productDto);

            product.Id = id;

            try
            {
                await _productService.UpdateExistingProduct(product);
            }
            catch (ProductNotFoundException)
            {
                return NotFound(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.DeleteProduct(id);
            }
            catch (ProductNotFoundException)
            {
                return NotFound(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }

            return Ok();
        }
    }
}
