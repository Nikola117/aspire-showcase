using AspireShowcase.Catalog.Api.Infrastructure;
using AspireShowcase.Catalog.Api.Models;

namespace AspireShowcase.Catalog.Api.Extensions
{
    public static class DbContextExtensions
    {
        public static void SeedProducts(CatalogDbContext ctx)
        {
            var products = GetSampleClothingProducts();
            foreach (var product in products)
            {
                var exists = ctx.Products.FirstOrDefault(x => x.Id == product.Id);
                if (exists == null)
                {
                    ctx.Products.Add(new Product
                    {
                        Name = product.Name,
                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                    });
                    ctx.SaveChanges();
                }
            }
        }

        private static List<Product> GetSampleClothingProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Classic Denim Jacket",
                    Description = "Vintage-style denim jacket with brass buttons and adjustable waist tabs. Perfect for casual layering.",
                    ImageUrl = "/images/products/denim-jacket-blue.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Merino Wool Sweater",
                    Description = "Premium merino wool sweater with ribbed cuffs and hem. Naturally temperature-regulating and ultra-soft.",
                    ImageUrl = "/images/products/wool-sweater-gray.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "High-Waisted Slim Jeans",
                    Description = "Contemporary high-waisted jeans with stretch comfort. Features a slim fit and classic five-pocket design.",
                    ImageUrl = "/images/products/slim-jeans-dark.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Cotton Oxford Shirt",
                    Description = "Timeless oxford button-down shirt made from premium cotton. Perfect for both casual and semi-formal occasions.",
                    ImageUrl = "/images/products/oxford-shirt-white.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "Pleated Midi Skirt",
                    Description = "Elegant pleated midi skirt with comfortable elastic waistband. Flows beautifully with movement.",
                    ImageUrl = "/images/products/pleated-skirt-black.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name = "Quilted Winter Parka",
                    Description = "Warm winter parka with synthetic insulation and water-resistant exterior. Features multiple pockets and adjustable hood.",
                    ImageUrl = "/images/products/winter-parka-green.jpg"
                },
                new Product
                {
                    Id = 7,
                    Name = "Cotton Crew Neck T-Shirt",
                    Description = "Essential crew neck t-shirt made from organic cotton. Features a comfortable regular fit and reinforced seams.",
                    ImageUrl = "/images/products/crew-tshirt-navy.jpg"
                },
                new Product
                {
                    Id = 8,
                    Name = "Linen Blend Blazer",
                    Description = "Lightweight linen-blend blazer perfect for summer. Features a tailored fit and partial lining.",
                    ImageUrl = "/images/products/linen-blazer-beige.jpg"
                },
                new Product
                {
                    Id = 9,
                    Name = "Athletic Performance Leggings",
                    Description = "High-performance leggings with moisture-wicking fabric. Features a high waist and hidden pocket.",
                    ImageUrl = "/images/products/athletic-leggings-black.jpg"
                },
                new Product
                {
                    Id = 10,
                    Name = "Cashmere V-Neck Pullover",
                    Description = "Luxurious cashmere v-neck pullover. Features a relaxed fit and ribbed trim details.",
                    ImageUrl = "/images/products/cashmere-vneck-burgundy.jpg"
                },
                new Product
                {
                    Id = 11,
                    Name = "Cargo Utility Pants",
                    Description = "Durable cargo pants with multiple pockets. Made from cotton twill with a slight stretch for comfort.",
                    ImageUrl = "/images/products/cargo-pants-khaki.jpg"
                },
                new Product
                {
                    Id = 12,
                    Name = "Silk Button-Up Blouse",
                    Description = "Elegant silk blouse with covered button placket. Features a relaxed fit and subtle sheen.",
                    ImageUrl = "/images/products/silk-blouse-ivory.jpg"
                },
                new Product
                {
                    Id = 13,
                    Name = "Hooded Zip Sweatshirt",
                    Description = "Classic zip-up hoodie made from brushed fleece. Features kangaroo pockets and ribbed cuffs.",
                    ImageUrl = "/images/products/zip-hoodie-gray.jpg"
                },
                new Product
                {
                    Id = 14,
                    Name = "Wrap Maxi Dress",
                    Description = "Flattering wrap-style maxi dress in flowing fabric. Features adjustable waist tie and flutter sleeves.",
                    ImageUrl = "/images/products/wrap-dress-floral.jpg"
                },
                new Product
                {
                    Id = 15,
                    Name = "Wool Blend Peacoat",
                    Description = "Classic double-breasted peacoat in wool blend. Features notched lapels and welted pockets.",
                    ImageUrl = "/images/products/peacoat-navy.jpg"
                }
            };
        }
    }
}
