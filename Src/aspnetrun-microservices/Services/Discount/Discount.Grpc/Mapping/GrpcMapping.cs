using System;
using AutoMapper;
using Discount.Domains.Discounts.Dtos;
using Discount.Domains.Discounts.Entities;

namespace Discount.Grpc.Mapping
{
    public class GrpcMapping:Profile
    {
        public GrpcMapping()
        {
            CreateMap<CouponModel,Coupon>().ReverseMap();
            CreateMap<CouponModel, CouponInfo>().ReverseMap();
        }
    }
}

