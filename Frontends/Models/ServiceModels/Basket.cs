using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.web.Models.ServiceModels
{
    public class Basket
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public int NumberOfItems { get; set; }
    }
}
