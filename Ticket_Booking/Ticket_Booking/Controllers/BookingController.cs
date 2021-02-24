using BuisnessService;
using DataService.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("{id}")]
        public IActionResult getBookingbyId(int id)
        {
            var booking = _bookingService.getBookingbyId(id);
            if (booking != null)
                return Ok(booking);
            else
                return NotFound($"Booking with id {id} was not found.");
        }
        [HttpPost]
        public IActionResult addBooking(Booking booking)
        {
            var p = _bookingService.addBooking(booking);
            if (p == true)
                return Ok(true);
            else
                return BadRequest("Booking aldeady exist.");
        }
    }
}
