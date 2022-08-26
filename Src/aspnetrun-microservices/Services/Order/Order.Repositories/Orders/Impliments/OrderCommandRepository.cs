using System;
using Order.DataAccessLayers.Context;
using Order.Domains.Orders.Repositories;

namespace Order.Repositories.Orders.Impliments
{
    public class OrderCommandRepository: IOrderCommandRepository
    {
       private readonly OrderContext _db;

        public OrderCommandRepository(OrderContext db)
        {
            _db = db;
        }

       
        public async Task<Domains.Orders.Entities.Order> CreateOrder(Domains.Orders.Entities.Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrder(Domains.Orders.Entities.Order order)
        {
             _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return true;
        }

       

        public async Task<bool> UpdateOrder(Domains.Orders.Entities.Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

