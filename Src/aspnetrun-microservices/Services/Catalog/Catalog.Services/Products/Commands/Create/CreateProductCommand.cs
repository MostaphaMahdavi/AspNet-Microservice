using System;
using Catalog.Domains.Products.Dtos;
using Catalog.Domains.Products.Entities;
using Catalog.Domains.Products.Repositories;
using MediatR;

namespace Catalog.Services.Products.Commands.Create
{
    public class CreateProductCommand:CreateProductInfo, IRequest<bool>
    {
      
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {

       private readonly IProductCommandRepository _command;

        public CreateProductCommandHandler(IProductCommandRepository command)
        {
            _command = command;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product { Name = request.Name, ImageFile = request.ImageFile, Price = request.Price, Category = request.Category, Description = request.Description, Summary = request.Summary };
            await _command.CreateProduct(product);
            return true;
        }
    }
}

;