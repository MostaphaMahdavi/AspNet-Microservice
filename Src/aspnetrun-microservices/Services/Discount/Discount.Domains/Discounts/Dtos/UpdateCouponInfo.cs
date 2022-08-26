namespace Discount.Domains.Discounts.Dtos
{
    public class UpdateCouponInfo
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

    }
}

