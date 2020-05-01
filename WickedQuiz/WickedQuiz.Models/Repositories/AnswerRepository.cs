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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly WickedQuizDbContext _context;

        public AnswerRepository(WickedQuizDbContext context)
        {
            this._context = context;
        }

        public async Task<IList<Answer>> GetAnswersForQuestionAsync(string questionId)
        {
            try
            {
                var result = await _context.Answers.Where(n => n.QuestionId == Guid.Parse(questionId)).ToListAsync<Answer>();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Answer> AddAnswerAsync(Answer answer)
        {
            try
            {
                await _context.Answers.AddAsync(answer);
                await _context.SaveChangesAsync();
                return answer;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }
    }
}
