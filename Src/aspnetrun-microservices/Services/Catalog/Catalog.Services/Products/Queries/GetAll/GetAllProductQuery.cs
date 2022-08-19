using System;
using Catalog.Domains.Products.Entities;
using Catalog.Domains.Products.Repositories;
using MediatR;

namespace Catalog.Services.Products.Queries.GetAll
{
    public class GetAllProductQuery:IRequest<IEnumerable<Product>>
    {
       
    }

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly IProductQueryRepository _query;

        public GetAllProductQueryHandler(IProductQueryRepository query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)=>        
            await _query.GetProducts();
        
    }
}

