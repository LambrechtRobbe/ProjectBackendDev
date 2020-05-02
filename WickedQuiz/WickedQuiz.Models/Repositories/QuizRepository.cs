using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;
using WickedQuiz.Web.Data;

namespace WickedQuiz.Models.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly WickedQuizDbContext _context;

        public QuizRepository(WickedQuizDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            try
            {
                var result = await _context.Quizzes.Include(a => a.ApplicationUser).Include(q => q.Questions).ThenInclude(q => q.Answers).ToListAsync<Quiz>();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Quiz>> GetQuizzesForUserAsync(string applicationuserid)
        {
            try
            {
                var result = await _context.Quizzes.Where(n => n.ApplicationUserId == applicationuserid).ToListAsync<Quiz>();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Quiz> GetQuizForQuizIdAsync(Guid quizid)
        {
            try
            {
                var result = await _context.Quizzes.Include(p => p.Questions).ThenInclude(it => it.Answers).SingleOrDefaultAsync<Quiz>(p => p.Id == quizid);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Quiz> AddQuizAsync(Quiz quiz)
        {
            try
            {
                var result = _context.Quizzes.AddAsync(quiz);
                await _context.SaveChangesAsync();
                return quiz;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }
    }
}
