
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Catalog.Services.Products.Queries.GetAll;
using Catalog.Domains.Products.Entities;
using Catalog.Services.Products.Queries.GetById;
using Catalog.Services.Products.Queries.GetByName;
using Catalog.Services.Products.Queries.GetByCategoryId;
using Catalog.Services.Products.Commands.Create;
using Catalog.Services.Products.Commands.Update;
using Catalog.Services.Products.Commands.Delete;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog.Api.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
       private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetAllProductQuery());
            return Ok(products);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _mediator.Send(new GetProductByNameQuery() { Name = name });
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("[action]/{categoryName}")]
        public async Task<IActionResult> GetProductByCategoryName(string categoryName)
        {
            var product = await _mediator.Send(new GetProductByCategoryNameQuery() { CategoryName = categoryName });
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> InsertProduct(CreateProductCommand insertProductCommand)
        {
            return Ok(await _mediator.Send(insertProductCommand));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            return Ok(await _mediator.Send(updateProductCommand));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand deleteProductCommand)
        {
            return Ok(await _mediator.Send(deleteProductCommand));
        }
    }
}

