using System;
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
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IScoreRepository _scoreRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [Obsolete]
        public QuizController(IQuizRepository quizRepository, IAnswerRepository answerRepository, IQuestionRepository questionRepository, IScoreRepository scoreRepository, UserManager<ApplicationUser> userManager, IHostingEnvironment e, IHttpContextAccessor httpContextAccessor)
        {
            _quizRepository = quizRepository;
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _scoreRepository = scoreRepository;
            _userManager = userManager;
            _he = e;
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
            var result = await _quizRepository.GetQuizzesForUserAsync(userId.ToString());
            return View(result);
        }

        [Authorize(Roles = "Administrator, User")]
        public async Task<ActionResult> ScoresQuizAsync(string quizid)
        {
            var result = await _scoreRepository.GetAllScoresForQuizzesAsync(Guid.Parse(quizid));
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

                var qstnList = await _questionRepository.GetQuestionsForQuizAsync(scoreUser_VM.QId);
                var qstnSelf = qstnList.ToList()[scoreUser_VM.QIndex];

                var ansListIe = await _answerRepository.GetAnswersForQuestionAsync(qstnSelf.Id.ToString());
                var ansList = ansListIe.ToList();

                scoreUser_VM.Question = qstnSelf;
                scoreUser_VM.Answers = ansList;
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
                var qstnList = await _questionRepository.GetQuestionsForQuizAsync(score1.QId);
                score1.QIndex++;
                if (Correct == "correct"){ Score += 1; }
                if (score1.QIndex >= qstnList.Count())
                {
                    Score newscore = new Score()
                    {
                        ApplicationUserId = _userManager.GetUserId(User),
                        QuizId = score1.QId,
                        MaxScore = qstnList.Count(),
                        FinalScore = Score
                    };
                    await _scoreRepository.AddScoreAsync(newscore);
                    return View("ResultQuiz", newscore);
                }
                else
                {
                    var objquestion = qstnList[score1.QIndex];
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
        public async Task<ActionResult> CreateQuizAsync(Quiz quizze)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                quizze.ApplicationUserId = userId.ToString();
                await _quizRepository.AddQuizAsync(quizze);
                IList<Question> questions = new List<Question>();
                for (var i = 0; i < quizze.QuestionCount; i++)
                {
                    List<Answer> answers = new List<Answer>();
                    for (var j = 0; j < 4; j++)
                    {
                        Answer answer = new Answer() {};
                        answers.Add(answer);
                    }
                    Question question1 = new Question() { Answers = answers, Quiz = quizze };
                    questions.Add(question1);
                }
                ViewBag.QuizId = quizze.Id;
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
        public async Task<ActionResult> AddQuestionToQuiz(IList<Question> questions, List<IFormFile> questionimg, List<string> listimgindex)
        {
            try
            {
                var uploadPath = Path.Combine(_he.WebRootPath, "images");
                int imgCounter = 0;
                int isaindex = 0;
                foreach (var question in questions)
                {
                    await _questionRepository.AddQuestionAsync(question);
                    Guid QuestionGuid = question.Id;
                    if (Int16.Parse(listimgindex[isaindex]) == 1)
                    {
                        if (questionimg[imgCounter].Length > 0)
                        {
                            var filePath = Path.Combine(uploadPath, QuestionGuid + ".jpg");
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await questionimg[imgCounter].CopyToAsync(fileStream);
                            }
                        }
                        imgCounter++;
                    }
                    isaindex++;
                }
                var quizzes = await _quizRepository.GetAllQuizzesAsync();
                return View("MyQuizzes", quizzes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return View("MyQuizzes");
            }
        }
    }
}