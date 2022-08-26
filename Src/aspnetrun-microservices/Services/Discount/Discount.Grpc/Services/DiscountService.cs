using System;
using AutoMapper;
using Discount.Services.Discounts.Commands.Create;
using Discount.Services.Discounts.Commands.Delete;
using Discount.Services.Discounts.Commands.DeleteDiscountByProductName;
using Discount.Services.Discounts.Commands.Update;
using Discount.Services.Discounts.Queris.GettByProductNameDiscounQuery;
using Grpc.Core;
using MediatR;
namespace Discount.Grpc.Services
{
    public class DiscountService: DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DiscountService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
          var coupon=  await _mediator.Send(new GetByProductNameDiscountQuery
            {
                productName = request.ProductName
            }) ;
            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound,$"Discount {request.ProductName} is not found"));
            }

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _mediator.Send(new CreateDiscountCommand
            {
                ProductName=request.Coupon.ProductName,
                Amount=request.Coupon.Amount,
                Description=request.Coupon.Description
            });
            if (!coupon)
            {
                throw new RpcException(new Status(StatusCode.Aborted, $"Discountis not create"));
            }

            return request.Coupon;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var guidParser = Guid.TryParse(request.Coupon.Id, out Guid id);
            if (!guidParser)
            {
                throw new RpcException(new Status(StatusCode.Aborted, $"Id *{request.Coupon.Id}* is not valid!"));
            }
                   var coupon = await _mediator.Send(new UpdateDiscountCommand
                   {
                       Id=id,
                       ProductName = request.Coupon.ProductName,
                       Amount = request.Coupon.Amount,
                       Description = request.Coupon.Description
                   });
            if (!coupon)
            {
                throw new RpcException(new Status(StatusCode.Aborted, $"Discount did not updated"));
            }

            return request.Coupon;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var isDelete = await _mediator.Send(new DeleteDiscountByProductName { ProductName=request.ProductName });
        
            return new DeleteDiscountResponse {Success=isDelete };
        }

    }
}

