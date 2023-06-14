using Microsoft.EntityFrameworkCore;
using Playing_With_GraphQL.src.Models;

namespace Playing_With_GraphQL.src.Contexts
{
    public class DataContext : DbContext
    {
        // public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DataContext(DbContextOptions options)
            : base(options: options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}