using System;
using Catalog.Domains.Products.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace Catalog.DataAccessLayers.Context
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }


    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionStrings"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);

            // CatalogContextSeed.SeedData(Products);

        }

        public IMongoCollection<Product> Products { get; }
    }
}

