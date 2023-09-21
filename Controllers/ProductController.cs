using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Dtos.Dtos;

namespace Dtos.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<ProductDto> products = new()
        {
            new ProductDto(Guid.NewGuid(), "Termék1", 2500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(), "Termék2", 5500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(), "Termék3", 12500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
        };

        [HttpGet] public IEnumerable<ProductDto> GetAll()
        {
            return products;
        }
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(Guid id)
        {
            var product = products.Where(x => x.Id == id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDto> PostProduct(CreateProductDto createProduct)
        {
            var product = new ProductDto(
                Guid.NewGuid(),
                createProduct.ProductName,
                createProduct.ProductPrice,
                DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow
                );

            if (product.ProductName == null || product.ProductPrice == 0)
            {
                return BadRequest();
            }

            products.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id },product);
        }
        [HttpPut]
        public ProductDto PullProduct(Guid id, UpdateProductDto updateProduct)
        {
            var existingProduct = products.Where(x => x.Id == id).FirstOrDefault();

            var product = existingProduct with
            {
                ProductName = updateProduct.ProductName,
                ProductPrice = updateProduct.ProductPrice,
                ModifiedTime = DateTimeOffset.UtcNow
            };

            var index = products.FindIndex(x => x.Id == id);

            products[index] = product;

            return product;
        }
        [HttpDelete]
        public ActionResult<object> DeleteProduct(Guid id)
        {
            var index = products.FindIndex(x => x.Id == id);

            products.RemoveAt(index);

            if (index == 0)
            {
                return NotFound();
            }

            return StatusCode(205, "Törölt");    
        }

    }
}
