using System;
using Discount.Domains.Discounts.Entities;

namespace Discount.Domains.Discounts.Repositories
{
    public interface IDiscountCommandRepository
    {
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(Coupon coupon);
        
    }
}

