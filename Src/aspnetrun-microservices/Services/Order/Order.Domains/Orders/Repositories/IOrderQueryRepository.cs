using System;
namespace Order.Domains.Orders.Repositories
{
    public interface IOrderQueryRepository
    {

        Task<IEnumerable<Entities.Order>> GetAllOrder();
        Task<Entities.Order> GetOrderById(Guid orderId);
        Task<IEnumerable<Entities.Order>> GetOrderByUserName(string userName);
    }
}

