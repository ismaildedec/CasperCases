using ProductApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetFilteredProductsAsync(string? filter);
    }
} 