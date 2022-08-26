using System;
using AutoMapper;
using MediatR;
using Order.Domains.Orders.Dtos;
using Order.Domains.Orders.Repositories;

namespace Order.Services.Orders.Queries.GetById
{
    public class GetByIdOrderQuery:IRequest<OrderInfo>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdOrderQueryHandelr : IRequestHandler<GetByIdOrderQuery, OrderInfo>
    {

        IOrderQueryRepository _query;
        IMapper _mapper;

        public GetByIdOrderQueryHandelr(IOrderQueryRepository query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<OrderInfo> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _query.GetOrderById(request.Id);
            if (order is null)
            {
                throw new Exception("یافت نشد.");
            }
            return _mapper.Map<OrderInfo>(order);
        }
    }
}

