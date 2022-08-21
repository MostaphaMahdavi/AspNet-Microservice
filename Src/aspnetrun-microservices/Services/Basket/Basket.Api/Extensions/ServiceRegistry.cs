using System;
using Basket.Domain.Baskets.Repositories;
using Basket.Domain.Baskets.Services;
using Basket.Repositories.Baskets.Impliments;
using Basket.Services.Baskets.Impliments;

namespace Basket.Api.Extensions
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketService, BasketService>();
        }


        public static void AddRedis(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = configuration["CacheSettings:RedisConnection"];
            });
        }
  
    }
}

