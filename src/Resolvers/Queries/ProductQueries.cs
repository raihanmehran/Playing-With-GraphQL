using Microsoft.EntityFrameworkCore;
using Playing_With_GraphQL.src.Contexts;
using Playing_With_GraphQL.src.Models;
using Playing_With_GraphQL.src.Repositories;

namespace Playing_With_GraphQL.src.Resolvers.Queries
{
    public class ProductQueries
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> GetProducts([Service] DataContext context)
        {
            try
            {
                return context.Products;
            }
            catch (Exception) { throw; }
        }

        public async Task<Product> GetProductById([Service] DataContext context, int id)
        {
            try
            {
                System.Console.WriteLine(id);
                return await context.Products.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception) { throw; }
        }
    }
}