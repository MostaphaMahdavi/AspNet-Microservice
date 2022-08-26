using System;
using AutoMapper;
using Discount.Domains.Discounts.Dtos;
using Discount.Domains.Discounts.Entities;
using Discount.Domains.Discounts.Repositories;
using MediatR;

namespace Discount.Services.Discounts.Commands.Update
{
    public class UpdateDiscountCommand: UpdateCouponInfo,IRequest<bool>
    {
       
    }

    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, bool>
    {

        private readonly IDiscountCommandRepository _discountCommandRepository;
        private readonly IDiscountQueryRepository _discountQueryRepository;
        private readonly IMapper _mapper;

        public UpdateDiscountCommandHandler(IDiscountCommandRepository discountCommandRepository,
            IDiscountQueryRepository discountQueryRepository, IMapper mapper)
        {
            _discountCommandRepository = discountCommandRepository;
            _discountQueryRepository = discountQueryRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _discountQueryRepository.GetDiscountById(request.Id);
            if (coupon is null)
            {
                throw new Exception($"{request.Id } {request?.ProductName?? ""} یافت نشد.");
            }
           return await _discountCommandRepository.UpdateDiscount(_mapper.Map<Coupon>(request));
        }
    }
}

