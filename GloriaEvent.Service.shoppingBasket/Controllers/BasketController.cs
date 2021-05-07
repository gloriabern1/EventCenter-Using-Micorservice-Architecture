using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GloriaEvent.Service.shoppingBasket.Entities;
using GloriaEvent.Service.shoppingBasket.Models;
using GloriaEvent.Service.shoppingBasket.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GloriaEvent.Service.shoppingBasket.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRespository _basketRespository;
        private readonly IMapper _mapper;
        public BasketController(IBasketRespository basketRespository, IMapper mapper)
        {
            _basketRespository = basketRespository;
            _mapper = mapper;
        }

        [HttpGet("{basketId}", Name ="GetBasket")]
        public async Task<ActionResult<BasketDTO>> Get(Guid basketId)
        {
            var basket = await _basketRespository.GetBasketbyId(basketId);
            if(basket == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<BasketDTO>(basket);
            result.NumberOfItems = basket.BasketLines.Sum(x => x.TicketAmount);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BasketDTO>> Post(BasketCreation basketCreation)
        {
            var basketEntity = _mapper.Map<Basket>(basketCreation);
            _basketRespository.AddBasket(basketEntity);
            await _basketRespository.SaveChanges();

            var returnedBasket = _mapper.Map<BasketDTO>(basketEntity);

            return CreatedAtRoute("GetBasket", new { basketId = basketEntity.BasketId }, returnedBasket);

        }
    }
}