using DataService.Entities;
using DataService.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessService
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _ibookingRepo;
        public BookingService(IBookingRepo ibookingRepo)
        {
            _ibookingRepo = ibookingRepo;
        }

        public bool addBooking(Booking booking)
        {
            bool aldreadyBooked = _ibookingRepo.checkUserIdEventId(booking);
            if (aldreadyBooked == false)
            {
                return _ibookingRepo.addBooking(booking);
            }
            else
            {
                return false;
            }
        }
        public Booking getBookingbyId(int id)
        {
            var booking = _ibookingRepo.getBookingbyId(id);
            return booking;
        }


    }

}

