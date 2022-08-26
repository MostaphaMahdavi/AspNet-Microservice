using System;
using Discount.DataAccessLayers.Discounts.Coupons;
using Discount.Domains.Discounts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.DataAccessLayers.Context
{
    public class DiscountContext:DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options):base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
      

        public DbSet<Coupon> Coupons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CouponConfig).Assembly);
        }


    }
}

