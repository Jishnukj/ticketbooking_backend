using BusinessService;
using DataService.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User with Id: {id} is not found");
        }

        // POST api/<UserController>
        [HttpPost("register/User")]
        public bool Post([FromBody] User user)
        {
            var userRegistered = _userService.RegisterUser(user);
            return userRegistered;
        }

        [HttpPost("login/User")]
        public bool Post(string email, string password)
        {
            var userRegistered = _userService.LoginUser(email, password);
            return userRegistered;
        }



        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
