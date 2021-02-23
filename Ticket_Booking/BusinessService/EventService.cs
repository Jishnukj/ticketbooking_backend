using DataService.Entities;
using DataService.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessService
{
    public class EventService : IEventService
    {
        private readonly IEventRepo _eventRepository;


        public EventService(IEventRepo eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();
           events = _eventRepository.getAllEvents();
            return events.ToList();
        }
    }
}
