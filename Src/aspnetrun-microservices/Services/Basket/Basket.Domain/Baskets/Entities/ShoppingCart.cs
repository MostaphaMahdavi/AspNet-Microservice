using System;
namespace Basket.Domain.Baskets.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {

        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPRice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in ShoppingCartItems)
                {
                    totalPrice += item.Price *item.Quantity;
                }
                return totalPrice;
            }
        }
    }
}

