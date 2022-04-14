using MatkesPuslapis.Core;
using MatkesPuslapis.Core.Interfaces;
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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionServices _questionServices;
        public QuestionsController(IQuestionServices questionServices)
        {
            _questionServices = questionServices;
        }
        [HttpPost]
        public IActionResult AddQuestion(Question question)
        {
            if (_questionServices.NameExists(question.Name))
                return StatusCode(406, new { Name = "Already exists" });
            _questionServices.AddQuestion(question);
            return CreatedAtRoute("GetQuestion", new { id = question.Id }, question);
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            return Ok(_questionServices.GetQuestions());
        }

        [HttpGet("{id}", Name = "GetQuestion")]
        public IActionResult GetQuestion(string id)
        {
            try
            {
                return Ok(_questionServices.GetQuestion(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateQuestion(Question question)
        {
            if (_questionServices.NameExists(question.Name))
                return StatusCode(406, new { Name = "Already exists" });
            try
            {
                return Ok(_questionServices.UpdateQuestion(question));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(string id)
        {
            try
            {
                _questionServices.DeleteQuestion(id);
                return Ok("Deletion Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
