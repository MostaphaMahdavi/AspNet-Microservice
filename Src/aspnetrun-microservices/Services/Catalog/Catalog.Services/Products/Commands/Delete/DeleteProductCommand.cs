using System;
using Catalog.Domains.Products.Repositories;
using MediatR;

namespace Catalog.Services.Products.Commands.Delete
{
    public class DeleteProductCommand:IRequest<bool>
    {
        public string Id { get; set; }
       
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductCommandRepository _command;

        public DeleteProductCommandHandler(IProductCommandRepository command)
        {
            _command = command;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)=>
        
            await _command.DeleteProduct(request.Id);
        
    }
}

