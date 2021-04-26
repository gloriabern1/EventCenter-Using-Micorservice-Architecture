using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventRecords.Entities
{
    public class Categorys
    {
        [Required]
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public List<Events> Events { get; set; }
    }
}
