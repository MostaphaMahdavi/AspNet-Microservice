using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Basket.Domain.Baskets.Services;
using Basket.Domain.Baskets.Entities;
using Basket.Api.GrpcService;

namespace Basket.Api.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly IBasketService _basket;
        public BasketController(IBasketService basket, DiscountGrpcService discountGrpcService )
        {
            _basket = basket;
            _discountGrpcService = discountGrpcService;
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
            /*
            foreach (var item in shoppingCart.ShoppingCartItems)
            {
              var coupon= await _discountGrpcService.GetDiscount(item.ProductName);
                item.Price = coupon.Amount;
            }
            */
            return Ok(await _basket.UpdateBasketAsync(shoppingCart));
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _basket.DeleteBasketAsync(userName);
            return Ok();
        }



    }
}

