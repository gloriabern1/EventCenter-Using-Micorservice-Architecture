using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GloriaEvent.Service.shoppingBasket.Models;
using GloriaEvent.Service.shoppingBasket.Repository;
using GloriaEvent.Service.shoppingBasket.Services;
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
        private readonly IEventComponentService _eventComponentService;

        private readonly IMapper _mapper;
        public IActionResult Index()
        {
            return Ok();
        }

     
        public BasketLineController(IBasketRespository basketRepository,
            IBasketLineRepository basketLinesRepository, IEventRepository eventRepository,
            IEventComponentService eventComponentService, IMapper mapper)
        {
            _basketRespository = basketRepository;
            _basketLineRepository = basketLinesRepository;
            _eventRepository = eventRepository;
            _eventComponentService = eventComponentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketLineDTO>>> Get(Guid basketId)
        {
            if (!await _basketRespository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLines = await _basketLineRepository.GetBasketLines(basketId);
            return Ok(_mapper.Map<IEnumerable<BasketLineDTO>>(basketLines));
        }

        [HttpGet("{basketLineId}", Name = "GetBasketLine")]
        public async Task<ActionResult<BasketLineDTO>> Get(Guid basketId,
            Guid basketLineId)
        {
            if (!await _basketRespository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLine = await _basketLineRepository.GetBasketLineById(basketLineId);
            if (basketLine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BasketLineDTO>(basketLine));
        }

        [HttpPost]
        public async Task<ActionResult<BasketLineDTO>> Post(Guid basketId,
            [FromBody] BasketLineCreation basketLineCreation)
        {
            if (!await _basketRespository.BasketExists(basketId))
            {
                return NotFound();
            }

            if (!await _eventRepository.EventExists(basketLineCreation.EventId))
            {
                var eventFromCatalog = await _eventComponentService.GetEvent(basketLineCreation.EventId);
                _eventRepository.AddEvent(eventFromCatalog);
                await _eventRepository.SaveChanges();
            }

            var basketLineEntity = _mapper.Map<Entities.BasketLine>(basketLineCreation);

            var processedBasketLine = await _basketLineRepository.AddOrUpdateBasketLine(basketId, basketLineEntity);
            await _basketLineRepository.SaveChanges();

            var basketLineToReturn = _mapper.Map<BasketLineDTO>(processedBasketLine);

            return CreatedAtRoute(
                "GetBasketLine",
                new { basketId = basketLineEntity.BasketId, basketLineId = basketLineEntity.BasketLineId },
                basketLineToReturn);
        }

        [HttpPut("{basketLineId}")]
        public async Task<ActionResult<BasketLineDTO>> Put(Guid basketId,
            Guid basketLineId,
            [FromBody] BasketLineforUpdate basketLineForUpdate)
        {
            if (!await _basketRespository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await _basketLineRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            // map the entity to a dto
            // apply the updated field values to that dto
            // map the dto back to an entity
            _mapper.Map(basketLineForUpdate, basketLineEntity);

           await  _basketLineRepository.AddOrUpdateBasketLine( basketId, basketLineEntity);
            await _basketLineRepository.SaveChanges();

            return Ok(_mapper.Map<BasketLineDTO>(basketLineEntity));
        }

        [HttpDelete("{basketLineId}")]
        public async Task<IActionResult> Delete(Guid basketId,
            Guid basketLineId)
        {
            if (!await _basketRespository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await _basketLineRepository.GetBasketLineById(basketLineId);

            if (basketLineEntity == null)
            {
                return NotFound();
            }

            _basketLineRepository.RemoveBasketLine(basketLineEntity);
            await _basketLineRepository.SaveChanges();

            return NoContent();
        }
    }
}