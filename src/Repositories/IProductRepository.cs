using Playing_With_GraphQL.src.Contexts;
using Playing_With_GraphQL.src.Models;

namespace Playing_With_GraphQL.src.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct([Service] DataContext context, Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}