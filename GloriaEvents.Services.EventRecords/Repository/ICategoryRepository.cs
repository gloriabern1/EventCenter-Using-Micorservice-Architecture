using GloriaEvents.Services.EventRecords.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventComponent.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Categorys>> GetAllCategories();

    }
}
