using System;
using Catalog.Domains.Products.Entities;
using MongoDB.Driver;

namespace Catalog.DataAccessLayers.Context
{
    public class CatalogContextSeed
    {
      public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool exitProduct = productCollection.Find(p=>true).Any();
            if (!exitProduct)
            {
                productCollection.InsertManyAsync(GetPreCOnfigurationProduct());
            }

        }


        public static IEnumerable<Product> GetPreCOnfigurationProduct()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Category1",
                Description = "Description1",
                ImageFile = "ImageFIle1",
                Name = "Name1",
                Price = 12.12M,
                Summary = "Summary1"
            });
            products.Add(new Product
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Category2",
                Description = "Description2",
                ImageFile = "ImageFIle2",
                Name = "Name2",
                Price = 14M,
                Summary = "Summary2"
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid().ToString(),
                Category = "Category3",
                Description = "Description3",
                ImageFile = "ImageFIle3",
                Name = "Name3",
                Price = 851.333M,
                Summary = "Summary3"
            });

            return products;
        }
    }
}

