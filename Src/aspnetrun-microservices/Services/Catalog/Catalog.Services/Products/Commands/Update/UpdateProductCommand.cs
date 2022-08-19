using System;
using Catalog.Domains.Products.Dtos;
using Catalog.Domains.Products.Entities;
using Catalog.Domains.Products.Repositories;
using MediatR;

namespace Catalog.Services.Products.Commands.Update
{
    public class UpdateProductCommand: UpdateProductInfo, IRequest<bool>
    {
        
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductCommandRepository _command;
        private readonly IProductQueryRepository _query;

        public UpdateProductCommandHandler(IProductCommandRepository command, IProductQueryRepository query)
        {
            _command = command;
            _query = query;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _query.GetProductById(request.Id) is null)
                return false;


            Product product = new Product { Name = request.Name, ImageFile = request.ImageFile, Price = request.Price, Category = request.Category, Description = request.Description, Summary = request.Summary };
            product.Id = request.Id; 
           return await _command.UpdateProduct(product);
        }
    }
}

