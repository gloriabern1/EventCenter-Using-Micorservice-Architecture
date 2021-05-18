using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.web.Models.ServiceModels
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid EventId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
        public Events Event { get; set; }
    }
}
