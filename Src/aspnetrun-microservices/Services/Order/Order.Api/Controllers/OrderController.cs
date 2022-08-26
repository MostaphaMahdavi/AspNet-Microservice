using aspnetrun_microservice.Frameworks.Common;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Order.Services.Orders.Queries.GetAll;
using Order.Services.Orders.Queries.GetByUserName;
using Order.Services.Orders.Queries.GetById;
using Order.Services.Orders.Commands.Create;
using Order.Services.Orders.Commands.Update;
using Order.Services.Orders.Commands.Delete;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order.Api.Controllers
{
    public class OrderController : BaseController
    {
        IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrder()
        {
            var orders = await _mediator.Send(new GetAllOrderQuery());
            return Ok(orders);
        }

        [HttpGet("[action]/{userName}")]
        public async Task<IActionResult> GetOrderByUserName(string userName) 
        {
            var orders = await _mediator.Send(new GetByUserNameOrderQuery { UserName=userName});
            return Ok(orders);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _mediator.Send(new GetByIdOrderQuery
            {
                Id=id
            });
            return Ok(order);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertOrder(CreateOrderCommand request)
        {
            var order = await _mediator.Send(request);
            return Ok(order);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand request)
        {
            var isUpdate = await _mediator.Send(request);
            return Ok(isUpdate);
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var isDelete = await _mediator.Send(new DeleteOrderCommand { Id=id});
            return Ok(isDelete);
        }


    }
}

