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
    public class TopicsController : Controller
    {
        private readonly ITopicServices _storyServices;
        public TopicsController(ITopicServices storyServices)
        {
            _storyServices = storyServices;
        }

        [HttpPost]
        public IActionResult AddStory(Topic story)
        {
            if (_storyServices.TopicExists(story.Title))
                return StatusCode(406, new { Name = "Already exists" });
            _storyServices.AddTopic(story);
            return CreatedAtRoute("GetQuestion", new { id = story.Id }, story);
        }

        [HttpGet]
        public IActionResult GetStories()
        {
            return Ok(_storyServices.GetTopics());
        }

        [HttpGet("{id}", Name = "GetTopic")]
        public IActionResult GetStory(string id)
        {
            try
            {
                return Ok(_storyServices.GetTopic(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("name/{name}", Name = "GetStoryByName")]
        public IActionResult GetStoryByName(string name)
        {
            try
            {
                return Ok(_storyServices.GetTopicByIndex(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateStory(Topic story)
        {
            if (_storyServices.TopicExists(story.Title))
                return StatusCode(406, new { Name = "Already exists" });
            try
            {
                return Ok(_storyServices.UpdateTopic(story));
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
                _storyServices.DeleteTopic(id);
                return Ok("Deletion Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
