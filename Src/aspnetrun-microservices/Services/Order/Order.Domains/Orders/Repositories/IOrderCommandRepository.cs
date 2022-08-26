using System;
namespace Order.Domains.Orders.Repositories
{
    public interface IOrderCommandRepository
    {
        Task<Entities.Order> CreateOrder(Entities.Order order);
        Task<bool> UpdateOrder(Entities.Order order);
        Task<bool> DeleteOrder(Entities.Order order);
       
    }
}

