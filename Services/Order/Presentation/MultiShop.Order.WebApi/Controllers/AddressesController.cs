using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingesController : ControllerBase
    {
        private readonly GetOrderingQueryHandler _getOrderingQueryHandler;
        private readonly GetOrderingByIdQueryHandler _getOrderingByIdQueryHandler;
        private readonly CreateOrderingCommandHandler _createOrderingCommandHandler;
        private readonly RemoveOrderingCommandHandler _removeOrderingCommandHandler;
        private readonly UpdateOrderingCommandHandler _updateOrderingCommandHandler;


        public OrderingesController(GetOrderingQueryHandler getOrderingQueryHandler, GetOrderingByIdQueryHandler getOrderingByIdQueryHandler, CreateOrderingCommandHandler createOrderingCommandHandler, RemoveOrderingCommandHandler removeOrderingCommandHandler, UpdateOrderingCommandHandler updateOrderingCommandHandler)
        {
            _getOrderingByIdQueryHandler = getOrderingByIdQueryHandler;
            _getOrderingQueryHandler = getOrderingQueryHandler;
            _createOrderingCommandHandler = createOrderingCommandHandler;
            _removeOrderingCommandHandler = removeOrderingCommandHandler;
            _updateOrderingCommandHandler = updateOrderingCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _getOrderingQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderingListById(int id)
        {
            var value = await _getOrderingByIdQueryHandler.Handle(new GetOrderingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _createOrderingCommandHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _updateOrderingCommandHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla güncellendi.");
        }

        [HttpDelete]    
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _removeOrderingCommandHandler.Handle(new RemoveOrderingCommand(id));
            return Ok("Adres bilgisi başarıyla silindi.");
        }
    }
}
