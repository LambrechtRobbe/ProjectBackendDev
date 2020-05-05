﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WickedQuiz.Models.Models;
using WickedQuiz.Models.Repositories;
using WickedQuiz.Models.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WickedQuiz.Web.Controllers
{
    public class QuizController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment _he;
        private readonly IQuizRepository _quizRepository;
        private readonly IScoreRepository _scoreRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [Obsolete]
        public QuizController(IQuizRepository quizRepository, IAnswerRepository answerRepository, IQuestionRepository questionRepository, IScoreRepository scoreRepository, UserManager<ApplicationUser> userManager, IHostingEnvironment e, IHttpContextAccessor httpContextAccessor)
        {
            _he = e;
            _userManager = userManager;
            _quizRepository = quizRepository;
            _scoreRepository = scoreRepository;
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: Quiz
        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult> QuizzesAsync()
        {
            var result = await _quizRepository.GetAllQuizzesAsync();
            return View(result);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> MyQuizzesAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _quizRepository.GetQuizzesForUserAsync(userId);
            return View(result);
        }

        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult> ScoresQuizAsync(string quizid)
        {
            var result = await _scoreRepository.GetAllScoresForQuizzesAsync(quizid);
            ViewBag.quizid = quizid;
            return View(result);
        }

        [Authorize(Roles = "Administrator, User")]
        public ActionResult ResultQuiz()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult> StartQuizAsync(string quizid)
        {
            var result = await _quizRepository.GetQuizForQuizIdAsync(Guid.Parse(quizid));
            return View(result);
        }

        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult> PlayQuizAsync(string quizid)
        {
            try
            {
                Quiz quiz = await _quizRepository.GetQuizForQuizIdAsync(Guid.Parse(quizid));
                ScoreUser_VM scoreUser_VM = new ScoreUser_VM() { QName = quiz.Name, QId = quiz.Id };
                var questions = await _questionRepository.GetQuestionsForQuizAsync(scoreUser_VM.QId);
                var question = questions[scoreUser_VM.QIndex];

                var answers = await _answerRepository.GetAnswersForQuestionAsync(question.Id.ToString());

                scoreUser_VM.Question = question;
                scoreUser_VM.Answers = answers;
                ViewBag.Score = 0;
                return View("PlayQuiz", scoreUser_VM);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return View();
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult> NextQuestion(Guid QId, string QName, int QIndex, string Correct, int Score)
        {
            try
            {
                ScoreUser_VM score1 = new ScoreUser_VM() { QName = QName, QId = QId, QIndex = QIndex };
                var questions = await _questionRepository.GetQuestionsForQuizAsync(score1.QId);
                score1.QIndex++;
                if (Correct == "correct"){ Score += 1; }
                if (score1.QIndex >= questions.Count())
                {
                    Score newscore = new Score()
                    {
                        ApplicationUserId = _userManager.GetUserId(User),
                        QuizId = score1.QId,
                        MaxScore = questions.Count(),
                        FinalScore = Score
                    };
                    await _scoreRepository.AddScoreAsync(newscore);
                    return View("ResultQuiz", newscore);
                }
                else
                {
                    var objquestion = questions[score1.QIndex];
                    IList<Answer> answers = await _answerRepository.GetAnswersForQuestionAsync(objquestion.Id.ToString());
                    score1.Question = objquestion;
                    score1.Answers = answers;
                    ViewBag.score = Score;
                    return View("PlayQuiz", score1);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return View();
            }
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult CreateQuiz() => View();

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuiz(Quiz quiz)
        {
            try
            {
                IList<Question> questions = new List<Question>();
                for (var i = 0; i < quiz.QuestionCount; i++)
                {
                    List<Answer> answers = new List<Answer>();
                    for (var j = 0; j < 4; j++)
                    {
                        Answer answer = new Answer() { };
                        answers.Add(answer);
                    }
                    Question question1 = new Question() { Answers = answers, Quiz = quiz };
                    questions.Add(question1);
                }
                ViewBag.QuizId = quiz.Id;
                ViewBag.QuizName = quiz.Name;
                ViewBag.QuizDescript = quiz.Description;
                ViewBag.QuizDiff = quiz.Difficulty;
                return View("AddQuestionToQuiz", questions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return View();
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<ActionResult> AddQuestionToQuiz(IList<Question> questions, List<IFormFile> questionimg, List<string> listimgindex, string quizname, string quizdiff, string quizdescript)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var uploadPath = Path.Combine(_he.WebRootPath, "images");
                int imgCounter = 0;
                int isaindex = 0;
                Quiz quiz = new Quiz() { Name = quizname, Description = quizdescript, Difficulty = (Quiz.Difficulties)Enum.Parse(typeof(Quiz.Difficulties), quizdiff), QuestionCount = questions.Count(), ApplicationUserId = userId };
                await _quizRepository.AddQuizAsync(quiz);
                foreach (var question in questions)
                {
                    question.Quiz = quiz;
                    await _questionRepository.AddQuestionAsync(question);
                    if (Int16.Parse(listimgindex[isaindex]) == 1)
                    {
                        if (questionimg[imgCounter].Length > 0)
                        {
                            var filePath = Path.Combine(uploadPath, question.Id + ".jpg");
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await questionimg[imgCounter].CopyToAsync(fileStream);
                            }
                        }
                        imgCounter++;
                    }
                    isaindex++;
                }
                var result = await _quizRepository.GetAllQuizzesAsync();
                return View("Quizzes", result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return View("MyQuizzes");
            }
        }
    }
}