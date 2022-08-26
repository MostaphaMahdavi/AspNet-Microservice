using Discount.Domains.Discounts.Entities;

namespace Discount.Domains.Discounts.Repositories
{
    public interface IDiscountQueryRepository
    {
        Task<IEnumerable<Coupon>> GetAllDiscount();
        Task<Coupon> GetDiscountByProductName(string productName);
        Task<Coupon> GetDiscountById(Guid id);
    }
}

