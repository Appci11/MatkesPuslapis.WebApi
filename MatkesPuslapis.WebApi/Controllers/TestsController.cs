//Bet ko bandymams/testavimui. Uzbaigtai programai nereikalinga

using MatkesPuslapis.Core;
using Microsoft.AspNetCore.Authorization;
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
    public class TestsController : ControllerBase
    {
        private readonly ITestServices _testServices;
        public TestsController(ITestServices testServices )
        {
            _testServices = testServices;
        }
        [HttpGet]
        public IActionResult GetTests()
        {
            return Ok(_testServices.GetTests());
        }
    }
}
