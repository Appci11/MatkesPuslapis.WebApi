using MatkesPuslapis.Core;
using MatkesPuslapis.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatkesPuslapis.WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public UsersController(IUserServices userServices, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _userServices = userServices;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _userServices.AddUser(user);
            //return Ok();
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var token = Request.Headers["Authorization"];
            var user = jwtAuthenticationManager.GetUser(token);
            // return Ok(_userServices.GetUsers());
            return Ok(user);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _userServices.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("addSolvedTopic")]
        public IActionResult AddSolvedTopic(UserTopic userTopic)
        {
            try
            {
                return Ok(_userServices.AddSolvedTopic(userTopic));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("removeSolvedTopic")]
        public IActionResult RemoveSolvedTopic(UserTopic userTopic)
        {
            try
            {
                return Ok(_userServices.RemoveSolvedTopic(userTopic));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //[HttpPost]
        //[Route("register")]
        //public IActionResult AddUser(string username, string email, string password)
        //{
        //    if (_userServices.UsernameExists(username)) { return Ok(1); }
        //    if (_userServices.EmailExists(email)) { return Ok(2); }
        //    _userServices.AddUser(username, email, password);
        //    return Ok(0);
        //}

        //[Authorize]
        //[HttpGet("Test")]
        //public IActionResult Test()
        //{
        //    return Ok("Pro autorizacija praeita sekmingai");
        //}
    }
}
