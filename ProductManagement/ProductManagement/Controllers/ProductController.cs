using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetProductsByName([FromQuery] string name)
        {
            var products = await _productService.GetProductsByName(name);
            return Ok(products);
        }

        [HttpGet("total-count")]
        public async Task<IActionResult> GetTotalProductCount()
        {
            try
            {
                var totalCount = await _productService.GetTotalProductCount();
                return Ok(totalCount);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            var products = await _productService.GetProductsByCategory(category);
            if (products == null || products.Count == 0)
                return NotFound();

            return Ok(products);
        }

        [HttpGet("sort")]
        public async Task<IActionResult> SortProducts([FromQuery] string sortBy, [FromQuery] string sortOrder)
        {
            var sortedProducts = await _productService.SortProducts(sortBy, sortOrder);
            return Ok(sortedProducts);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            var existingProduct = await _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound();
            //Can replace with Mapper
            existingProduct.Name = product.Name; 
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;

            await _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound();

            await _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllProducts()
        {
            await _productService.DeleteAllProducts();
            return NoContent();
        }
        // GET: api/product/category/{category}/subcategory/{subcategory}
        //[HttpGet("category/{category}/subcategory/{subcategory}")]
        //public ActionResult<IEnumerable<Product>> GetProductsByCategoryAndSubcategory(string category, string subcategory)
        //{
        //    var products = _productService.GetProductsByCategoryAndSubcategory(category, subcategory);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return products;//OK - 200
        //}
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    var products = await _productService.GetAllProductsAsync();
        //    return Ok(products);//200
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProductById(int id)
        //{
        //    //
        //    var product = await _productService.GetProductByIdAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        //[HttpPost]
        //public async Task<ActionResult<Product>> AddProduct(Product product)
        //{
        //    await _productService.AddProductAsync(product);
        //    return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await _productService.UpdateProductAsync(product);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    await _productService.DeleteProductAsync(id);
        //    return NoContent();
        //}

        // Implement other CRUD operations here
    }
}
