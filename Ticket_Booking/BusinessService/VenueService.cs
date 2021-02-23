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
        public VenueService(IVenueRepo iVenueRepo)
        {
            _iVenueRepo = iVenueRepo;
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

    }
}
