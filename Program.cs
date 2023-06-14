using Microsoft.EntityFrameworkCore;
using Playing_With_GraphQL.src.Contexts;
using Playing_With_GraphQL.src.Models;
using Playing_With_GraphQL.src.Repositories;
using Playing_With_GraphQL.src.Resolvers.Mutations;
using Playing_With_GraphQL.src.Resolvers.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opt => opt
    .UseSqlite(builder.Configuration
        .GetConnectionString("DefaultConnection")),
        ServiceLifetime.Transient);

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<ProductQueries>()
    .AddMutationType<ProductMutations>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.MapGraphQL("/graphql");

app.Run();

public class Query
{
    public string Hello(string name = "World")
        => $"Hello, {name}!";

    public IEnumerable<Book> GetBooks()
    {
        var author = new Author("Jon Skeet");
        yield return new Book("C# in Depth", author);
        yield return new Book("C# in Depth 2nd Edition", author);
    }
}

public record Book(string Title, Author Author);
public record Author(string Name);
