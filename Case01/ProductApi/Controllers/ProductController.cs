using Microsoft.AspNetCore.Mvc;
using ProductApi.Services;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromQuery] string? filter)
        {
            try
            {
                IEnumerable<Product> products;
                if (string.IsNullOrWhiteSpace(filter))
                    products = await _productService.GetAllProductsAsync();
                else
                    products = await _productService.GetFilteredProductsAsync(filter);
                return Ok(products);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }
    }
} 