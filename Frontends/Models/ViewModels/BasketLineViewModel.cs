using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.web.Models.ViewModels
{
    public class BasketLineViewModel
    {
        public Guid LineId { get; set; }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public DateTimeOffset Date { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
