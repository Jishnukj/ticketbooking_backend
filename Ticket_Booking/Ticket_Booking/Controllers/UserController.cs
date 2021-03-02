﻿using BusinessService;
using DataService.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        // GET api/<UserController>/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist")]
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

        [HttpPost("login")]
        public async Task<IActionResult> checkadmin(string email,string password)
        {
           
            var user = _userService.checkAdmin(email, password);
            if (user != null)
            {
                var usertype = user.user_type;
                var userid = user.user_id;
                var username = user.user_name;
                if (usertype == "admin" || usertype == "artist" || usertype == "user")
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("email",email.ToString()),
                        new Claim(ClaimTypes.Role, usertype)
                        }),
                        Expires = DateTime.UtcNow.AddHours(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes("123433231324354343434")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token, usertype, userid, username });
                }
                else
                {
                    return BadRequest(new { message = "invalid" });
                }
            }
            else
            {
                return BadRequest(new { message = "invalid" });
            }

        }

    }
}
