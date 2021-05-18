using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.web.Models.ServiceModels
{
    public class BasketCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
