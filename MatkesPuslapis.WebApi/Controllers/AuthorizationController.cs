using MatkesPuslapis.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatkesPuslapis.WebApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public AuthorizationController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult AddUser(string name, string email, string password)
        {
            bool a = jwtAuthenticationManager.UsernameExists(name);
            bool b = jwtAuthenticationManager.EmailExists(email);
            if(a && b) return StatusCode(406, new { Name = "Already exists", Email = "Already exists" });
            if (a) return StatusCode(406, new { Name = "Already exists"});
            if (b) return StatusCode(406, new { Email = "Already exists" });
            jwtAuthenticationManager.AddUser(name, email, password);
            return Ok("Registered");
        }

        [HttpPost("login")]
        public IActionResult Authenticate(string email, string password)
        {
            var token = jwtAuthenticationManager.Authenticate(email, password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
