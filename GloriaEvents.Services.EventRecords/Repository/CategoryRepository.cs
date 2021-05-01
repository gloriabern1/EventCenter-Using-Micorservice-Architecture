using GloriaEvents.Services.EventRecords.DbContexts;
using GloriaEvents.Services.EventRecords.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventComponent.Repository
{
    public class CategoryRepository : BaseRepository<Categorys>, ICategoryRepository
    {
        private readonly EventsContext _eventsContext;
        public CategoryRepository(EventsContext eventsContext) : base(eventsContext)
        {
            _eventsContext = eventsContext;
        }

        public async Task<IEnumerable<Categorys>> GetAllCategories()
        {
            return await this.GetAll();
        }
    }
    }
