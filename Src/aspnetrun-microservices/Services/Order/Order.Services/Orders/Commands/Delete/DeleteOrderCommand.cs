using System;
using AutoMapper;
using MediatR;
using Order.Domains.Orders.Repositories;

namespace Order.Services.Orders.Commands.Delete
{
    public class DeleteOrderCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteOrderCommandHandel : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderCommandRepository _command;
        private readonly IOrderQueryRepository _query;
       

        public DeleteOrderCommandHandel(IOrderCommandRepository command,IOrderQueryRepository query)
        {
            _command = command;
            _query = query;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _query.GetOrderById(request.Id);
            if (order is null)
            {
                throw new Exception("یافت نشد.");
            }
            await _command.DeleteOrder(order);
            return true;
        }
    }
}

