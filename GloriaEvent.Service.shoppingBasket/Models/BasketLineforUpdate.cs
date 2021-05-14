using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.Models
{
    public class BasketLineforUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
