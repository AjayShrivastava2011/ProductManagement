using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsByName(string name)
        {
            return await _context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task<int> GetTotalProductCount()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<List<Product>> GetProductsByCategory(string category)
        {
            return await _context.Products.Where(p => p.Category == category).ToListAsync();
        }

        public async Task<List<Product>> SortProducts(string sortBy, string sortOrder)
        {
            IQueryable<Product> query = _context.Products;

            switch (sortBy.ToLower())
            {
                case "name":
                    query = sortOrder.ToLower() == "asc" ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                    break;
                case "category":
                    query = sortOrder.ToLower() == "asc" ? query.OrderBy(p => p.Category) : query.OrderByDescending(p => p.Category);
                    break;
                case "price":
                    query = sortOrder.ToLower() == "asc" ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            //if (_context.Entry(product).State == EntityState.Detached)
            //{
            //    _context.Products.Attach(product);
            //}
            //_context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllProducts()
        {
            _context.Products.RemoveRange(_context.Products);
            await _context.SaveChangesAsync();
        }
        //public List<Product> GetProductsByCategoryAndSubcategory(string category, string subcategory)
        //{
        //    return _context.Products
        //        .Where(p => p.Category == category && p.Subcategory == subcategory)
        //        .ToList();
        //}
        //public async Task<IEnumerable<Product>> GetAllProductsAsync()
        //{
        //    return await _context.Products.ToListAsync();
        //}

        //public async Task<Product> GetProductByIdAsync(int id)
        //{
        //    return await _context.Products.FindAsync(id);
        //}

        //public async Task AddProductAsync(Product product)
        //{
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateProductAsync(Product product)
        //{
        //    _context.Entry(product).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteProductAsync(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if (product != null)
        //    {
        //        _context.Products.Remove(product);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        // Implement other database operations here
    }
}
