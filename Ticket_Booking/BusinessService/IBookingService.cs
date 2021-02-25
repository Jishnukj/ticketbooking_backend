using System;
using System.Collections.Generic;
using System.Text;
using DataService.Entities;

namespace BuisnessService
{
    public interface IBookingService
    {
        bool addBooking(Booking booking);
        Booking getBookingbyId(int id);
        List<Booking> getAllBookings();
    }
}