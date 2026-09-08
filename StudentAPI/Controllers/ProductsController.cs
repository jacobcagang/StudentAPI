using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        // GET: api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            products.Add(product);

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.ProductId },
                product
            );
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            product.Code = updatedProduct.Code;
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;

            return Ok(product);
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            products.Remove(product);

            return NoContent();
        }
    }
}
