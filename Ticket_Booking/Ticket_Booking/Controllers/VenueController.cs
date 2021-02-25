using BusinessService;
using DataService.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private IVenueService _venueSerice;
        public VenueController(IVenueService venueService)
        {
            _venueSerice = venueService;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("allVenues")]
   
        public IActionResult getAllVenues()
        {
            return Ok(_venueSerice.getAllVenues());
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("availableVenues/{date}")]

        public IActionResult getAvailableVenues(DateTime date)
        {
            return Ok(_venueSerice.getAvailable(date));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public IActionResult GetVenueById(int id)
        {
            var venue = _venueSerice.getVenuebyId(id);

            if (venue != null)
            {
                return Ok(venue);
            }
            return NotFound($"Activity with Id: {id} was not found");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult addVenue(Venue venue)
        {
            var p = _venueSerice.addVenue(venue);
            if (p == true)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest("Venue already exist");
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch]
        public IActionResult updateVenue(Venue venue, int id)
        {
            var p = _venueSerice.Update(venue, id);
            if (p == true)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest("Invalid");
            }
        }
    }
}
