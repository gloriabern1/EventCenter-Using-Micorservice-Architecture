using AutoMapper;
using GloriaEvent.Grpc;
using GloriaEvents.Services.EventComponent.Repository;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventComponent.Services
{
    public class EventGRPSService : Events.EventsBase
    {

        private readonly IEventRepository _eventRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public EventGRPSService(IEventRepository eventRepository, ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public override async Task<GetAllEventsResponse> GetAllEvents(
       GetAllEventsRequest request, ServerCallContext context)
        {
            var response = new GetAllEventsResponse();
            var eventEntities = await _eventRepository.GetEvents(Guid.Empty);
            response.Events.Add(_mapper.Map<List<Event>>(eventEntities));
            return response;
        }

        public override async Task<GetAllEventsResponse> GetAllbyCategoryId(
            GetAllbyCategoryIdRequest request, ServerCallContext context)
        {
            var response = new GetAllEventsResponse();
            var eventEntities = await _eventRepository.GetEvents(
                Guid.Parse(request.CategoryId));
            response.Events.Add(_mapper.Map<List<Event>>(eventEntities));
            return response;
        }

        public override async Task<GetByEventIdResponse> GetByEventId(
            GetByEventIdRequest request, ServerCallContext context)
        {
            var response = new GetByEventIdResponse();
            var entity = await _eventRepository.GetEventbyId(Guid.Parse(request.EventId));
            response.Events = _mapper.Map<Event>(entity);
            return response;
        }

       //Add other methods


    }
}
