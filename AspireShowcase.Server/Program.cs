using AspireShowcase.Cart.Api;
using AspireShowcase.Catalog.Api;
using AspireShowcase.Catalog.Api.Extensions;
using AspireShowcase.Catalog.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var connectionString = builder.Configuration.GetConnectionString("catalogdb");
builder.AddSqlServerDbContext<CatalogDbContext>("catalogdb");

builder.Services.AddScoped<CatalogRepository>();
builder.Services.AddScoped<CartRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<CatalogDbContext>();
        await context.Database.MigrateAsync();

        DbContextExtensions.SeedProducts(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

app.MapDefaultEndpoints();

app.MapGet("/products", ([FromServices] CatalogRepository catalogRepository) => catalogRepository.GetProducts());
app.MapGet("/products/{id}", ([FromServices] CatalogRepository catalogRepository, long id) => catalogRepository.GetProductById(id));
app.MapGet("/cart/{id}", ([FromServices] CartRepository cartRepository, long id) => cartRepository.GetCartById(id));

app.Run();
