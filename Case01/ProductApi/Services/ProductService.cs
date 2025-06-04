using ProductApi.Models;
using ProductApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Services
{    public class ProductService : IProductService
    {

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await Task.FromResult(MockData.Products);
        }

 
        public async Task<IEnumerable<Product>> GetFilteredProductsAsync(string? filter)
        {
            var products = MockData.Products.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();
                products = products.Where(p => p.Name.ToLower().Contains(filter) || p.Category.ToLower().Contains(filter));
            }
            return await Task.FromResult(products);
        }
    }
} 