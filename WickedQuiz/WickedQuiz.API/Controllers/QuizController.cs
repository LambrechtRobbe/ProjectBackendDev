using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WickedQuiz.API.ApiModels;
using WickedQuiz.Models.Models;
using WickedQuiz.Models.Repositories;

namespace WickedQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IScoreRepository _scoreRepository;

        public QuizController(IQuizRepository quizRepository, IScoreRepository scoreRepository)
        {
            _quizRepository = quizRepository;
            _scoreRepository = scoreRepository;
        }

        // GET: api/Quiz
        [HttpGet]
        public async Task<IActionResult> GetAllQuizzesAsync()
        {
            Quiz_DTO quiz_DTO = new Quiz_DTO();
            var quizzes = await _quizRepository.GetAllQuizzesAsync();
            List<Quiz_DTO> quiz_DTOs = new List<Quiz_DTO>();
            foreach (var obj in quizzes)
            {
                quiz_DTO = QuizMapper.ConvertTo_DTO(obj, ref quiz_DTO);
                quiz_DTOs.Add(quiz_DTO);
            }
            return Ok(quiz_DTOs);
        }

        // GET: api/Quiz/5
        [HttpGet("scores/{quizid}", Name = "GetScoresForQuiz")] //HttpGet("taken/{guid}", Name = "GetTimesTakenByQuiz")
        public async Task<IList<Score>> GetScoreForQuizAsync(string quizid)
        {
            var scores = await _scoreRepository.GetAllScoresForQuizzesAsync(Guid.Parse(quizid));
            return scores;
        }
    }
}
