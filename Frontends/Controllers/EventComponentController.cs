using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloriaEvent.Grpc;
using GloriaEvent.web.Models.ViewModels;
using GloriaEvent.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GloriaEvent.web.Controllers
{
    public class EventComponentController : Controller
    {
        private readonly IEventComponentService _eventComponentService;
        private readonly Events.EventsClient eventComponentGRPSService;

        public EventComponentController(IEventComponentService eventComponentService, Events.EventsClient eventComponentGRPSService)
        {
            _eventComponentService = eventComponentService;
            this.eventComponentGRPSService= eventComponentGRPSService;
        }
        //public async Task<IActionResult> Index(Guid categoryId)
        //{
        //    var getcategories = _eventComponentService.GetAllCategories();
        //    var getEvents = categoryId == Guid.Empty ? _eventComponentService.GetAll() :
        //        _eventComponentService.GetEventsByCategoryId(categoryId);
        //    await Task.WhenAll(new Task[] { getcategories, getEvents });


        //    return View(
        //           new EventsListModel
        //           {
        //               Events = getEvents.Result,
        //               Categories = getcategories.Result,
        //               SelectedCategory = categoryId
        //           }
        //       );
        //}

        public async Task<IActionResult> Index(Guid categoryId)
        {
            var getcategories = eventComponentGRPSService.GetAllCatgoriesAsync(new GetAllCatgoriesRequest());
            var getEvents = categoryId == Guid.Empty ? eventComponentGRPSService.GetAllEventsAsync(new GetAllEventsRequest()) :
                eventComponentGRPSService.GetAllbyCategoryIdAsync( new GetAllbyCategoryIdRequest { CategoryId = categoryId.ToString() });
            await Task.WhenAll(new Task[] { getcategories.ResponseAsync, getEvents.ResponseAsync });


            return View(
                   new EventsListModelGRPC
                   {
                       Event = getEvents.ResponseAsync.Result.Events,
                       Categories = getcategories.ResponseAsync.Result.Categories,
                       SelectedCategory = categoryId
                   }
               ); ;
        }
    }
}
