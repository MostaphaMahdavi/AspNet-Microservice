using System;
using Catalog.Domains.Products.Entities;
using Catalog.Domains.Products.Repositories;
using MediatR;

namespace Catalog.Services.Products.Queries.GetById
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public string Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductQueryRepository _query;

        public GetProductByIdQueryHandler(IProductQueryRepository query)
        {
            _query = query;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
            await _query.GetProductById(request.Id);
    }
}

