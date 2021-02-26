using BusinessService.Dto;
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
        private readonly IUserRepo _iuserRepo;

        public BookingService(IBookingRepo ibookingRepo,IEventRepo ieventRepo,IUserRepo iuserRepo)
        {
            _ibookingRepo = ibookingRepo;
            _ieventrepo = ieventRepo;
            _iuserRepo = iuserRepo;
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
        public List<BookingDto> getAllbookings()
        {
            var booking= _ibookingRepo.getAllbookings();
            var user = _iuserRepo.GetAllUsers();
            var data = (from bo in booking join us in user on bo.user_id equals us.user_id select new {bo.booking_id,bo.user_id,bo.event_id,bo.booking_date,bo.No_of_tickets,us.user_name }).ToList();
            return data.Select(a => new BookingDto
            {
               booking_id=a.booking_id,
               user_id=a.user_id,
               event_id=a.event_id,
               booking_date=a.booking_date,
               No_of_tickets=a.No_of_tickets,
               username=a.user_name

            }).ToList();
        }


    }

}

