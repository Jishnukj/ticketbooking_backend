using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService
{
    public interface IVenueService
    {
        bool addVenue(Venue venue);
        bool Update(Venue venueChange, int id);
        Venue getVenuebyId(int id);
        List<Venue> getAllVenues();

    }
}
