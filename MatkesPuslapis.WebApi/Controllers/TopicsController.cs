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
        private readonly ITopicServices _topicServices;
        public TopicsController(ITopicServices topicServices)
        {
            _topicServices = topicServices;
        }

        [HttpPost]
        public IActionResult AddTopic(TopicCreation topic)
        {
            if (_topicServices.TopicExists(topic.Title))
                return StatusCode(406, new { Title = "Already exists" });
            if (_topicServices.IndexExists(topic.Index))
                return StatusCode(406, new { Index = "Already exists" });
            _topicServices.AddTopic(topic);
            return Ok(topic);
            //return CreatedAtRoute("GetTopic", new { id = topic.Id }, topic);
        }

        [HttpGet]
        public IActionResult GetTopics()
        {
            return Ok(_topicServices.GetTopics());
        }

        [HttpGet("{id}", Name = "GetTopic")]
        public IActionResult GetStory(string id)
        {
            try
            {
                return Ok(_topicServices.GetTopic(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("index/{index}", Name = "GetStoryByName")]
        public IActionResult GetStoryByName(int index)
        {
            try
            {
                return Ok(_topicServices.GetTopicByIndex(index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //100% egzistuoja bugai, bet nzn ar butina rodyt
        //tarkim nurodau pakeist tik Title, bet index lieka, tokiu atveju sauks,
        //kad irasas su tokiu Index jau egzistuoja
        [HttpPut]
        public IActionResult UpdateTopic(TopicEdit topic)
        {
            if (_topicServices.TopicExists(topic.Title))
                return StatusCode(406, new { Title = "Already exists" });
            if (_topicServices.IndexExists(topic.Index))
                return StatusCode(406, new { Index = "Already exists" });
            try
            {
                return Ok(_topicServices.UpdateTopic(topic));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTopic(string id)
        {
            try
            {
                _topicServices.DeleteTopic(id);
                return Ok("Deletion Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //patikrinimo reikia, ar Question tokiu id jau neegzistuoja
        [HttpPatch("addQuestion")]
        public IActionResult AddSolvedTopic(TopicQuestion topicQuestion)
        {
            try
            {
                return Ok(_topicServices.AddQuestion(topicQuestion));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("removeQuestion")]
        public IActionResult RemoveQuestion(TopicQuestionDelete topicQuestionDelete)
        {
            try
            {
                return Ok(_topicServices.RemoveQuestion(topicQuestionDelete));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("question/addPossibleAnswerByText")]
        public IActionResult AddPossibleAnswerByText(PossibleAnswer possibleAnswer)
        {
            try
            {
                return Ok(_topicServices.AddPossibleAnswerByText(possibleAnswer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("bandymas")]
        public IActionResult Bandymas(PossibleAnswer possibleAnswer)
        {
            try
            {
                return Ok(_topicServices.Bandymas(possibleAnswer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPatch("question/addPossibleAnswer")]
        //public IActionResult Bandymas2(TopicQuestionDelete topicQuestionDelete)
        //{
        //    return Ok();
        //}

        //[HttpPatch("question/removePossibleAnswer")]
        //public IActionResult Bandymas3(TopicQuestionDelete topicQuestionDelete)
        //{
        //    return Ok();
        //}
    }
}
