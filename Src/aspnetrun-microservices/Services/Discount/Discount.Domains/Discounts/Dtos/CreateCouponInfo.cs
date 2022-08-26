using System;
namespace Discount.Domains.Discounts.Dtos
{
    public class CreateCouponInfo
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

    }
}

