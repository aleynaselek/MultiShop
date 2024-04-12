using MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler
    {
        private readonly IRepository<Ordering> _repository;
        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle()
        {
            var values  = await _repository.GetAllAsync();
            return values.Select(x=>new GetOrderingQueryResult
            {
                OrderingId = x.OrderingId,
                UserId = x.UserId,
                TotalPrice = x.TotalPrice,
                OrderDate = x.OrderDate
            }).ToList();

        }
    }
}
