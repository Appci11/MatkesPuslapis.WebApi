//Bet ko bandymams/testavimui. Uzbaigtai programai nereikalinga

using MatkesPuslapis.Core;
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
    public class TestsController : ControllerBase
    {
        private readonly ITestServices _testServices;
        public TestsController(ITestServices testServices )
        {
            _testServices = testServices;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_testServices.GetTests());
        }

        [HttpPost]
        public IActionResult AddTest(Test test)
        {
            _testServices.AddTest(test);
            return CreatedAtRoute("GetTest", new { id = test.Id }, test);
        }
    }
}
