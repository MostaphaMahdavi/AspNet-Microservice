using System;
using MediatR;
using Order.Domains.Orders.Repositories;
using Order.Repositories.Orders.Impliments;
using Order.ServicesMappings;

using Order.Services.Orders.Commands.Create;
using Order.DataAccessLayers.Context;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Reflection;
using Order.Services.Behaviours;
using aspnetrun_microservice.Frameworks.Implimentations;
using aspnetrun_microservice.Frameworks.Interfaces;

namespace Order.Api.Extensions
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();
            services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddMediatR(typeof(CreateOrderCommand).Assembly);

            services.AddScoped<IEmailService, EmailService>();
         
        }



        public static void AddDbContextExt(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(option => {
                option.UseSqlServer(configuration["ConnectionStrings:OrderConnection"]);
            });
        }

    
    }
}

