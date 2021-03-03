﻿using BuisnessService;
using DataService.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist,user")]
        [HttpGet("{id}")]
        public IActionResult getBookingbyId(int id)
        {
            var booking = _bookingService.getBookingbyId(id);
            if (booking != null)
                return Ok(booking);
            else
                return NotFound($"Booking with id {id} was not found.");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist,user")]
        [HttpPost("booking")]
        public IActionResult addBooking(Booking booking)
        {
            var p = _bookingService.addBooking(booking);
            if (p == true)
            {
                return Ok(p);
            }
            return BadRequest("Already booked or tickets are not available");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist,user")]
        [HttpGet("allbooking")]
        public IActionResult getAllbooking()
        {
            return Ok(_bookingService.getAllbookings());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist")]
        [HttpGet("eventbooking/{eventid}")]
        public IActionResult getBookingByEventid(int eventid)
        {
            return Ok(_bookingService.getbookingsByEventid(eventid));
        }
    }
}
