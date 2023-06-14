using Microsoft.EntityFrameworkCore;
using Playing_With_GraphQL.src.Contexts;
using Playing_With_GraphQL.src.Models;

namespace Playing_With_GraphQL.src.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository([Service] DataContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct([Service] DataContext context, Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProductById(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        // public ValueTask DisposeAsync()
        // {
        //     return _context.DisposeAsync();
        // }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products
                .SingleOrDefaultAsync(x => x.Id == id);
            await _context.DisposeAsync();

            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            System.Console.WriteLine("there");
            var products = await _context.Products.ToListAsync();
            await _context.DisposeAsync();
            System.Console.WriteLine(products.Count);
            return products;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            await _context.DisposeAsync();

            return product;
        }
    }
}