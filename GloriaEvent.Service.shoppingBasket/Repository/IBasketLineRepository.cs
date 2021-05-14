using GloriaEvent.Service.shoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.Repository
{
    public interface IBasketLineRepository
    {
        Task<BasketLine> AddOrUpdateBasketLine(Guid basketId, BasketLine basketLine);
        Task<BasketLine> GetBasketLineById(Guid basketLineId);
        Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId);
        void RemoveBasketLine(BasketLine basketLine);
        Task<bool> SaveChanges();
    }

}
