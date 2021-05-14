using GloriaEvent.Service.shoppingBasket.DbContexts;
using GloriaEvent.Service.shoppingBasket.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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


        public async Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId)
        {
            return await this.GetQueryable(x=>x.BasketId==basketId).Include("Event").ToListAsync();
           
        }

        public async Task<BasketLine> GetBasketLineById(Guid basketLineId)
        {
            return await this.GetQueryable(x=>x.BasketLineId==basketLineId).Include("Event").FirstOrDefaultAsync();
        }

        public async Task<BasketLine> AddOrUpdateBasketLine(Guid basketId, BasketLine basketLine)
        {
            var existingLine = await GetQueryable(x=>x.BasketId==basketId && x.EventId==basketLine.EventId).Include("Event").FirstOrDefaultAsync();
            if (existingLine == null)
            {
                basketLine.BasketId = basketId;
                await this.Insert(basketLine);
                return basketLine;
            }
            existingLine.TicketAmount += basketLine.TicketAmount;
            return existingLine;
        }

        public void UpdateBasketLine(BasketLine basketLine)
        {
            // empty on purpose
        }

        public async void RemoveBasketLine(BasketLine basketLine)
        {
           await this.Delete(basketLine);
        }

    
        public async Task<bool> SaveChanges()
        {

            return (await this.SaveChangesasync() > 0);
        }
    }


}
