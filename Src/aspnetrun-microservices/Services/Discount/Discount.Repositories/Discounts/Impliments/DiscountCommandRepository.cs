using System;
using Discount.DataAccessLayers.Context;
using Discount.Domains.Discounts.Entities;
using Discount.Domains.Discounts.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Repositories.Discounts.Impliments
{
    public class DiscountCommandRepository: IDiscountCommandRepository
    {
        DiscountContext _db;

        public DiscountCommandRepository(DiscountContext db)
        {
            _db = db;
        }


        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            await _db.Coupons.AddAsync(coupon);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDiscount(Coupon coupon)
        {
            _db.Coupons.Remove(coupon);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            _db.Coupons.Update(coupon);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

