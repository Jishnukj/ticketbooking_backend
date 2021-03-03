using System;
using System.Collections.Generic;
using System.Text;
using BusinessService.Dto;
using DataService.Entities;

namespace BuisnessService
{
    public interface IBookingService
    {
        bool addBooking(Booking booking);
        Booking getBookingbyId(int id);
        List<BookingDto> getAllbookings();
        List<BookingDto> getbookingsByEventid(int id);
    }
}