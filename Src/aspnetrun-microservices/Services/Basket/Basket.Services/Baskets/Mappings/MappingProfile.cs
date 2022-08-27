using System;
using AutoMapper;
using Basket.Domain.Baskets.Dtos;
using Basket.Domain;
using Eventbus.Messages.Events;

namespace Basket.Services.Baskets.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BasketCheckoutInfo, BasketCheckoutEvent>().ReverseMap();
        }
    }
}

