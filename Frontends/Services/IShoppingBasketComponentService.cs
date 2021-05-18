using GloriaEvent.web.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.web.Services
{
    public interface IShoppingBasketComponentService
    {
        Task<BasketLine> AddToBasket(Guid basketId, BasketLineCreation basketLine);
        Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId);
        Task<Basket> GetBasket(Guid basketId);
        Task UpdateLine(Guid basketId, BasketLineUpdate basketLineForUpdate);
        Task RemoveLine(Guid basketId, Guid lineId);
    }
}
