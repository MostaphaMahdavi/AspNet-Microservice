using System;
using AutoMapper;
using Discount.Domains.Discounts.Dtos;
using Discount.Domains.Discounts.Entities;

namespace Discount.Services.Discounts.Mapping
{
    public class DicountMapper:Profile
    {
        public DicountMapper()
        {
            CreateMap<Coupon, CouponInfo>().ForMember(s => s.CouponFUllData, d =>d.MapFrom(opt=>$"{opt.ProductName }({opt.Id}) - {opt.Amount}")).ReverseMap();

            CreateMap<Coupon, CreateCouponInfo>().ReverseMap();

            CreateMap<Coupon,UpdateCouponInfo>().ReverseMap();

        }
    }
}

