using GloriaEvent.Service.shoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.Repository
{
    public interface IEventRepository
    {
        Task<Event> GetEventbyId(Guid EventId);
        Task<IEnumerable<Event>> GetAllEvents();
        Task<bool> SaveChanges();
        void AddEvent(Event theEvent);
        Task<bool> EventExists(Guid eventId);
    }
}
