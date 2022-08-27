using System;
using AutoMapper;
using Eventbus.Messages.Events;
using MassTransit;
using MediatR;
using Order.Services.Orders.Commands.Create;

namespace Order.Services.EventBusConsumers
{
    public class BasketCheckoutConsumer:IConsumer<BasketCheckoutEvent>
    {
       private IMediator _mediator;
        IMapper _mapper;
        public BasketCheckoutConsumer(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

     

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var basket = _mapper.Map<CreateOrderCommand>(context.Message);         
            await _mediator.Send(basket);
        }
    }
}

