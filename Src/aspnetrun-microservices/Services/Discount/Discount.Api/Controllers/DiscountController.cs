using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Discount.Services.Discounts.Queris.GetAll;
using Discount.Services.Discounts.Queris.GetById;
using Discount.Services.Discounts.Queris.GettByProductNameDiscounQuery;
using Discount.Services.Discounts.Commands.Create;
using Discount.Services.Discounts.Commands.Update;
using Discount.Services.Discounts.Commands.Delete;
using aspnetrun_microservice.Frameworks.Common;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Discount.Api.Controllers
{

    public class DiscountController : BaseController
    {
        IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDiscount()
        {
            var products = await _mediator.Send(new GetAllDiscountQuery());
            return Ok(products);
        }


        [HttpGet("[action]{id}")]
        public async Task<IActionResult> GetDiscountById(Guid id)
        {
            return Ok(await _mediator.Send(new GetByIdDiscountQuery {Id=id }));
        }


        [HttpGet("[action]/productName")]
        public async Task<IActionResult> GetDiscountByProductName(string productName)
        {
            return Ok(await _mediator.Send(new GetByProductNameDiscountQuery { productName=productName}));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveDiscount(CreateDiscountCommand create)
        {
            return Ok(await _mediator.Send(create));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountCommand update)
        {
            return Ok(await _mediator.Send(update));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSiscount(DeleteDiscountCommand delete)
        {
            return Ok(await _mediator.Send(delete));
        }
    }
}

