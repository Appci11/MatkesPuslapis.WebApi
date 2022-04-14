using MatkesPuslapis.Core.Interfaces;
using MatkesPuslapis.Core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MatkesPuslapis.WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class StoriesController : Controller
    {
        private readonly IStoryServices _storyServices;

        public StoriesController(IStoryServices storyServices)
        {
            _storyServices = storyServices;
        }

        [HttpPost]
        public IActionResult AddStory(Story story)
        {
            return Ok("Not Implemented");
        }

        [HttpGet]
        public IActionResult GetStories()
        {
            return Ok("Not Implemented");
        }

        [HttpGet("{id}", Name = "GetStory")]
        public IActionResult GetStory(string id)
        {
            return Ok("Not implemented");
        }

        [HttpPut]
        public IActionResult UpdateStory(Story story)
        {
            return Ok("Not implemented");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStory(string id)
        {
            return Ok("Not implemented");
        }

    }
}
