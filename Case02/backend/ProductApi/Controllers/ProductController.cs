using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private static List<Category> Categories = new List<Category>
        {
            new Category { Id = 1, Name = "Elektronik" },
            new Category { Id = 2, Name = "Mobilya" }
        };

        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 15000, CategoryId = 1 },
            new Product { Id = 2, Name = "Koltuk", Price = 5000, CategoryId = 2 }
        };

 
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var result = Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = Categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name
            });
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<ProductDto> Create([FromBody] ProductCreateDto dto)
        {
            var newId = Products.Any() ? Products.Max(p => p.Id) + 1 : 1;
            var product = new Product
            {
                Id = newId,
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };
            Products.Add(product);
            var result = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name
            };
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, result);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductCreateDto dto)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            Products.Remove(product);
            return NoContent();
        }

        
        [HttpGet("categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return Ok(Categories);
        }
    }

    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
} 