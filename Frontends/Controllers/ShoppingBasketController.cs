using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloriaEvent.web.Extensions;
using GloriaEvent.web.Models;
using GloriaEvent.web.Models.ServiceModels;
using GloriaEvent.web.Models.ViewModels;
using GloriaEvent.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GloriaEvent.web.Controllers
{
    public class ShoppingBasketController : Controller
    {
        private readonly IShoppingBasketComponentService basketService;
       // private readonly IBus bus;
        private readonly Settings settings;

        public ShoppingBasketController(IShoppingBasketComponentService basketService, Settings settings)
        {
            this.basketService = basketService;
            //this.bus = bus;
            this.settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var basketLines = await basketService.GetLinesForBasket(Request.Cookies.GetCurrentBasketId(settings));
            var lineViewModels = basketLines.Select(bl => new BasketLineViewModel
            {
                LineId = bl.BasketLineId,
                EventId = bl.EventId,
                EventName = bl.Event.Name,
                Date = bl.Event.Date,
                Price = bl.Price,
                Quantity = bl.TicketAmount
            }
            );
            return View(lineViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLine(BasketLineCreation basketLine)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            var newLine = await basketService.AddToBasket(basketId, basketLine);
            Response.Cookies.Append(settings.BasketIdCookieName, newLine.BasketId.ToString());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLine(BasketLineUpdate basketLineUpdate)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            await basketService.UpdateLine(basketId, basketLineUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveLine(Guid lineId)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(settings);
            await basketService.RemoveLine(basketId, lineId);
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Pay()
        //{
        //    var basketId = Request.Cookies.GetCurrentBasketId(settings);
        //    await bus.Send(new PaymentRequestMessage { BasketId = basketId });
        //    return View("Thanks");
        //}
    }
}