using System;
using AutoMapper;
using MediatR;
using Order.Domains.Orders.Dtos;
using Order.Domains.Orders.Repositories;

namespace Order.Services.Orders.Queries.GetAll
{
    public class GetAllOrderQuery:IRequest<IEnumerable<OrderInfo>>
    {
      
    }


    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<OrderInfo>>
    {
        IOrderQueryRepository _query;
        IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderQueryRepository query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderInfo>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _query.GetAllOrder();
            return _mapper.Map<IEnumerable<OrderInfo>>(orders);
        }
    }
}

