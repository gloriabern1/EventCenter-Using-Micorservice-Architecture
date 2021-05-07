using GloriaEvent.Service.shoppingBasket.DbContexts;
using GloriaEvent.Service.shoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.Repository
{
    public class BasketLineRepository : BaseRepository<BasketLine>, IBasketLineRepository
    {
        private readonly BasketDbContext _basketContext;
        public BasketLineRepository(BasketDbContext basketContext) : base(basketContext)
        {
            _basketContext = basketContext;
        }
    }
}
