using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;

namespace WickedQuiz.Models.Repositories
{
    public interface IScoreRepository
    {
        Task<Score> AddScoreAsync(Score score);
        Task<IList<Score>> GetAllScoresForQuizzesAsync(string quizid);
    }
}