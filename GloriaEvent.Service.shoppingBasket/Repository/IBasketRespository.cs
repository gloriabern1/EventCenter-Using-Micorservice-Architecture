using GloriaEvent.Service.shoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.Repository
{
    public interface IBasketRespository
    {
        Task<Basket> GetBasketbyId(Guid BasketId);
        Task<bool> BasketExists(Guid basketId);

        void AddBasket(Basket basket);

        Task<bool> SaveChanges();
    }
}
