using System;
using AutoMapper;
using Eventbus.Messages.Events;
using Order.Domains.Orders.Dtos;
using Order.Services.EventBusConsumers;
using Order.Services.Orders.Commands.Create;

namespace Order.ServicesMappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Domains.Orders.Entities.Order,OrderInfo>()
                .ForMember(s=>s.OrderFullData,op=>op.MapFrom(des=>$"{des.FirstName} {des.LastName} - {des.UserName} {des.TotalPrice} - {des.AddressLine}"))
                .ReverseMap();
            CreateMap<Domains.Orders.Entities.Order, UpdateOrderInfo>().ReverseMap();

            CreateMap<CreateOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}

