using System;
using Microsoft.EntityFrameworkCore;
using Order.DataAccessLayers.Context;
using Order.Domains.Orders.Repositories;

namespace Order.Repositories.Orders.Impliments
{
    public class OrderQueryRepository: IOrderQueryRepository
    {

        OrderContext _db;

        public OrderQueryRepository(OrderContext db)
        {
            _db = db;
        }
    

        public async Task<IEnumerable<Domains.Orders.Entities.Order>> GetAllOrder()=>        
            await _db.Orders.ToListAsync();


        public async Task<Domains.Orders.Entities.Order> GetOrderById(Guid orderId) =>
            await _db.Orders.FirstOrDefaultAsync(o=>o.Id==orderId);

        public async Task<IEnumerable<Domains.Orders.Entities.Order>> GetOrderByUserName(string userName) =>
            await _db.Orders.Where(o => o.UserName.ToLower() == userName.ToLower()).ToListAsync();
    }
}

