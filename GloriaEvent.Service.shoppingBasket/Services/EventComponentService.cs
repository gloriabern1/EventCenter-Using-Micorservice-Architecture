using GloriaEvent.Service.shoppingBasket.Entities;
using GloriaEvent.Service.shoppingBasket.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.Services
{
    public class EventComponentService : IEventComponentService
    {
        private readonly HttpClient client;

        public EventComponentService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await client.GetAsync($"/api/events/{id}");
            return await response.ReadContentAs<Event>();
        }
    }
}
