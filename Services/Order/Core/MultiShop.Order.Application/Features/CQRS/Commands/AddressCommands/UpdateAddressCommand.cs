﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands
{
    public class UpdateOrderingCommand    
    {

        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Detail { get; set; }
    }
}