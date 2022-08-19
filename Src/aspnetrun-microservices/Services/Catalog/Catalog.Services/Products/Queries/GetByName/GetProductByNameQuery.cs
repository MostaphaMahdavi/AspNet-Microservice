using System;
using Catalog.Domains.Products.Entities;
using Catalog.Domains.Products.Repositories;
using MediatR;

namespace Catalog.Services.Products.Queries.GetByName
{
    public class GetProductByNameQuery:IRequest<IEnumerable<Product>>
    {
        public string Name { get; set; }
    }

    public class GetProductByNameQueryHandker : IRequestHandler<GetProductByNameQuery, IEnumerable<Product>>
    {
        private readonly IProductQueryRepository _query;

        public GetProductByNameQueryHandker(IProductQueryRepository query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken) =>
            await _query.GetProductByName(request.Name);
    }
}

