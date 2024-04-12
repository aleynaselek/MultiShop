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
    public class UpdateOrderingCommandHandler
    {
        private readonly IRepository<Ordering> _repository;
        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderingId);
            values.UserId = command.UserId;
            values.TotalPrice = command.TotalPrice;
            values.OrderDate = command.OrderDate; 
            await _repository.UpdateAsync(values);          

        }
    }
}
