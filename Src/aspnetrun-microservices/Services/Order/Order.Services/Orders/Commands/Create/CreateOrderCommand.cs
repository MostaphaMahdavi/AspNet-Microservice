using System;
using aspnetrun_microservice.Frameworks.Entities.Emails;
using aspnetrun_microservice.Frameworks.Interfaces;
using AutoMapper;
using MediatR;
using Order.Domains.Orders.Dtos;
using Order.Domains.Orders.Repositories;


namespace Order.Services.Orders.Commands.Create
{
    public class CreateOrderCommand:OrderInfo,IRequest<OrderInfo>
    {
        
    }

    public class CreateOrderCommandHandelr : IRequestHandler<CreateOrderCommand, OrderInfo>
    {
       private readonly IOrderCommandRepository _command;
       private readonly IMapper _mapper;

        public CreateOrderCommandHandelr(IOrderCommandRepository command, IMapper mapper)
        {
            _command = command;
            _mapper = mapper;
        }

        public async Task<OrderInfo> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderData = _mapper.Map<Domains.Orders.Entities.Order>(request);
            var newOrder= await _command.CreateOrder(orderData);

          /*
           * await _emailService.SendEmail(new Email
            {
               To=request.EmailAddress,
               Body="Order was created",
               Subject="Create order"
            });
          */

            return _mapper.Map<OrderInfo>(newOrder);
        }
    }
}

