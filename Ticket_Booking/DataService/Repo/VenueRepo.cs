using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Repo
{
    public class VenueRepo : IVenueRepo
    {
        private readonly ApplicationdbContext _dbContext;
        public VenueRepo(ApplicationdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Venue getVenuebyId(int id)
        {
            Venue venue = _dbContext.Venues.Where(e => e.venue_id == id).FirstOrDefault();
            return venue;
        }
        public List<Venue> getAllVenues()
        {
            return _dbContext.Venues.ToList();
        }
        public bool addVenue(Venue venue)
        {
            _dbContext.Venues.Add(venue);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Update(Venue venueChange, int id)
        {
            Venue venue = _dbContext.Venues.Where(x => x.venue_id == id).FirstOrDefault();
            if (venue != null)
            {
                venue.venue_name = venueChange.venue_name;
                venue.total_seats = venueChange.total_seats;
                venue.ticket_rate = venueChange.ticket_rate;
                _dbContext.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }


    }
}
