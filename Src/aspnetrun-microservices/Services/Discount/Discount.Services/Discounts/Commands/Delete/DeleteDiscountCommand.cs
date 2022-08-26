using System;
using AutoMapper;
using Discount.Domains.Discounts.Dtos;
using Discount.Domains.Discounts.Repositories;
using MediatR;

namespace Discount.Services.Discounts.Commands.Delete
{
    public class DeleteDiscountCommand:DeleteCouponInfo,IRequest<bool>
    {
       
    }


    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand,bool>
    {
        private readonly IDiscountCommandRepository _discountCommandRepository;
        private readonly IDiscountQueryRepository _discountQueryRepository;       

        public DeleteDiscountCommandHandler(IDiscountCommandRepository discountCommandRepository,
            IDiscountQueryRepository discountQueryRepository)
        {
            _discountCommandRepository = discountCommandRepository;
            _discountQueryRepository = discountQueryRepository;           
        }

        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _discountQueryRepository.GetDiscountById(request.Id);
            if (coupon is null)
            {
                throw new Exception($"{request.Id} یافت نشد.");
            }

           return await _discountCommandRepository.DeleteDiscount(coupon);
        }
    }
}

