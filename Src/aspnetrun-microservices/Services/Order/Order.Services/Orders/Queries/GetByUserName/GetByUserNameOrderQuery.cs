using System;
using AutoMapper;
using MediatR;
using Order.Domains.Orders.Dtos;
using Order.Domains.Orders.Repositories;

namespace Order.Services.Orders.Queries.GetByUserName
{
    public class GetByUserNameOrderQuery:IRequest<IEnumerable<OrderInfo>>
    {
        public string UserName { get; set; }
    }

    public class GetByUserNameOrderQueryHandler : IRequestHandler<GetByUserNameOrderQuery, IEnumerable<OrderInfo>>
    {
        IOrderQueryRepository _query;
        IMapper _mapper;

        public GetByUserNameOrderQueryHandler(IOrderQueryRepository query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }


        public async Task<IEnumerable<OrderInfo>> Handle(GetByUserNameOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _query.GetOrderByUserName(request.UserName);
            if (orders is null)
            {
                throw new Exception("یافت نشد.");
            }
            return  _mapper.Map<IEnumerable<OrderInfo>>(orders);
        }
        
    }
}

