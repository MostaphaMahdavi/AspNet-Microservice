using System;
using AutoMapper;
using Discount.Domains.Discounts.Dtos;
using Discount.Domains.Discounts.Entities;
using Discount.Domains.Discounts.Repositories;
using MediatR;

namespace Discount.Services.Discounts.Queris.GetAll
{
    public class GetAllDiscountQuery:IRequest<IEnumerable<CouponInfo>>
    {
       
    }

    public class GetAllDiscountQueryHandler : IRequestHandler<GetAllDiscountQuery, IEnumerable<CouponInfo>>
    {
        private readonly IDiscountQueryRepository _discountQueryRepository;
        private readonly IMapper _mapper;
        public GetAllDiscountQueryHandler(IDiscountQueryRepository discountQueryRepository , IMapper mapper )
        {
            _discountQueryRepository = discountQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CouponInfo>> Handle(GetAllDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupons = await _discountQueryRepository.GetAllDiscount();
            return _mapper.Map<IEnumerable<CouponInfo>>(coupons);
        }
    }
}

