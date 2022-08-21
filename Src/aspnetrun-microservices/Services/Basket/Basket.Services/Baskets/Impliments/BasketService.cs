using System;
using Basket.Domain.Baskets.Entities;
using Basket.Domain.Baskets.Repositories;
using Basket.Domain.Baskets.Services;

namespace Basket.Services.Baskets.Impliments
{
    public class BasketService: IBasketService
    {
        IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task DeleteBasketAsync(string userName)=>
        
            await _basketRepository.DeleteBasket(userName);
        

        public async Task<ShoppingCart> GetBasketAsyn(string userName)=>
        
            await _basketRepository.GetBasket(userName);
        

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart shoppingCart)=>
        
            await _basketRepository.UpdateBasket(shoppingCart);
        
    }
}

