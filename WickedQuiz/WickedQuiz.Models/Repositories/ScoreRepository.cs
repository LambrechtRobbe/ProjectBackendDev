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

        public async Task<IList<Score>> GetAllScoresForQuizzesAsync(string quizid)
        {
            try
            {
                var fdsfdsfs = await _context.Scores.Include(q => q.Quiz).ThenInclude(a => a.ApplicationUser).Where(n => n.QuizId == Guid.Parse(quizid)).OrderBy(s => s.FinalScore).ToListAsync();
                var result = await _context.Scores.Include(e => e.Quiz).ThenInclude(e => e.ApplicationUser)
                           .GroupBy(e => new { e.QuizId, e.ApplicationUserId, e.MaxScore })
                           .Select(e => new { Score = e.Max(x => x.FinalScore), User = e.Key.ApplicationUserId, maxScore = e.Key.MaxScore, quiz = e.Key.QuizId }).Where(e => e.User == quizid)
                           .OrderByDescending(e => e.Score).ToDictionaryAsync(e => new Score { FinalScore = e.Score, ApplicationUserId = e.User, MaxScore = e.maxScore });
                List<Score> scores = new List<Score>();
                foreach (var obj in result)
                {
                    Score score = new Score()
                    {
                        QuizId = obj.Value.quiz
                    };
                }

                return fdsfdsfs;
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
