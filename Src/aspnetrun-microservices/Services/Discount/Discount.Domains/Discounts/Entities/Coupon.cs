using System;
using aspnetrun_microservice.Frameworks.Entities;

namespace Discount.Domains.Discounts.Entities
{
    public class Coupon:BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}

