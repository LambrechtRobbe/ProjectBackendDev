using System.Collections.Generic;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;

namespace WickedQuiz.Models.Repositories
{
    public interface IAnswerRepository
    {
        Task<Answer> AddAnswerAsync(Answer answer);
        Task<IEnumerable<Answer>> GetAnswersForQuestionAsync(string questionId);
    }
}