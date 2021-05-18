using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.web.Models.ServiceModels
{
    public class BasketLineUpdate
    {
        [Required]
        public int TicketAmount { get; set; }s
    }
}
