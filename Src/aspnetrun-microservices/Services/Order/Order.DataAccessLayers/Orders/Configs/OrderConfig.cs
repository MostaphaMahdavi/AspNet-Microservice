using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.DataAccessLayers.Orders.Configs
{
    public class OrderConfig : IEntityTypeConfiguration<Domains.Orders.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Domains.Orders.Entities.Order> builder)
        {
            builder.Property(o => o.UserName).IsRequired().HasMaxLength(150);
            builder.Property(o => o.TotalPrice).IsRequired().HasMaxLength(150);

            builder.Property(o=>o.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(o => o.LastName).IsRequired().HasMaxLength(150);
            builder.Property(o => o.EmailAddress).IsRequired().HasMaxLength(350);
            builder.Property(o => o.AddressLine).IsRequired().HasMaxLength(300);
            builder.Property(o => o.Country).IsRequired().HasMaxLength(50).HasDefaultValue("ایران");
            builder.Property(o => o.State).IsRequired().HasMaxLength(50).HasDefaultValue("تهران");
            builder.Property(o => o.ZipCode).IsRequired().HasMaxLength(15);

            builder.Property(o => o.CardName).IsRequired().HasMaxLength(100);
            builder.Property(o => o.CardNumber).IsRequired().HasMaxLength(30);
            builder.Property(o => o.Expiration).IsRequired().HasMaxLength(5);
            builder.Property(o => o.CVV).IsRequired().HasMaxLength(10);
            builder.Property(o => o.PaymentMethod).IsRequired().HasMaxLength(50);
        }

    }
}

