using Microsoft.EntityFrameworkCore;
using Playing_With_GraphQL.src.Contexts;
using Playing_With_GraphQL.src.Models;
using Playing_With_GraphQL.src.Repositories;

namespace Playing_With_GraphQL.src.Resolvers.Mutations
{
    public class ProductMutations
    {
        public ProductMutations()
        {
        }

        public async Task<Product> AddProduct([Service] DataContext _context, Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception) { throw; }
        }

        public async Task<Product> UpdateProduct([Service] DataContext _context, Product product)
        {
            try
            {
                var existingProduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                }
                var result = await _context.SaveChangesAsync() > 0;

                if (result) return existingProduct;
                return product;
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> DeleteProduct([Service] DataContext _context, int productId)
        {
            try
            {
                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == productId);
                if (product != null)
                {
                    _context.Remove(product);
                    return true;
                }

                return false;
            }
            catch (Exception) { throw; }
        }
    }
}