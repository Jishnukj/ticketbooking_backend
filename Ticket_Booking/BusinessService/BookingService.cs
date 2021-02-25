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
        private readonly IEventRepo _ieventrepo;
        public BookingService(IBookingRepo ibookingRepo,IEventRepo ieventRepo)
        {
            _ibookingRepo = ibookingRepo;
            _ieventrepo = ieventRepo;
        }

        public bool addBooking(Booking booking)
        {
            var events = _ieventrepo.getEventbyId(booking.event_id);
            var data = _ibookingRepo.getAllbookings();
            int Total = data.Where(x => x.user_id == booking.user_id && x.event_id==booking.event_id).Count();
            
            if (Total == 0 && booking.No_of_tickets<=events.available_seats)
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
        public List<Booking> getAllbookings()
        {
            return _ibookingRepo.getAllbookings();
        }


    }

}

