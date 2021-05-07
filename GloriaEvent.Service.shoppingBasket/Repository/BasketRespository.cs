using GloriaEvent.Service.shoppingBasket.DbContexts;
using GloriaEvent.Service.shoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvent.Service.shoppingBasket.Repository
{
    public class BasketRespository : BaseRepository<Basket>, IBasketRespository
    {
        private readonly BasketDbContext _basketContext;
        public BasketRespository(BasketDbContext basketContext) : base(basketContext)
        {
            _basketContext = basketContext;
        }

        public async Task<Basket> GetBasketbyId(Guid BasketId)
        {
            return await this.GetById(BasketId);
        }

        public async Task<bool> BasketExists(Guid basketId)
        {
            return await this.Any(b => b.BasketId == basketId);
        }

        public async void AddBasket(Basket basket)
        {
           await  this.Insert(basket);
        }

        public async Task<bool> SaveChanges()
        {
            
            return (await this.SaveChangesasync() > 0);
        }
    }
}
