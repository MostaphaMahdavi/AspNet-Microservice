using System;
using AutoMapper;
using Discount.Domains.Discounts.Dtos;
using Discount.Domains.Discounts.Entities;
using Discount.Domains.Discounts.Repositories;
using MediatR;

namespace Discount.Services.Discounts.Commands.Create
{
    public class CreateDiscountCommand: CreateCouponInfo, IRequest<bool>
    {
        public CreateDiscountCommand()
        {
        }
    }

    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, bool>
    {
       private readonly IDiscountCommandRepository _discountCommandRepository;
       private readonly IMapper _mapper;

        public CreateDiscountCommandHandler(IDiscountCommandRepository discountCommandRepository, IMapper mapper)
        {
            _discountCommandRepository = discountCommandRepository;
            _mapper = mapper;
        }

       
        
        public async Task<bool> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)=>        
             await _discountCommandRepository.CreateDiscount(_mapper.Map<Coupon>(request));
        
    }
}

