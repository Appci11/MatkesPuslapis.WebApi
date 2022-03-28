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
            if (jwtAuthenticationManager.UsernameExists(name)) { return Ok(1); }
            if (jwtAuthenticationManager.EmailExists(email)) { return Ok(2); }
            jwtAuthenticationManager.AddUser(name, email, password);
            return Ok(0);
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
