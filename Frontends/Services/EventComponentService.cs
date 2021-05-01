using GloriaEvent.web.Extensions;
using GloriaEvent.web.Models;
using GloriaEvent.web.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GloriaEvent.web.Services
{
    public class EventComponentService : IEventComponentService
    {
        private readonly HttpClient _client;
        private readonly Settings _settings;
        public EventComponentService(HttpClient client, Settings settings)
        {
            _client = client;
            _settings = settings;
        }

        public async Task<IEnumerable<Events>> GetAll()
        {
            var response = await _client.GetAsync("/api/events/GetAllEvents");
            return await response.ReadContentAs<List<Events>>();

        }
        public async Task<IEnumerable<Categories>> GetAllCategories()
        {
            var response = await _client.GetAsync("api/categories/Get");
            return await response.ReadContentAs<List<Categories>>();

        }
        public async Task<IEnumerable<Events>> GetEventsByCategoryId(Guid CategoryId)
        {
            var response = await _client.GetAsync($"/api/events/Get?CategoryId={CategoryId}");
            return await response.ReadContentAs<List<Events>>();

        }
    }
}
