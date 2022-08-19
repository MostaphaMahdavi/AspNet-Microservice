using System;
using Catalog.DataAccessLayers.Context;
using Catalog.Domains.Products.Repositories;
using Catalog.Repositories.Products.Impliments;
using Catalog.Services.Products.Commands.Create;
using MediatR;

namespace Catalog.Api.Extensions
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();




            services.AddSingleton<ICatalogContext, CatalogContext>();
        }


        public static void AddMediatRRegistry(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateProductCommand).Assembly);
        }
    }
}

