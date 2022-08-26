using System;
using AutoMapper;
using Discount.Domains.Discounts.Dtos;
using Discount.Domains.Discounts.Repositories;
using MediatR;

namespace Discount.Services.Discounts.Queris.GettByProductNameDiscounQuery
{
    public class GetByProductNameDiscountQuery:IRequest<CouponInfo>
    {
        public string productName { get; set; }     
    }

    public class GetByProductNameDiscountQueryHandler : IRequestHandler<GetByProductNameDiscountQuery, CouponInfo>
    {
       private readonly IDiscountQueryRepository _discountQueryRepository;
       private readonly IMapper _mapper;

        public GetByProductNameDiscountQueryHandler(IDiscountQueryRepository discountQueryRepository, IMapper mapper)
        {
            _discountQueryRepository = discountQueryRepository;
            _mapper = mapper;
        }


        public async Task<CouponInfo> Handle(GetByProductNameDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _discountQueryRepository.GetDiscountByProductName(request.productName);
            return _mapper.Map<CouponInfo>(coupon);
        }


    }
}

