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
        [HttpGet]
        public IActionResult GetQuestions()
        {
            return Ok(_questionServices.GetQuestions());
        }
    }
}
