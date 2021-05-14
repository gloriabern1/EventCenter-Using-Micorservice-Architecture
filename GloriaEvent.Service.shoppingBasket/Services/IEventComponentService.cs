using GloriaEvent.Service.shoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.Services
{
    public interface IEventComponentService
    {
        Task<Event> GetEvent(Guid id);
    }
}
