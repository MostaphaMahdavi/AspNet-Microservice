using System;
using Catalog.DataAccessLayers.Context;
using Catalog.Domains.Products.Entities;
using Catalog.Domains.Products.Repositories;
using MongoDB.Driver;

namespace Catalog.Repositories.Products.Impliments
{
    public class ProductCommandRepository : IProductCommandRepository
    {
       private readonly ICatalogContext _context;
        public ProductCommandRepository(ICatalogContext context)
        {
            _context = context?? throw new ArgumentException(nameof(context));
        }

        public async Task CreateProduct(Product product)=>
            await _context.Products.InsertOneAsync(product);
       

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p=>p.Id,id);
            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
           var updateResult= await _context.Products.ReplaceOneAsync(filter:g=>g.Id==product.Id,replacement:product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}

