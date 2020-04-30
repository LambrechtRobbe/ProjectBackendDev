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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly WickedQuizDbContext _context;

        public QuestionRepository(WickedQuizDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Question>> GetQuestionsForQuizAsync(string quizid)
        {
            try
            {
                var result = await _context.Questions.Where(n => n.QuizId == Guid.Parse(quizid)).ToListAsync<Question>();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Question> AddQuestionAsync(Question question)
        {
            try
            {
                var result = _context.Questions.AddAsync(question);
                await _context.SaveChangesAsync();
                return question;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }
    }
}
