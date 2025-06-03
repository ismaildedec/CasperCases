using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Category = "Elektronik" },
            new Product { Id = 2, Name = "Telefon", Category = "Elektronik" },
            new Product { Id = 3, Name = "Koltuk", Category = "Mobilya" },
            new Product { Id = 4, Name = "Masa", Category = "Mobilya" },
            new Product { Id = 5, Name = "Kazak", Category = "Giyim" }
        };

        [HttpGet]
        public IActionResult Get([FromQuery] string? filter)
        {
            var result = Products.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();
                result = result.Where(p => p.Name.ToLower().Contains(filter) || p.Category.ToLower().Contains(filter));
            }
            return Ok(result);
        }
    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
} 