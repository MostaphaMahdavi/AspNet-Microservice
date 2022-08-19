using Catalog.Domains.Products.Entities;

namespace Catalog.Domains.Products.Repositories
{
    public interface IProductQueryRepository
    {

        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategoryName(string categoryName);
    }

}

