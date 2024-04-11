using MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler
    {
        private readonly IRepository<Ordering> _repository;
        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderingCommand createOrderingCommand)
        {
            await _repository.CreateAsync( new Ordering
            {
                UserId = createOrderingCommand.UserId,
                City = createOrderingCommand.City,
                District = createOrderingCommand.District,
                Detail = createOrderingCommand.Detail
            });

        }
    }
}
