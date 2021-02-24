using BusinessService;
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

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var user = _eventService.GetEventById(id);
            if (user.Count != 0)
            {
                return Ok(user);
            }
            return NotFound($"Event with Id: {id} not found");
        }

        [HttpGet("Event/{date}")]
        public IActionResult GetEventByDate(DateTime date)
        {
            var user = _eventService.GetEventByDate(date);
            if (user.Count != 0)
            {
                return Ok(user);
            }
            return NotFound($"Event on Date: {date} not found");
        }

        [HttpPost("adding")]
        public bool addEvent(Event events)
        {
            var p = _eventService.addEvent(events);
            return p;
        }
        [HttpPost("appove")]
        public IActionResult appoveEvent(int event_id, bool appove)
        {
            var p = _eventService.appoveEvent(event_id, appove);
            if (p == true)
            {
                return Ok(p);
            }
            return BadRequest("Invalid");
        }
    }
}
