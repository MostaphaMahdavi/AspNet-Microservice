using System;
using Discount.DataAccessLayers.Context;
using Discount.Domains.Discounts.Repositories;
using Discount.Repositories.Discounts.Impliments;
using Discount.Services.Discounts.Commands.Create;
using Discount.Services.Discounts.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Discount.Api.Extensions
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IDiscountQueryRepository, DiscountQueryRepository>();
            services.AddScoped<IDiscountCommandRepository, DiscountCommandRepository>();



            services.AddMediatR(typeof(CreateDiscountCommand).Assembly);

            services.AddAutoMapper(typeof(DicountMapper).Assembly);
        }

        public static void DatabaseExtention(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DiscountContext>(option =>
            {
                option.UseNpgsql(configuration["ConnectionStrings:DiscountContext"]);
            });
        }
    }
}

