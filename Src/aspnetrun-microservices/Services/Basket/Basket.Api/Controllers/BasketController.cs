using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Basket.Domain.Baskets.Services;
using Basket.Domain.Baskets.Entities;
using Basket.Api.GrpcService;
using Basket.Domain.Baskets.Dtos;
using aspnetrun_microservice.Frameworks.Common;
using Eventbus.Messages.Events;
using AutoMapper;
using MassTransit;
using Newtonsoft.Json;

namespace Basket.Api.Controllers
{

    public class BasketController : BaseController
    {
       // private readonly DiscountGrpcService _discountGrpcService;
        private readonly IBasketService _basket;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publish;

        public BasketController(IBasketService basket,
            IMapper mapper, IPublishEndpoint publish)
        {
            _basket = basket;
            _mapper = mapper;
            _publish = publish;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasket(string userName)
        {
            var basket = await _basket.GetBasketAsyn(userName);
            return Ok(basket??new ShoppingCart (userName));
        }



        [HttpPut("[action]")]
        public async Task<IActionResult> InsertBasket (ShoppingCart shoppingCart)
        {
           
            return Ok(await _basket.UpdateBasketAsync(shoppingCart));
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _basket.DeleteBasketAsync(userName);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Checkout(BasketCheckoutInfo request)
        {

            // get from redis
            var basket = await _basket.GetBasketAsyn(request.UserName);
            if (basket is null)
            {
                return BadRequest("یافت نشد.");
            }


            var eventMessage = _mapper.Map<BasketCheckoutEvent>(request);
            eventMessage.TotalPrice = basket.TotalPRice;

            //publish to rabbitmq with MassTransit
            await _publish.Publish(eventMessage);
            //delete from redis
            await _basket.DeleteBasketAsync(request.UserName);
            return Accepted();
        }


    }
}

