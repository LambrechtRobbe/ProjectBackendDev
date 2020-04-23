using System.Collections.Generic;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;

namespace WickedQuiz.Models.Repositories
{
    public interface IQuizRepository
    {
        Task<Quiz> AddQuizAsync(Quiz quiz);
        Task<IEnumerable<Quiz>> GetAllQuizzesAsync();
        Task<Quiz> GetQuizForNameAsync(string quizname);
        Task<IEnumerable<Quiz>> GetQuizzesForUserAsync(string applicationuser);
    }
}