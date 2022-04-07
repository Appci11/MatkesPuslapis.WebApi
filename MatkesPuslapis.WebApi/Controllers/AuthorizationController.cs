using MatkesPuslapis.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatkesPuslapis.WebApi.Controllers
{
    [EnableCors]
    [Route("auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public AuthorizationController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        //[HttpPost]
        //[Route("register")]
        //public IActionResult AddUser(string name, string email, string password)
        //{
        //    bool a = jwtAuthenticationManager.UsernameExists(name);
        //    bool b = jwtAuthenticationManager.EmailExists(email);
        //    if(a && b) return StatusCode(406, new { Name = "Already exists", Email = "Already exists" });
        //    if (a) return StatusCode(406, new { Name = "Already exists"});
        //    if (b) return StatusCode(406, new { Email = "Already exists" });
        //    jwtAuthenticationManager.AddUser(name, email, password);
        //    return Ok("Registered");
        //}

        [HttpPost]
        [Route("register")]
        public IActionResult AddUser([FromBody] UserRegisterCredentials userCredentials)
        {
            bool a = jwtAuthenticationManager.UsernameExists(userCredentials.Name);
            bool b = jwtAuthenticationManager.EmailExists(userCredentials.Email);
            if (a && b) return StatusCode(406, new { Name = "Already exists", Email = "Already exists" });
            if (a) return StatusCode(406, new { Name = "Already exists" });
            if (b) return StatusCode(406, new { Email = "Already exists" });
            jwtAuthenticationManager.AddUser(userCredentials.Name, userCredentials.Email, userCredentials.Password);
            return Ok(new { Name = userCredentials.Name, Email = userCredentials.Email, Status = "Registered" });
        }

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] UserLoginCredentials userCredentials)
        {
            var token = jwtAuthenticationManager.Authenticate(userCredentials.Email, userCredentials.Password);
            if (token == null)
                return Unauthorized();

            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.HttpOnly = true;
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            this.HttpContext.Response.Cookies.Append("Session", token, cookieOptions);
            //return Ok();
            return Ok(token);
        }
    }
}
