using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Product>>> GetProducts()
        {
            IList<Product> products = await _productRepo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product? product = await _productRepo.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await _productRepo.CreateProductAsync(product);
            return CreatedAtAction(nameof(CreateProduct),
                                   new { id = product.Id },
                                   product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _productRepo.UpdateProductAsync(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepo.DeleteProductAsync(id);
            return Ok();
        }
    }
}
