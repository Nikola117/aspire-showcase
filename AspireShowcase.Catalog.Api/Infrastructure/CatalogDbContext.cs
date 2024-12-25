using AspireShowcase.Catalog.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AspireShowcase.Catalog.Api.Infrastructure
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
