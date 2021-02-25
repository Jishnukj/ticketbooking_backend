using DataService.Entities;
using DataService.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var data = _ibookingRepo.getAllBookings();
            int Total = data.Where(x => x.user_id == booking.user_id && x.event_id==booking.event_id).Count();
            if (Total == 0)
            {
                _ibookingRepo.addBooking(booking);
                return true;
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
        public List<Booking> getAllBookings()
        {
            return _ibookingRepo.getAllBookings();
        }



    }

}

