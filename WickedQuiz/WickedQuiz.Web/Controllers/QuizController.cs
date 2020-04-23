using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WickedQuiz.Models.Models;
using WickedQuiz.Models.Repositories;

namespace WickedQuiz.Web.Controllers
{
    public class QuizController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuizRepository _quizRepository;

        public QuizController(UserManager<ApplicationUser> userManager, ICategoryRepository  categoryRepository, IQuizRepository quizRepository)
        {
            this._userManager = userManager;
            this._categoryRepository = categoryRepository;
            this._quizRepository = quizRepository;
        }

        // GET: Quiz
        public async Task<ActionResult> IndexQuizzes()
        {
            var result = await _quizRepository.GetAllQuizzesAsync();
            return View(result);
        }

        public async Task<ActionResult> IndexMyQuizzes()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _quizRepository.GetQuizzesForUserAsync(userId.ToString());
            return View(result);
        }

// GET: Quiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuiz(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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