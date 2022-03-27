using MatkesPuslapis.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatkesPuslapis.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userServices.GetUsers());
        }
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(string id)
        {
            try
            {
                return Ok(_userServices.GetUser(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _userServices.AddUser(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _userServices.DeleteUser(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                return Ok(_userServices.UpdateUser(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Prideda "User" irasa i "Users" lentele duomenu bazeje
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>0 - irasyta sekmingai; 1 - username egzistuoja; 2 - email egzistuoja</returns>
        [HttpPost]
        [Route("register")]
        public IActionResult AddUser(string name, string email, string password)
        {
            if (_userServices.UsernameExists(name)) { return Ok(1); }
            if (_userServices.EmailExists(email)) { return Ok(2); }
            _userServices.AddUser(name, email, password);
            return Ok(0);
        }
        [HttpGet("Tikrinti")]
        public IActionResult Test()
        {
            return Ok(_userServices.Test());
        }
    }
}
