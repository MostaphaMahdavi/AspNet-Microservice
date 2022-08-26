using System;
using Discount.Domains.Discounts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discount.DataAccessLayers.Discounts.Coupons
{
    public class CouponConfig:IEntityTypeConfiguration<Coupon>
    {       

        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(d=>d.ProductName).IsRequired().HasMaxLength(150);
            builder.Property(d=>d.Amount).IsRequired();
            builder.Property(d=>d.Description).IsRequired().HasMaxLength(500);

        }
    }
}

