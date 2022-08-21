using System;
using Basket.Domain.Baskets.Entities;

namespace Basket.Domain.Baskets.Services
{
    public interface IBasketService
    {

        Task<ShoppingCart> GetBasketAsyn(string userName);
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart shoppingCart);
        Task DeleteBasketAsync(string userName);
    }
}

