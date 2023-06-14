using Microsoft.EntityFrameworkCore;
using Playing_With_GraphQL.src.Contexts;
using Playing_With_GraphQL.src.Repositories;

namespace Playing_With_GraphQL.src.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration config
        )
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}