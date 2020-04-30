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
        public async Task<ActionResult> PlayQuizAsync(string quizid)
        {
            Quiz quiz = await _quizRepository.GetQuizForQuizIdAsync(Guid.Parse(quizid));
            return View(quiz);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult CreateQuiz() => View();

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateQuizAsync(IFormCollection collection)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; //nog niet juist
                Quiz quiz = new Quiz() { Id = Guid.NewGuid(), Name = collection["Name"], Description = collection["Description"], QuestionCount = Int32.Parse(collection["QuestionCount"]), ApplicationUserId=  userId.ToString()};
                switch (Int16.Parse(collection["Difficulty"]))
                {
                    case 0:
                        quiz.Difficulty = Quiz.Difficulties.easy;
                        break;
                    case 1:
                        quiz.Difficulty = Quiz.Difficulties.medium;
                        break;
                    case 2:
                        quiz.Difficulty = Quiz.Difficulties.hard;
                        break;
                    default:
                        break;
                }
                await _quizRepository.AddQuizAsync(quiz);
                ICollection<Question> questions = new List<Question>();
                for (var i = 0; i < quiz.QuestionCount; i++)
                {
                    List<Answer> answers = new List<Answer>();

                    for (var j = 0; j < 4; j++)
                    {
                        Answer answer = new Answer() { Id = Guid.NewGuid() };
                        answers.Add(answer);
                    }
                    Question question1 = new Question() { Id = Guid.NewGuid(), Answers = answers, Quiz = quiz };

                    questions.Add(question1);
                }
                ViewBag.QuizId = quiz.Id;
                return View("AddQuestionToQuiz", questions);
            }
            catch //(Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<ActionResult> AddQuestionToQuiz(IFormCollection collection, List<IFormFile> questionimg, List<string> listimgindex)
        {
            try
            {
                var uploadPath = Path.Combine(_he.WebRootPath, "images");
                int imgCounter = 0;
                int questioncount = collection["item.QuestionName"].Count();
                // TODO: Add insert logic here
                for (var i = 0; i < questioncount; i++)
                {
                    List<Answer> answers = new List<Answer>();
                    for (var j = 0; j < 4; j++)
                    {
                        //var name = collection["item.QuestionName"][i];
                        int index = j + (i * 4);
                        if (Int32.Parse(collection["answer.Correct"][index]) == 1)
                        {
                            Answer newanswer = new Answer() { Id = Guid.NewGuid(), AnswerName = collection["answer.AnswerName"][index], Correct = Answer.State.correct };
                            answers.Add(newanswer);
                        }
                        else
                        {
                            Answer newanswer = new Answer() { Id = Guid.NewGuid(), AnswerName = collection["answer.AnswerName"][index], Correct = Answer.State.incorrect };
                            answers.Add(newanswer);
                        }
                    }
                    var value = collection["quizid"][0];
                    Guid QuestionGuid = Guid.NewGuid();
                    if (Int16.Parse(listimgindex[i]) == 1)
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

                    Question newquestion = new Question() { Id = QuestionGuid, QuestionName = collection["item.QuestionName"][i], Answers = answers, QuizId = Guid.Parse(value) };
                    await _questionRepository.AddQuestionAsync(newquestion);
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

        // GET: Quiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}