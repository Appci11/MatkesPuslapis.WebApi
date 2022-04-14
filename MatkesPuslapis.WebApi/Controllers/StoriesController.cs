using MatkesPuslapis.Core.Interfaces;
using MatkesPuslapis.Core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

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
            if (_storyServices.NameExists(story.Name))
                return StatusCode(406, new { Name = "Already exists" });
            _storyServices.AddStory(story);
            return CreatedAtRoute("GetQuestion", new { id = story.Id }, story);
        }

        [HttpGet]
        public IActionResult GetStories()
        {
            return Ok(_storyServices.GetStories());
        }

        [HttpGet("{id}", Name = "GetStory")]
        public IActionResult GetStory(string id)
        {
            try
            {
                return Ok(_storyServices.GetStory(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateStory(Story story)
        {
            if (_storyServices.NameExists(story.Name))
                return StatusCode(406, new { Name = "Already exists" });
            try
            {
                return Ok(_storyServices.UpdateStory(story));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStory(string id)
        {
            try
            {
                _storyServices.DeleteStory(id);
                return Ok("Deletion Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
