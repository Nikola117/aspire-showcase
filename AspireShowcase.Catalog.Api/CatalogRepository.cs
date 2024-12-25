using AspireShowcase.Catalog.Api.Infrastructure;
using AspireShowcase.Catalog.Api.Models;

namespace AspireShowcase.Catalog.Api
{
    public class CatalogRepository
    {
        private readonly CatalogDbContext catalogDbContext;

        //private List<Product> products;

        public CatalogRepository(CatalogDbContext catalogDbContext)
        {
            this.catalogDbContext = catalogDbContext;
            //products = GetSampleClothingProducts();
        }

        public Product GetProductById(long id)
        {
            return catalogDbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return catalogDbContext.Products.ToList();
        }
    }
}
