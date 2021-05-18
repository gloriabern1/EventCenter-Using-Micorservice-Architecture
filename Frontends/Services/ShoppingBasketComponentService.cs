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
    public class ShoppingBasketComponentService : IShoppingBasketComponentService
    {
        private readonly HttpClient client;
        private readonly Settings settings;

        public ShoppingBasketComponentService(HttpClient client, Settings settings)
        {
            this.client = client;
            this.settings = settings;
        }

        public async Task<BasketLine> AddToBasket(Guid basketId, BasketLineCreation basketLine)
        {
            if (basketId == Guid.Empty)
            {
                var basketResponse = await client.PostAsJson("/api/baskets", new BasketCreation { UserId = settings.UserId });
                var basket = await basketResponse.ReadContentAs<Basket>();
                basketId = basket.BasketId;
            }

            var response = await client.PostAsJson($"api/baskets/{basketId}/basketlines", basketLine);
            return await response.ReadContentAs<BasketLine>();
        }

        public async Task<Basket> GetBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return null;
            var response = await client.GetAsync($"/api/baskets/{basketId}");
            return await response.ReadContentAs<Basket>();
        }

        public async Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return new BasketLine[0];
            var response = await client.GetAsync($"/api/baskets/{basketId}/basketLines");
            return await response.ReadContentAs<BasketLine[]>();

        }

        public async Task UpdateLine(Guid basketId, BasketLineUpdate basketLineForUpdate)
        {
            await client.PutAsJson($"/api/baskets/{basketId}/basketLines/{basketLineForUpdate.LineId}", basketLineForUpdate);
        }

        public async Task RemoveLine(Guid basketId, Guid lineId)
        {
            await client.DeleteAsync($"/api/baskets/{basketId}/basketLines/{lineId}");
        }
    }
}
