using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GloriaEvents.Services.EventComponent.Repository;
using GloriaEvents.Services.EventRecords.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace GloriaEvents.Services.EventRecords.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

       
        [HttpGet("/Get")]
        public async Task<ActionResult<IEnumerable<EventsDto>>> Get([FromQuery]Guid CategoryId)
        {
            var result = await _eventRepository.GetEvents(CategoryId);
            return Ok(_mapper.Map<List<EventsDto>>(result));
        }

        [HttpGet("/GetAllEvents")]
        public async Task<ActionResult<IEnumerable<EventsDto>>> GetAllEvents()
        {
            var result = await _eventRepository.GetAllEvents();
            return Ok(_mapper.Map<List<EventsDto>>(result));
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventsDto>> GetbyId(Guid EventId)
        {
            var result = await _eventRepository.GetEventbyId(EventId);
            return Ok(_mapper.Map<EventsDto>(result));
        }
    }
}