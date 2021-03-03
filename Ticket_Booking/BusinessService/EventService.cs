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


          
            var data2 = (from ev in events join ven in venue on ev.venue_id equals ven.venue_id select new { ev.event_id, ev.event_name, ev.event_date, ev.event_time, ev.venue_id, ev.available_seats, ev.artist_name, ev.description, ev.approval_status, ev.image, ven.venue_name , ven.total_seats, ev.ticketprice }).ToList();
            var data = data2.OrderByDescending(s => s.event_date);
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
                ticket_rate=a.ticketprice,
                total_seats=a.total_seats

            }).ToList();
        
        }

        public List<EventDto> GetUpComingEvents()
        {
            var events = _eventRepository.getAllEvents();
            var venue = _venueRepository.getAllVenues();
            var data2 = (from ev in events join ven in venue on ev.venue_id equals ven.venue_id select new { ev.event_id, ev.event_name, ev.event_date, ev.event_time, ev.venue_id, ev.available_seats, ev.artist_name, ev.description, ev.approval_status, ev.image, ven.venue_name, ven.total_seats, ev.ticketprice }).ToList();
            var datefilter1 = data2.Where(s => s.event_date.Date >= DateTime.Now.Date);
            var data = datefilter1.OrderByDescending(s => s.event_date);
            return data.Select(a => new EventDto
            {
                event_id = a.event_id,
                event_name = a.event_name,
                event_date = a.event_date,
                event_time = a.event_time,
                venue_id = a.venue_id,
                available_seats = a.available_seats,
                artist_name = a.artist_name,
                description = a.description,
                approval_status = a.approval_status,
                image = a.image,
                venue_name = a.venue_name,
                ticket_rate = a.ticketprice,
                total_seats = a.total_seats

            }).ToList();

        }
        public List<EventDto> GetUpComingApprovedEvents()
        {
            var events = _eventRepository.getAllEvents();
            var venue = _venueRepository.getAllVenues();
            var data2 = (from ev in events join ven in venue on ev.venue_id equals ven.venue_id select new { ev.event_id, ev.event_name, ev.event_date, ev.event_time, ev.venue_id, ev.available_seats, ev.artist_name, ev.description, ev.approval_status, ev.image, ven.venue_name, ven.total_seats, ev.ticketprice }).ToList();
            var datefilter1 = data2.Where(s => s.event_date.Date >= DateTime.Now.Date);
            var datefilter2 = datefilter1.Where(s => s.approval_status=="approve");
            var data = datefilter2.OrderByDescending(s => s.event_date);
            return data.Select(a => new EventDto
            {
                event_id = a.event_id,
                event_name = a.event_name,
                event_date = a.event_date,
                event_time = a.event_time,
                venue_id = a.venue_id,
                available_seats = a.available_seats,
                artist_name = a.artist_name,
                description = a.description,
                approval_status = a.approval_status,
                image = a.image,
                venue_name = a.venue_name,
                ticket_rate = a.ticketprice,
                total_seats = a.total_seats

            }).ToList();
        }
        public List<EventDto> GetUpComingNotConfirmedEvents()
        {
            var events = _eventRepository.getAllEvents();
            var venue = _venueRepository.getAllVenues();
            var data2 = (from ev in events join ven in venue on ev.venue_id equals ven.venue_id select new { ev.event_id, ev.event_name, ev.event_date, ev.event_time, ev.venue_id, ev.available_seats, ev.artist_name, ev.description, ev.approval_status, ev.image, ven.venue_name, ven.total_seats, ev.ticketprice }).ToList();
            var datefilter1 = data2.Where(s => s.event_date.Date >= DateTime.Now.Date);
            var datefilter2 = datefilter1.Where(s => s.approval_status != "approve" && s.approval_status != "reject");
            var data = datefilter2.OrderByDescending(s => s.event_date);
            return data.Select(a => new EventDto
            {
                event_id = a.event_id,
                event_name = a.event_name,
                event_date = a.event_date,
                event_time = a.event_time,
                venue_id = a.venue_id,
                available_seats = a.available_seats,
                artist_name = a.artist_name,
                description = a.description,
                approval_status = a.approval_status,
                image = a.image,
                venue_name = a.venue_name,
                ticket_rate = a.ticketprice,
                total_seats = a.total_seats

            }).ToList();
        }

        public List<EventDto> GetEventById(int id)
        {

            var events = _eventRepository.getAllEvents();
            var venue = _venueRepository.getAllVenues();

            var data = (from ev in events join ven in venue on ev.venue_id equals ven.venue_id where ev.event_id == id select new { ev.event_id, ev.event_name, ev.event_date, ev.event_time, ev.venue_id, ev.available_seats, ev.artist_name, ev.description, ev.approval_status, ev.image, ven.venue_name, ven.total_seats, ev.ticketprice }).ToList();
            return data.Select(a => new EventDto
            {
                event_id = a.event_id,
                event_name = a.event_name,
                event_date = a.event_date,
                event_time = a.event_time,
                venue_id = a.venue_id,
                available_seats = a.available_seats,
                artist_name = a.artist_name,
                description = a.description,
                approval_status = a.approval_status,
                image = a.image,
                venue_name = a.venue_name,
                ticket_rate = a.ticketprice,
                total_seats = a.total_seats

            }).ToList();

        }

        public List<EventDto> GetEventByDate(DateTime date)
        {
            var events = _eventRepository.getAllEvents();
            var venue = _venueRepository.getAllVenues();



            var data = (from ev in events join ven in venue on ev.venue_id equals ven.venue_id where ev.event_date.Date == date.Date select new { ev.event_id, ev.event_name, ev.event_date, ev.event_time, ev.venue_id, ev.available_seats, ev.artist_name, ev.description, ev.approval_status, ev.image, ven.venue_name, ven.total_seats, ev.ticketprice }).ToList();
            return data.Select(a => new EventDto
            {
                event_id = a.event_id,
                event_name = a.event_name,
                event_date = a.event_date,
                event_time = a.event_time,
                venue_id = a.venue_id,
                available_seats = a.available_seats,
                artist_name = a.artist_name,
                description = a.description,
                approval_status = a.approval_status,
                image = a.image,
                venue_name = a.venue_name,
                ticket_rate = a.ticketprice,
                total_seats = a.total_seats

            }).ToList();

        }



        public bool addEvent(Event events)
        {
            return _eventRepository.addEvent(events);
            
        }
        public bool approveEvent(int event_id, string approve)
        {
            var p = _eventRepository.getEventbyId(event_id);
            if (p.approval_status != "approve")
            {
                _eventRepository.approveEvent(event_id, approve);
                return true;
            }
            return false;
        }
        public List<EventDto> GetApporedEvents()
        {
            
            var events = _eventRepository.getAllEvents();
            var venue = _venueRepository.getAllVenues();
            var data2 = (from ev in events join ven in venue on ev.venue_id equals ven.venue_id select new { ev.event_id, ev.event_name, ev.event_date, ev.event_time, ev.venue_id, ev.available_seats, ev.artist_name, ev.description, ev.approval_status, ev.image, ven.venue_name, ven.total_seats, ev.ticketprice }).ToList();
            var datefilter1 = data2.Where(s => s.event_date.Date >= DateTime.Now.Date);
            var data3 = datefilter1.OrderByDescending(s => s.event_date);
            var data=data3.Where(x => x.approval_status == "approve");
            return data.Select(a => new EventDto
            {
                event_id = a.event_id,
                event_name = a.event_name,
                event_date = a.event_date,
                event_time = a.event_time,
                venue_id = a.venue_id,
                available_seats = a.available_seats,
                artist_name = a.artist_name,
                description = a.description,
                approval_status = a.approval_status,
                image = a.image,
                venue_name = a.venue_name,
                ticket_rate = a.ticketprice,
                total_seats = a.total_seats

            }).ToList();
        }
    }
}
