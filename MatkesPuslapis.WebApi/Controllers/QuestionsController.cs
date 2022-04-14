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
            _questionServices.AddQuestion(question);
            return CreatedAtRoute("GetQuestion", new { id = question.Id }, question);
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            return Ok(_questionServices.GetQuestions());
        }

        [HttpGet("{id}", Name = "GetQuestion")]
        public IActionResult GetTest(string id)
        {
            return Ok("Not implemented");
        }

        [HttpPut]
        public IActionResult UpdateQuestion(Question question)
        {
            return Ok("Not implemented");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(string id)
        {
            return Ok("Not implemented");
        }
    }
}
