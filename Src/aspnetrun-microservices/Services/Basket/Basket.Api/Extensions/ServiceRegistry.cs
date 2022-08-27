using System;
using Basket.Api.GrpcService;
using Basket.Domain.Baskets.Repositories;
using Basket.Domain.Baskets.Services;
using Basket.Repositories.Baskets.Impliments;
using Basket.Services.Baskets.Impliments;
using Basket.Services.Baskets.Mappings;


using Eventbus.Messages.Events;
using MassTransit;

namespace Basket.Api.Extensions
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketService, BasketService>();


            services.AddAutoMapper(typeof(MappingProfile).Assembly);
           
        }


        public static void AddRedis(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = configuration["CacheSettings:RedisConnection"];
            });
        }

        /*
        public static void AddGrpcExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(o => o.Address = new Uri(
               configuration["GrpcSettings:DiscountUrl"]
                ));

            services.AddScoped<DiscountGrpcService>();
        }
        */
        public static void AddMessagingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                  //  cfg.UseHealthCheck(ctx);
                });

                x.AddConsumers(typeof(BaseEvent).Assembly);
            });
            services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    options.WaitUntilStarted = true;
                    options.StartTimeout = TimeSpan.FromSeconds(10);
                    options.StopTimeout = TimeSpan.FromSeconds(30);
                });


        }


    }
}

