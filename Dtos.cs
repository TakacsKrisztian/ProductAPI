using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class Dtos
    {
        public record ProductDto(Guid Id, string ProductName, int ProductPrice, DateTimeOffset CreatedTime,
            DateTimeOffset ModifiedTime);
        public record CreateProductDto([Required]string ProductName, [Range(0, 10000)] int ProductPrice);
        public record UpdateProductDto(string ProductName, int ProductPrice);
        public record DeleteProductDto([Required]string ProductName, [Range(0, 10000)] int ProductPrice);
    }
}
