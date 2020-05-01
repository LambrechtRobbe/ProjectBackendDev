using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;
using WickedQuiz.Web.Data;

namespace WickedQuiz.Models.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly WickedQuizDbContext _context;

        public ScoreRepository(WickedQuizDbContext wickedQuizDbContext)
        {
            this._context = wickedQuizDbContext;
        }

        public async Task<IList<Score>> GetAllScoresForQuizzesAsync(Guid quizid)
        {
            try
            {
                var result = await _context.Scores.Include(q => q.Quiz).ThenInclude(a => a.ApplicationUser).Where(n => n.QuizId == quizid).OrderBy(s => s.FinalScore).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Score> AddScoreAsync(Score score)
        {
            try
            {
                var result = _context.Scores.AddAsync(score);
                await _context.SaveChangesAsync();
                return score;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }
    }
}
