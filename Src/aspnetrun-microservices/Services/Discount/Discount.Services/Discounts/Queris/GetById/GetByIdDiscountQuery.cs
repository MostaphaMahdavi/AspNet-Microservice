using System;
using AutoMapper;
using Discount.Domains.Discounts.Dtos;
using Discount.Domains.Discounts.Repositories;
using MediatR;

namespace Discount.Services.Discounts.Queris.GetById
{
    public class GetByIdDiscountQuery:IRequest<CouponInfo>
    {
        public Guid Id { get; set; }
        
    }

    public class GetByIdDiscountQueryHandler : IRequestHandler<GetByIdDiscountQuery, CouponInfo>
    {
       private readonly IDiscountQueryRepository _discountQueryRepository;
       private readonly IMapper _mapper;

        public GetByIdDiscountQueryHandler(IDiscountQueryRepository discountQueryRepository, IMapper mapper )
        {
            _discountQueryRepository = discountQueryRepository;
            _mapper = mapper;
        }

        public async Task<CouponInfo> Handle(GetByIdDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _discountQueryRepository.GetDiscountById(request.Id);
            return _mapper.Map<CouponInfo>(coupon);
        }
    }
}

