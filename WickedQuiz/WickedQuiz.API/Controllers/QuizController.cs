using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme + ",Identity.Application";

        public QuizController(IQuizRepository quizRepository, IScoreRepository scoreRepository)
        {
            _quizRepository = quizRepository;
            _scoreRepository = scoreRepository;
        }

        // GET: api/Quiz
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllQuizzesAsync()
        {
            var returnMessage = "";
            try
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
            catch (Exception ex)
            {
                returnMessage = $"Foutief of ongeldig request: {ex.Message}"; ModelState.AddModelError("", returnMessage);
            }
            return BadRequest(returnMessage);
        }

        // GET: api/Quiz/5
        [Authorize]
        [HttpGet("scores/{quizid}", Name = "GetScoresForQuiz")]
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Administrator, User")]
        public async Task<IActionResult> GetScoreForQuizAsync(string quizid)
        {
            var returnMessage = "";
            if (!Guid.TryParse(quizid, out var newGuid))
            {
                return BadRequest("Onvolledige gegevens.");
            }
            try
            {
                ScoreTable_DTO scoreTable_DTO = new ScoreTable_DTO();
                var scores = await _scoreRepository.GetAllScoresForQuizzesAsync(Guid.Parse(quizid));
                List<ScoreTable_DTO> scoreTable_DTOs = new List<ScoreTable_DTO>();
                foreach (var obj in scores)
                {
                    scoreTable_DTO = ScoreMapper.ConvertTo_DTO(obj, ref scoreTable_DTO);
                    scoreTable_DTOs.Add(scoreTable_DTO);
                }
                return Ok(scoreTable_DTOs);
            }
            catch (Exception ex)
            {
                returnMessage = $"Foutief of ongeldig request: {ex.Message}"; ModelState.AddModelError("", returnMessage);
            }
            return BadRequest(returnMessage);
        }
    }
}
