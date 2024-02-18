using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductsByName(string name);
        Task<int> GetTotalProductCount();
        Task<List<Product>> GetProductsByCategory(string category);
        Task<List<Product>> SortProducts(string sortBy, string sortOrder);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task DeleteAllProducts();
    }
}
