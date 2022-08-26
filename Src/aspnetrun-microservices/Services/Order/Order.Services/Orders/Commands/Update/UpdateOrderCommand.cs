using System;
using AutoMapper;
using MediatR;
using Order.Domains.Orders.Dtos;
using Order.Domains.Orders.Repositories;

namespace Order.Services.Orders.Commands.Update
{
    public class UpdateOrderCommand:UpdateOrderInfo,IRequest<bool>
    {
        
    }

    public class UpdateOrderCommandHandelr : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderCommandRepository _command;
        private readonly IOrderQueryRepository _query;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandelr(IOrderCommandRepository command, IMapper mapper, IOrderQueryRepository query)
        {
            _command = command;
            _mapper = mapper;
            _query = query;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Domains.Orders.Entities.Order>(request);
            if (order is null)
            {
                throw new Exception("یافت نشد.");
            }
            await _command.UpdateOrder(order);
            return true;
        }
    }
}

