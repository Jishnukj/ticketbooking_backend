using BusinessService;
using DataService.Entities;
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
        [HttpGet]
        [Route("allVenues")]
        public IActionResult getAllVenues()
        {
            return Ok(_venueSerice.getAllVenues());
        }
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
