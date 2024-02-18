using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddProduct(Product product)
        {
            await _productRepository.AddProduct(product);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<List<Product>> GetProductsByName(string name)
        {
            return await _productRepository.GetProductsByName(name);
        }

        public async Task<int> GetTotalProductCount()
        {
            return await _productRepository.GetTotalProductCount();
        }

        public async Task<List<Product>> GetProductsByCategory(string category)
        {
            return await _productRepository.GetProductsByCategory(category);
        }

        public async Task<List<Product>> SortProducts(string sortBy, string sortOrder)
        {
            return await _productRepository.SortProducts(sortBy,sortOrder);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task DeleteAllProducts()
        {
            await _productRepository.DeleteAllProducts();
        }
        //public List<Product> GetProductsByCategoryAndSubcategory(string category, string subcategory)
        //{
        //    return _productRepository.GetProductsByCategoryAndSubcategory(category, subcategory);
        //}
        //public async Task<IEnumerable<Product>> GetAllProductsAsync()
        //{
        //    return await _productRepository.GetAllProductsAsync();
        //}

        //public async Task<Product> GetProductByIdAsync(int id)
        //{
        //    return await _productRepository.GetProductByIdAsync(id);
        //}

        //public async Task AddProductAsync(Product product)
        //{
        //    await _productRepository.AddProductAsync(product);
        //}

        //public async Task UpdateProductAsync(Product product)
        //{
        //    await _productRepository.UpdateProductAsync(product);
        //}

        //public async Task DeleteProductAsync(int id)
        //{
        //    await _productRepository.DeleteProductAsync(id);
        //}
        // Implement other business logic here
    }
}
