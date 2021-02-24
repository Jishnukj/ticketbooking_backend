using DataService.Entities;
using DataService.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessService
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepo _iVenueRepo;
        private readonly IEventRepo _iEventRepo;
        public VenueService(IVenueRepo iVenueRepo, IEventRepo iEventRepo)
        {
            _iVenueRepo = iVenueRepo;
            _iEventRepo = iEventRepo;
        }
        public bool addVenue(Venue venue)
        {
            var data = _iVenueRepo.getAllVenues();
            int Total = data.Where(x => x.venue_name == venue.venue_name).Count();
            if (Total == 0)
            {
                _iVenueRepo.addVenue(venue);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(Venue venueChange, int id)
        {
            var data = _iVenueRepo.getVenuebyId(id);
            if (data != null)
            {
                return _iVenueRepo.Update(venueChange, id);
            }
            return false;
        }
        public Venue getVenuebyId(int id)
        {
            var venue = _iVenueRepo.getVenuebyId(id);
            return venue;
        }
        public List<Venue> getAllVenues()
        {
            return _iVenueRepo.getAllVenues();
        }
        public List<Venue> getAvailable(DateTime date)
        {
            var venue = _iVenueRepo.getAllVenues();
            var activity = _iEventRepo.getAllEvents().Where(x => x.event_date.Date == date.Date);
            var data = (from ve in venue join act in activity on ve.venue_id equals act.venue_id select new { ve.venue_id, ve.venue_name, ve.total_seats, ve.ticket_rate }).ToList();
            var venuefinal = (from p in venue where !data.Any(u => u.venue_id == p.venue_id) select p).ToList();
            return venuefinal;
        }

    }
}
