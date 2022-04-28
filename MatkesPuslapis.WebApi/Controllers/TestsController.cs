//Praktiskai nenaudojama, lieka, nes kitai lentelei atsiradus, uzteks pervadint

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
    public class TestsController : ControllerBase
    {
        //private readonly ITestServices _testServices;
        //public TestsController(ITestServices testServices )
        //{
        //    _testServices = testServices;
        //}

        //[HttpPost]
        //public IActionResult AddTest(Test test)
        //{
        //    if (_testServices.NameExists(test.Name))
        //        return StatusCode(406, new { Name = "Already exists" });
        //    _testServices.AddTest(test);
        //    return CreatedAtRoute("GetTest", new { id = test.Id }, test);
        //}

        //[HttpGet]
        //public IActionResult GetTests()
        //{
        //    return Ok(_testServices.GetTests());
        //}

        //[HttpGet("{id}", Name = "GetTest")]
        //public IActionResult GetTest(string id)
        //{
        //    try
        //    {
        //        return Ok(_testServices.GetTest(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet("name/{name}", Name = "GetTestByName")]
        //public IActionResult GetTestByName(string name)
        //{
        //    try
        //    {
        //        return Ok(_testServices.GetTestByName(name));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut]
        //public IActionResult UpdateTest(Test test)
        //{
        //    if (_testServices.NameExists(test.Name))
        //        return StatusCode(406, new { Name = "Already exists" });
        //    try
        //    {
        //        return Ok(_testServices.UpdateTest(test));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteTest(string id)
        //{
        //    try
        //    {
        //        _testServices.DeleteTest(id);
        //        return Ok("Deletion Successful");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
