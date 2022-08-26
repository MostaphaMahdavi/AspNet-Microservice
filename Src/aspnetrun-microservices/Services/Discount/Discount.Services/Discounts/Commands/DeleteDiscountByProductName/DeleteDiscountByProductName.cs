using System;
using Discount.Domains.Discounts.Repositories;
using MediatR;

namespace Discount.Services.Discounts.Commands.DeleteDiscountByProductName
{
    public class DeleteDiscountByProductName:IRequest<bool>
    {
        public string ProductName { get; set; }
    }

    public class DeleteDiscountByProductNameHandler : IRequestHandler<DeleteDiscountByProductName, bool>
    {
        private readonly IDiscountCommandRepository _discountCommandRepository;
        private readonly IDiscountQueryRepository _discountQueryRepository;

        public DeleteDiscountByProductNameHandler(IDiscountCommandRepository discountCommandRepository,
            IDiscountQueryRepository discountQueryRepository)
        {
            _discountCommandRepository = discountCommandRepository;
            _discountQueryRepository = discountQueryRepository;
        }

        public async Task<bool> Handle(DeleteDiscountByProductName request, CancellationToken cancellationToken)
        {
            var coupon = await _discountQueryRepository.GetDiscountByProductName(request.ProductName);
            if (coupon is null)
            {
                throw new Exception($"{request.ProductName} یافت نشد.");
            }

            return await _discountCommandRepository.DeleteDiscount(coupon);
        }
    }
}

