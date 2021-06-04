using GloriaEvent.web.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.web.Services
{
    public interface IEventComponentService
    {
        Task<IEnumerable<Events>> GetAll();
        Task<IEnumerable<Categories>> GetAllCategories();
        Task<Events> GetEvent(Guid id);
        Task<IEnumerable<Events>> GetEventsByCategoryId(Guid CategoryId);
    }
}
