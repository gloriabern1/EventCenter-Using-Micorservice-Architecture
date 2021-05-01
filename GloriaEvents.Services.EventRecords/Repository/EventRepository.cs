using GloriaEvents.Services.EventRecords.DbContexts;
using GloriaEvents.Services.EventRecords.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventComponent.Repository
{
    public class EventRepository : BaseRepository<Events>, IEventRepository
    {
        private readonly EventsContext _eventsContext;
        public EventRepository(EventsContext eventsContext) : base(eventsContext)
        {
            _eventsContext = eventsContext;
        }

        public async Task<Events> GetEventbyId(Guid EventId)
        {
            return await this.GetById(EventId);
        }

        public async Task<IEnumerable<Events>> GetEvents(Guid categoryid)
        {
            return await this.GetQueryable(x => x.CategoryId == categoryid).Include(x=>x.Category).ToListAsync();
        }
        public async Task<IEnumerable<Events>> GetAllEvents()
        {
            return await this.GetAll();
        }
    }
}
