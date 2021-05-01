using GloriaEvents.Services.EventRecords.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventComponent.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Events>> GetEvents(Guid Categoryid);
        Task<Events> GetEventbyId(Guid EventId);
        Task<IEnumerable<Events>> GetAllEvents();
    }
}
