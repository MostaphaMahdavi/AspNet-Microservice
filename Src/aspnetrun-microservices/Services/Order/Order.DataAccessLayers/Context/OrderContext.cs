using System;
using Microsoft.EntityFrameworkCore;
using Order.DataAccessLayers.Orders.Configs;

namespace Order.DataAccessLayers.Context
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options):base(options)
        {
        }
        public DbSet<Domains.Orders.Entities.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfig).Assembly);
        }
    }
}

