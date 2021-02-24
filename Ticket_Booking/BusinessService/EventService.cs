using BusinessService.Dto;
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
        private readonly IVenueRepo _venueRepository;

        public EventService(IEventRepo eventRepository, IVenueRepo venueRepository)
        {
            _eventRepository = eventRepository;
            _venueRepository = venueRepository;

        }

        public List<EventDto> GetEvents()
        {
            var events = _eventRepository.getAllEvents();
            var venue = _venueRepository.getAllVenues();


            var sort = events.OrderByDescending(s => s.event_date);
            var data = (from ev in events join ven in venue on ev.venue_id equals ven.venue_id select new { ev.event_id, ev.event_name, ev.event_date, ev.event_time, ev.venue_id, ev.available_seats, ev.artist_name, ev.description, ev.approval_status, ev.image, ven.venue_name , ven.total_seats, ven.ticket_rate }).ToList();
            return data.Select(a => new EventDto
            {
                event_id = a.event_id,
                event_name=a.event_name,
                event_date=a.event_date,
                event_time=a.event_time,
                venue_id=a.venue_id,
                available_seats=a.available_seats,
                artist_name=a.artist_name,
                description=a.description,
                approval_status=a.approval_status,
                image=a.image,
                venue_name=a.venue_name,
                ticket_rate=a.ticket_rate,
                total_seats=a.total_seats

            }).ToList();
        
        }
    }
}
