using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Repo
{
    public interface IVenueRepo
    {
        bool addVenue(Venue venue);
        Venue getVenuebyId(int id);
        List<Venue> getAllVenues();
    }
}
