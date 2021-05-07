using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GloriaEvent.Service.shoppingBasket.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GloriaEvent.Service.shoppingBasket.Controllers
{
    [Route("api/baskets/{basketId}/basketlines")]
    [ApiController]
    public class BasketLineController : ControllerBase
    {
        private readonly IBasketRespository _basketRespository;
        private readonly IBasketLineRepository _basketLineRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public IActionResult Index()
        {
            return Ok();
        }
    }
}