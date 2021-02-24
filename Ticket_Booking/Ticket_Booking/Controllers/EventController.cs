using BusinessService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController:ControllerBase
    {
        private IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(_eventService.GetEvents());
        }

        [HttpGet("UpcomingEvents")]
        public IActionResult GetUpComingEvents()
        {
            return Ok(_eventService.GetUpComingEvents());
        }

        [HttpPost]
        public IActionResult addEvent()
        {
            return Ok(true);
        }
    }
}
