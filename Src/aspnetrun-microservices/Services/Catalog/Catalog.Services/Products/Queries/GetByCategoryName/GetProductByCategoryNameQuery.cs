using System;
using Catalog.Domains.Products.Entities;
using Catalog.Domains.Products.Repositories;
using MediatR;

namespace Catalog.Services.Products.Queries.GetByCategoryId
{
    public class GetProductByCategoryNameQuery:IRequest<IEnumerable<Product>>
    {
        public string CategoryName { get; set; }
    }

    public class GetByCategoryNameQueryHandler : IRequestHandler<GetProductByCategoryNameQuery, IEnumerable<Product>>
    {
        private readonly IProductQueryRepository _query;

        public GetByCategoryNameQueryHandler(IProductQueryRepository query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductByCategoryNameQuery request, CancellationToken cancellationToken) =>
        await _query.GetProductByCategoryName(request.CategoryName);
    }
}

