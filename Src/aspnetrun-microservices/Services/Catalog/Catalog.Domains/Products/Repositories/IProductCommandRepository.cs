using System;
using Catalog.Domains.Products.Entities;

namespace Catalog.Domains.Products.Repositories
{
    public interface IProductCommandRepository
    {
        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }

}

