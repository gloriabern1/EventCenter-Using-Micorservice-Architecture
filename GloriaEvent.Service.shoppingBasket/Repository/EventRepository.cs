using GloriaEvent.Service.shoppingBasket.DbContexts;
using GloriaEvent.Service.shoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly BasketDbContext _basketContext;
        public EventRepository(BasketDbContext basketContext) : base(basketContext)
        {
            _basketContext = basketContext;
        }

        public async Task<Event> GetEventbyId(Guid EventId)
        {
            return await this.GetById(EventId);
        }

      
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await this.GetAll();
        }
    }
}
