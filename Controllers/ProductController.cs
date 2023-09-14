using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Dtos.Dtos;

namespace Dtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<ProductDto> productDtos = new()
        {
            new ProductDto(Guid.NewGuid(), "Termék1", 2500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(), "Termék2", 5500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new ProductDto(Guid.NewGuid(), "Termék3", 12500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
        };
    }
}
