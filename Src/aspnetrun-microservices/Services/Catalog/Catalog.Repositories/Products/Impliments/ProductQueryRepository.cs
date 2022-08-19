using Catalog.DataAccessLayers.Context;
using Catalog.Domains.Products.Entities;
using Catalog.Domains.Products.Repositories;
using MongoDB.Driver;

namespace Catalog.Repositories.Products.Impliments
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly ICatalogContext _context;
        public ProductQueryRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryName(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p=>p.Category,categoryName);
          return  await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<Product> GetProductById(string id)=>
            await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();



        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Where(p => p.Name.Contains(name) );
          return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()=>
            await _context.Products.Find(p => true).ToListAsync();
    }
}

