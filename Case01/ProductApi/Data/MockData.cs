using ProductApi.Models;
using System.Collections.Generic;

namespace ProductApi.Data
{
    public static class MockData
    {
        public static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Category = "Elektronik" },
            new Product { Id = 2, Name = "Telefon", Category = "Elektronik" },
            new Product { Id = 3, Name = "Koltuk", Category = "Mobilya" },
            new Product { Id = 4, Name = "Masa", Category = "Mobilya" },
            new Product { Id = 5, Name = "Kazak", Category = "Giyim" }
        };
    }
} 