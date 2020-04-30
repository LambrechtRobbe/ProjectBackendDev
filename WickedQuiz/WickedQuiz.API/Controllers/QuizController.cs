using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WickedQuiz.Models.Repositories;

namespace WickedQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;

        public QuizController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        // GET: api/Quiz
        [HttpGet]
        public async Task<IActionResult> GetAllQuizzesAsync()
        {
            var quizzes = await _quizRepository.GetAllQuizzesAsync();
            return Ok(quizzes);
        }

        // GET: api/Quiz/5
        [HttpGet("{quizid}", Name = "Get")]
        public string GetScoreForQuiz(Guid quizid)
        {

            return "value";
        }
    }
}
