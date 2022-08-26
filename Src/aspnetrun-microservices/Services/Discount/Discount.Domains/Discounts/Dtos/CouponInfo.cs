using System;
namespace Discount.Domains.Discounts.Dtos
{
    public class CouponInfo
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        public string CouponFUllData { get; set; }
    }
}

